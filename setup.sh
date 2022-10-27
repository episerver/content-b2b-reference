ROOTPATH=$PWD
ROOTDIR=$PWD
SOURCEPATH=$ROOTPATH/src

add_sql_container()
{
    if [ $( docker ps -a | grep sql_server_optimizely | wc -l ) -gt 0 ]; then
        echo "sql_server_optimizely exists"
    else
        sudo docker run -d --name sql_server_optimizely -h $1 -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Episerver123!' \
           -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
        docker cp ./build sql_server_optimizely:/build
    fi
}

while [ -z "$APPNAME" ]; do
    read -p "Enter your app name: " APPNAME
done

read -p "Enter your SQL server name [localhost]: " SQLSERVER
SQLSERVER=${SQLSERVER:-localhost}

dotnet new -i EPiServer.Templates
dotnet tool update EPiServer.Net.Cli --global --add-source https://nuget.optimizely.com/feed/packages.svc/
dotnet nuget add source https://nuget.optimizely.com/feed/packages.svc -n Optimizely
dotnet dev-certs https --trust

dotnet build
add_sql_container "$SQLSERVER"

cms_db=$APPNAME.Cms
user=$APPNAME.User
password=Episerver123!
errorMessage="" 

mkdir "$ROOTPATH/Build/Logs" 2>nul

cd src/Sample.Web/
npm ci
npm run scripts:dev
npm run styles:dev
cd ../..

docker exec -it sql_server_optimizely /opt/mssql-tools/bin/sqlcmd -S $SQLSERVER -U SA -P $password -Q "EXEC msdb.dbo.sp_delete_database_backuphistory N'$cms_db'"
docker exec -it sql_server_optimizely /opt/mssql-tools/bin/sqlcmd -S $SQLSERVER -U SA -P $password -Q "if db_id('$cms_db') is not null ALTER DATABASE [$cms_db] SET SINGLE_USER WITH ROLLBACK IMMEDIATE"
docker exec -it sql_server_optimizely /opt/mssql-tools/bin/sqlcmd -S $SQLSERVER -U SA -P $password -Q "if db_id('$cms_db') is not null DROP DATABASE [$cms_db]"
docker exec -it sql_server_optimizely /opt/mssql-tools/bin/sqlcmd -S $SQLSERVER -U SA -P $password -Q "if exists (select loginname from master.dbo.syslogins where name = '$user') EXEC sp_droplogin @loginame='$user'"

dotnet-episerver create-cms-database "./src/Sample.Web/Sample.Web.csproj" -S $SQLSERVER -U sa -P $password --database-name "$cms_db"  --database-user $user --database-password $password


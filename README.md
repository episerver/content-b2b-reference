<a href="https://github.com/InsiteSoftware/cms-b2b-starter-kit"><img src="https://www.optimizely.com/globalassets/02.-global-images/navigation/optimizely_logo_navigation.svg" title="Optimizely CMS to B2B Starter Kit" alt="Optimizely CMS to B2B Starter Kit"></a>

# Optimizely CMS to B2B Starter Kit 

 Optimizely CMS to B2B Starter Kit offers a starting point for when using content cloud and b2b commerce cloud together.

---

## Prerequisites

You will need these to run locally on your machine.

[Instance of Optimizely B2B Commerce](https://docs.developers.optimizely.com/commerce/v1.2.0-b2b-commerce/docs/b2b-commerce-cloud-environment-setup-for-developers) Follow the steps in the link to create local developer environment or use cloud environment.

[Net 6](https://dotnet.microsoft.com/download/dotnet/6.0) sdk is required to use with visual studio.  Runtime maybe sufficent to just run the application.

[Node JS](https://nodejs.org/en/download/)

Mac/Linux

[Docker](https://docs.docker.com/desktop/mac/install/)

Windows

[Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)


---

## Installation

### Optimizely B2B Commerce

If you want to install the sample data into commerce do the following

Add <a href="https://github.com/InsiteSoftware/cms-b2b-starter-kit/blob/main/build/UserFiles">user files</a> to b2b installation

Go to Catalog / Brands / Upload and import file <a href="https://github.com/InsiteSoftware/cms-b2b-starter-kit/blob/main/build/Import_Brands.xlsx">Import_Brands.xlsx</a>

Go to Catalog / Products / Upload and import file <a href="https://github.com/InsiteSoftware/cms-b2b-starter-kit/blob/main/build/Brand_Products.xlsx">Brand_Products.xlsx</a> 

Go to Marketing / Indexing and rebuild all

### Windows

```
open command prompt as administrator
git clone https://github.com/InsiteSoftware/cms-b2b-starter-kit.git
cd cms-b2b-starter-kit
git checkout main
setup.cmd 
dotnet run --project ./src/Sample.Web/Sample.Web.csproj
```

### Mac

```
Open a Terminal window
git clone https://github.com/InsiteSoftware/cms-b2b-starter-kit.git
cd cms-b2b-starter-kit
git checkout main
chmod u+x setup.sh
./setup.sh
dotnet run --project ./src/Sample.Web/Sample.Web.csproj
```

### Linux

```
Open a bash terminal window
git clone https://github.com/InsiteSoftware/cms-b2b-starter-kit.git
cd cms-b2b-starter-kit
git checkout main
chmod u+x setup.sh
./setup.sh
dotnet run --project ./src/Sample.Web/Sample.Web.csproj
```

### View the site

After completing the setup steps and running the solution, access the site at <a href="http://localhost:8000">http://localhost:8000</a>.

To change the default port, modify the file <a href="https://github.com/InsiteSoftware/cms-b2b-starter-kit/blob/main/src/Sample.Web/Properties/launchSettings.json">/src/Sample.Web/Properties/launchSettings.json</a>.

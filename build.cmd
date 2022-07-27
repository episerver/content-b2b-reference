@echo off
cd /d %~dp0
mode con:cols=120 lines=2500
set ROOTPATH=%cd%
set ROOTDIR=%cd%
set SOURCEPATH=%ROOTPATH%\src

echo ## Building Foundation please check the Build\Logs directory if you receive errors
echo ## Gettting MSBuildPath ##
for /f "usebackq tokens=*" %%i in (`.\build\vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath`) do (
  set InstallDir=%%i
)

for %%v in (15.0, 14.0) do (
  if exist "%InstallDir%\MSBuild\%%v\Bin\MSBuild.exe" (
    set msBuildPath=\MSBuild\%%v\Bin\MSBuild.exe
	goto :finish
  )
  set  msBuildPath=\MSBuild\Current\Bin\MSBuild.exe
)

:finish
echo msbuild.exe path: %InstallDir%%msBuildPath%

echo ## Gulp build ##  
cd %SOURCEPATH%\Sample.Web
CALL npm run build

cd %SOURCEPATH%
echo ## Clean and build ##
"%InstallDir%%msBuildPath%" CombinedSample.sln /t:Clean,Build
cd %ROOTPATH%
:error
if NOT "%errorMessage%"=="" echo %errorMessage%
pause
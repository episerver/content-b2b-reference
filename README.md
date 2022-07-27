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

## Introduction

Ths repoistory is a sample content cloud application connecting with Optimziely B2B Commerce.

<img src="diagram.png?raw=true" width="60%"/>



---

Here are the following components included in the solution.

### Pages

| Features               | Status              |
|------------------------|---------------------|
| Address Book           | Complete            |
| Brands                 | Incomplete          |
| Cart                   | Complete            |
| Catalog listing        | Complete            |
| Catalog product detail | Complete            |
| Change Password        | Incomplete          |
| Checkout               | Complete            |
| Contact Us             | Incomplete          |
| Content Page           | Complete            |
| Content Search         | Complete            |
| Create Account         | Complete            |
| Forgot Password        | Incomplete          |
| Home Page              | Complete            |
| Invoices               | Incomplete          |
| Login                  | Complete            |
| Logout                 | Complete            |
| My Account             | Needs love          |
| Order Confirmation     | Complete            |
| Order History          | Complete            |
| Product Comparison     | Incomplete          |
| Quick Order            | Partially completed |
| Reset password         | Incomplete          |
| Return Request         | Incomplete          |
| Saved Orders           | Incomplete          |
| Search                 | Complete            |
| Saved Lists            | Incomplete          |


### Block Types

| Features              | Status     |
|-----------------------|------------|
| Button Block          | Complete   |
| Call To Action Block  | Ccomplete  |
| Hero Block            | Complete   |
| Page List Block       | Complete   |
| Recently Viewed Block | Incomplete |
| Recent Orders Block   | Incomplete |
| Teaser Block          | Complete   |
| Text Block            | Complete   |
| Video Block           | Complete   |
| Vimeo Block           | Complete   |
| Youtube Block         | Complete   |


---

## Installation

### Optimizely B2B Commerce

The cms application utilizes the c-sharp Optimizely SDK nuget package which can be found <a href="https://www.nuget.org/packages/Optimizely.Commerce.API">here</a>.

If you need to step into the code you can download the repo <a href="https://github.com/InsiteSoftware/commerce-csharp-sdk">here</a>.  

The nuget pacakge should also contain symbols if you need to step through in the the debugger.

To configure the SDK you ust register the services in Startup.cs

```
services.AddCommerceSdk("url", "clientId", "clientSecret"", cachingEnabled); 
```

In the Sample.Web use can use te following appsettings to set the values in src\sample.web\appsettings.json.  You will want to change the client id and secret for production.

```
"CommerceApi": {
    "BaseUrl": "changme",
    "ClientId": "clientId",
    "ClientSecret": "clientSecret",
    "EnableCaching": "false"
  },
```

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

<a href="https://github.com/episerver/cms-b2b-reference-kit"><img src="https://www.optimizely.com/globalassets/02.-global-images/navigation/optimizely_logo_navigation.svg" title="Optimizely CMS to B2B Starter Kit" alt="Optimizely CMS to B2B Starter Kit"></a>

 
# Optimizely CMS to B2B Reference Kit
This kit provides a starting point for connecting Content Cloud and B2B Commerce. 

## Prerequisites
You will need the following running locally:
- A local developer or cloud Optimizely B2B Commerce instance.
- Net 6 SDK is required to use visual studio. Runtime may be sufficient to run the application alone.
- Node JS 14+
- Docker (Mac/Linux)
- Sql Server (Windows)

## Introduction
This repository is a sample integration between Content Cloud and B2B Commerce. It is meant to show how to create a content cloud site as the front end for a Optimizely B2B commerce instance.  This repository requires a working instance of B2B commerce cloud.  Please look [here](https://docs.developers.optimizely.com/commerce/v1.2.0-b2b-commerce/docs/b2b-commerce-cloud-environment-setup-for-developers) on how to create a local instance of B2B commerce or you can use your cloud instance. When running the setup script it will create a local instance of content cloud by performing the following actions

1.  Install node dependencies
2.  Webpack the scripts
3.  Create the stylesheets
4.  Build the solution
5.  Create the database
6.  Update the connectionstrings
7.  When starting the site, the sample content will be imported which contains the site structure of the site.

After developing locally you can push your code to content cloud through the deployment api [here](https://docs.developers.optimizely.com/digital-experience-platform/v1.2.0-dxp-cloud-services/docs/deploy-using-powershell).  If you would like to deploy to your own [server](https://docs.developers.optimizely.com/content-cloud/v12.0.0-content-cloud/docs/deploying-to-windows-servers) or [cloud instance](https://docs.developers.optimizely.com/content-cloud/v12.0.0-content-cloud/docs/deploying-to-azure-webapps). 

![Integration Overview Diagram](https://github.com/episerver/content-b2b-reference/blob/main/diagram.png?raw=true)

### Included Components

| Features               | Status              |
|------------------------|---------------------|
| Address Book           | Complete            |
| Brands                 | Not Provided        |
| Cart                   | Complete            |
| Catalog listing        | Complete            |
| Catalog product detail | Complete            |
| Change Password        | Not Provided        |
| Checkout               | Complete            |
| Contact Us             | Not Provided        |
| Content Page           | Complete            |
| Content Search         | Complete            |
| Create Account         | Complete            |
| Forgot Password        | Not Provided        |
| Home Page              | Complete            |
| Invoices               | Not Provided        |
| Login                  | Complete            |
| Logout                 | Complete            |
| My Account             | In Progress         |
| Order Confirmation     | Complete            |
| Order History          | Complete            |
| Product Comparison     | Not Provided        |
| Quick Order            | In Progress         |
| Reset password         | Not Provided        |
| Return Request         | Not Provided        |
| Saved Orders           | Not Provided        |
| Search                 | Complete            |
| Saved Lists            | Not Provided        |

### Block Types

| Blocks          | Status              |
|-----------------|---------------------|
| Button          | Complete            |
| Call to Action  | Complete            |
| Hero            | Complete            |
| Page List       | Complete            |
| Recently Viewed | Not Provided        |
| Recent Orders   | Not Provided        |
| Teaser          | Complete            |
| Text            | Complete            |
| Video           | Complete            |
| Vimeo           | Complete            |
| Youtube         | Complete            |

## Setup Instructions
1. Setup

### Windows

```
    open command prompt as administrator
    git clone https://github.com/episerver/cms-b2b-reference-kit.git
    cd cms-b2b-starter-kit
    git checkout main
    setup.cmd 
    dotnet run --project ./src/Sample.Web/Sample.Web.csproj
```

### Mac

```
    Open a Terminal window
    git clone https://github.com/episerver/cms-b2b-reference-kit.git
    cd cms-b2b-starter-kit
    git checkout main
    chmod u+x setup.sh
    ./setup.sh
    dotnet run --project ./src/Sample.Web/Sample.Web.csproj
```

 ### Linux

 ```   
    Open a bash terminal window
    git clone https://github.com/episerver/cms-b2b-reference-kit.git
    cd cms-b2b-starter-kit
    git checkout main
    chmod u+x setup.sh
    ./setup.sh
    dotnet run --project ./src/Sample.Web/Sample.Web.csproj
 ```

2.	Configure B2B Commerce API SDK

    The CMS application uses the C# Optimizely SDK NuGet package. You can also access and download the code repository.

    To configure the SDK you must register the services in Startup.cs

    `services.AddCommerceSdk("url", "clientId", "clientSecret"", cachingEnabled)`

    In the Sample.Web you can use the following appsettings to set the values in **src\sample.web\appsettings.json**. 
    
    You should change the client ID and secret for production.

    ```
    "CommerceApi": {
        "BaseUrl": "https://commerce.local.com", //B2B Commerce API Url
        "ClientId": "isc",
        "ClientSecret": "009AC476-B28E-4E33-8BAE-B5F103A142BC",
        "EnableCaching": "false" //Required to be false
    }
    ```

## View the site
You can access the site at http://localhost:8000 after completing the setup and running the solution.
To change the default port, modify the /src/Sample.Web/Properties/launchSettings.json file.

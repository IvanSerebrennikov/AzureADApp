# AzureADApp 

- Default ASP .NET 4.5.2 Web Application with MVC template. 

- Additional installed NuGet packages:  
> Microsoft.Owin.Security.OpenIdConnect  
> Microsoft.Owin.Security.Cookies  
> Microsoft.Owin.Host.SystemWeb  
> Microsoft.IdentityModel.Clients.ActiveDirectory  
> Microsoft.Graph.Core  

- Front-end: jQuery, Bootstrap.  

- No DataBase needed. 

- To build app you need Visual Studio, MS Build or any other tool that can compile c# and build .net apps

- To run app you need paste your Azure AD settings in next Web.config sections: 
```xml
 <add key="AzureAppId" value="" />
 <add key="AzureAppName" value="" /> <!--(tenant name)-->
 <add key="AzureAppSecret" value="" />
 <add key="AzureRedirectUri" value="" />
```

- Server machine should have Windows OS with .NET Framework 4.5.2 and ASP.NET installed, IIS enabled. 

- Possible improvements: use access token cache, use refresh token.

- Another way to implement this functionality is store base Azure users and groups data in external database like MS SQL Server. 
Populate this database by scheduler that run every day in any time, retrieve data from Azure AD with Graph API and store this data to our database. 
Then our app will use this local database to view users and groups. 
This approach will reduce both the number of requests for access token and the number of requests to Graph API.

# Daemon-App-calling-Authenticated-Azure-Function-API
This project contains sample code for making calls from a background job to an authenticated Azure function api. This approach user app's access token to connect to API

## ## Register an Azure AD app for the Daemon Console Application
1. Copy the client id and client secret from Azure AD.

In the below code make following changes:

 resourceId  --> Azure AD App id used for configuring authentication of the Azure function app.
 
clientId --> Azure AD app id of the app registered for the console app.

clientsecret --> Secret of the Azure AD app registered for the console app.



            string resourceId = "<id of Azure AD app used for Azure Function authentication>";  // AAD app ID used by the Azure function for authentication
            string clientId = "<id of Azure AD app registered for the Daemon job>";// AAD app ID of your console app
            string clientSecret = "<secret of Azure AD app for Daemon job>"; // Client secret of the AAD app registered for console app
            string resourceUrl = "https://blahblah.azurewebsites.net/api/events"; //HTTP function Endpoint to get events
            string domain = "<yourtenant>.onmicrosoft.com";   //Tenant domain
          

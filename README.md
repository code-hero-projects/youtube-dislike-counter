#  YouTube Dislike Counter
This is the solution for the YouTube Dislike Counter. It is made out of two parts, the backend and the frontend.

##  Backend

The backend is a ASP .NET Core 6 solution. To be able to run it you have to first change some variables in the **appsettings.Development.json** file:

- {COSMOS_DB_ACCOUNT_ENDPOINT} -> your own account endpoint for a CosmosDb database
- {DATA_API_KEY} - your own Data Api Key

After those changes you can either run the Api project or use the Dockerfile that's in the project to run it with Docker.

##  Frontend

The frontend is a browser extension that you can install in your browser. This extension makes uses of the Backend already mentioned to fetch the number of dislikes and update them.

To run it you run the following commands in the frontend folder:
- npm install
- npm run build

This will create a dist folder in the inside the frontend folder, which you only need to unpack in your browser as an extension.

**Note:** The extension will only work for **Chrome**.
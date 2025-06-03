# Set Up
Go to appsettings.json and update the connection string to the connection string of your local database
```
"ConnectionStrings": {
    "localSQLServer": ""
  },
```
after that run the following commands in a terminal to create the database
```
cd APIPlanoDeReficoes
dotnet ef database update
```

# Testing the application

To test the application open the APIPlanoDeReficoes.sln in visual studio or jetbrains rider and run the project.
After that import the collections from the Postman_Collections folder and run the requests in the following order:

1. Users/Create user admin
2. Users/ Create nutricionist user

After running this to requests a admin user and nutritionist user should have been created, after that you should run the requests to create the jwt token:

* Users/ Login admin
* Users/ login nutricionist

Finally you can run the requests for Food and Users by updating the bearer token to a new admin token and the MealPlans requests by updating the bearer token to a new nutricionist token
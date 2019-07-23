# RBAC (Role Based Access Control)
This is a sample application built on .net core for controlling access to any resource based on user roles.

It has below components:

1) RBA.Web which is a web api project.
2) RBA.Data which has database entities and database structure.

The program is using InMemoryDatabase using EntityFramework. Under RBA.Data project, we have database entities classes and repository classes for accessing the database tables.

The repository classes are accessed in RBA.Web using dependency injection and the implementation of the classes are registered in Startup.cs class under ConfigureServices().

In .net core api, whenever a request hits your application, it goes through a chain of filters which are known as middlewares here before hitting your actual api controller. These middlewares are registered in Configure() in startup.cs class.

Since for any authorization system to work we also need an authentication system, i have mocked an authentication system inside AuthenticationMiddleware.

The AuthenticationMiddleware adds a number of claims to HttpContext and passes the request to AuthorizationMiddleware which has the logic of checking whether the user has access to the resource or not.

Database Structure:
1) User Table
2) Resource Table
3) Roles Table
4) Action Type Table
5) ActionTypeRoleMapping table for mapping ActionTypes to Roles
6) ResourceRoleMapping table for mapping resource to roles.
7) UserRolesMapping table for mapping users to roles.

RolesDbContext.cs class contains database table structure as well as key relationships.

For initializing data in the database, DatabaseContext class is used.

For logging, console logs are being used which is also injected using dependency injection.

# How to run :-

To run this project, dotnet installation is needed.
You can download .net from below link:-
https://dotnet.microsoft.com/download/dotnet-core/2.2 

After the installation, you need to build the project.
To build, use below command:

dotnet build LocusRBAProject.sln
 

After the build is successful, go to the RBA.Web\bin\Debug\netcoreapp2.2 folder and execute the below command:

dotnet run RBA.Web.dll
 

After executing the above command, your api will be hosted and can be accessed using the url logged as output of the run command.
 

Authorized api: http://localhost:5000/api/values

Unauthorized api: http://localhost:5000/api/values/5


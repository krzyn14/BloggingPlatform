**Installation and running the app:**
1. Pull or download the repository
2. Open Package Manager Console in VSC and run the commands:
   
   ```
   Add-Migration NewMigration
   ```
   Then:
   ```
   Update-Database
   ```
3. To seed data open Terminal/Powershell in this directory:
   ```
   ..\BloggingPlatform\BloggingPlatform
   ```
   And run:
   ```
   dotnet run seeddata
   ```
4. Now you can run the application and test API manually or run unit tests for Remove and Edit blog posts methods (instruction below)

**Running unit tests** 
1. Open Terminal/Powershell in BlogginPlatform.Tests directory
2. Run this command:
    
   ```
   dotnest test
   ```

**Assignment: Building a Blogging Platform**

You are tasked with building a simple blogging platform where users can create and view blog posts. The application should have a backend API developed in ASP.NET Core and use Entity Framework for data access

**Requirements that I tried to implement:**
1.	Domain Model
 - Every User possesses the following attributes: ID, Username, and Email (which must be unique).
 -  Each BlogPost is characterized by the following attributes: ID, Title, Content, and timestamps for creation and updates.
 -	A User can be associated with multiple BlogPosts, and each BlogPost belongs to a single User.

2. Entity Framework:
-	Use Entity Framework Core to create models for the Users and BlogPosts tables.
-	Implement a DbContext to configure the database connection and relationships between User and BlogPost entities.
-	Seed the database with at least two users and a few sample blog posts for each user using EF migrations or a data seeding mechanism.

3. API:
- Create an API controller for managing blog posts.
   -	Implement CRUD (Create, Read, Update, Delete) operations for blog posts.
   -	Ensure that users can only edit/delete their own blog posts.
- Create an API controller for managing user profiles.
  -	Implement endpoints to retrieve user profiles and their associated blog posts.
-	Use appropriate HTTP methods (GET, POST, PUT, DELETE) and status codes.
-	Implement data validation and error handling in the API.

4. Testing:
-	Write unit tests which verify requirement 3.1.b


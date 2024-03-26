**Installation and running the app:**
1. Pull the repository
2. Seed data to the db
3. Now you can run the application and test API manually or run unit tests for Remove and Edit posts methods (instruction below)

**Running the unit tests** 
1. Open powershell in BlogginPlatform.Tests directory
2. Run dotnest test command

**Requirements that I tried to implement:**
1.	Domain Model
o	Every User possesses the following attributes: ID, Username, and Email (which must be unique).
o	Each BlogPost is characterized by the following attributes: ID, Title, Content, and timestamps for creation and updates.
o	A User can be associated with multiple BlogPosts, and each BlogPost belongs to a single User.

2. Entity Framework:
o	Use Entity Framework Core to create models for the Users and BlogPosts tables.
o	Implement a DbContext to configure the database connection and relationships between User and BlogPost entities.
o	Seed the database with at least two users and a few sample blog posts for each user using EF migrations or a data seeding mechanism.

3. API:
1.	Create an API controller for managing blog posts.
  a.	Implement CRUD (Create, Read, Update, Delete) operations for blog posts.
  b.	Ensure that users can only edit/delete their own blog posts.
2.	Create an API controller for managing user profiles.
  a.	Implement endpoints to retrieve user profiles and their associated blog posts.
3.	Use appropriate HTTP methods (GET, POST, PUT, DELETE) and status codes.
4.	Implement data validation and error handling in the API.

4. Testing:
o	Write unit tests which verify requirement 3.1.b


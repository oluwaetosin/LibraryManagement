
# Library Management

Library Project to Facility Management of books



# Installation using docker compose
- Clone git clone git@github.com:oluwaetosin/LibraryManagement.git
to your local pc
- if not in master branch git checkout to master branch
- cd into **/LibraryManagement/src** directory
-  to run the application as docker execute below command:
    **docker-compose up**
- Once application is successfully built and ready it will be available on http://localhost:8084/swagger/index.html
# Installation using visual studio
- Clone git clone git@github.com:oluwaetosin/LibraryManagement.git
to your local pc
- if not in master branch git checkout to master branch
- cd into **/LibraryManagement/src** directory
- open the Library.sln file in visual studio and it will laod the Projects
- Set the Library.Api as the startup project
- run the followin in Package manager console to setup the Database:
dotnet ef database update -p  Library.Infrastructure -s Library.Api 
- Ensure the application runs on localhost port 8084 for github Oauth2 to work correctly
# Database
Sqlite is used for persistence in the application
# Authentication
- The application use github Oauth2 provider to provide authentication. To consume the swagger apis do the follow:
    - While the applciation is running, open the link: http://localhost:8084/api/auth/login In a separate browser tab. This link will redirect to Github for authorization after which it redirects back to a page dispalying the follwing:
    -  Email
    - access token
    - JWT token

- Copy the jwt token and paste in swagger authorize box in the header right corrner. 
- The Apis should then be ready to use.

# Description of Endpoints

| End Point     | Method    | Description                     | 
| --------------|--------   | ----------------------------------|
| http://localhost:8084/api/Book  |    POST       | Creat new Book                       |                    |
|               |           |
|http://localhost:8084/api/Book | GET | List All books
|http://localhost:8084/api/Book/<Book id> | Get | Get book by Id
|http://localhost:8084/api/Book/<Book id> | PUT | Update a book record
http://localhost:8084/api/Book/search?Name=<book name> | GET | Search for a book by book name
http://localhost:8084/api/Book/<book id>/reserve | POST | Reserve a book for 24hr
http://localhost:8084/api/Book/<book id>/borrow  | POST | Borrow a book
http://localhost:8084/api/Book/<book id>/request-notifification | POST | Subscribe to Availability notifification of a book

# Project Structure
The Solution is made up of 5 Sub Projects:

| Project     | Description     
| --------------|--------    
| Library.Api  |   The User Interface of the Solution. A Web Api that provides the interface for user interraction. References the Library.Contracts, Library.Application                        
|Library.Application | Contains the Business Logic and define repository interfaces
|Library.Contracts| Defines the contracts/payload structure of Libray.Apis endpoints  
|Library.Domain | Define the Database Models  
|Library.Infrastructure | Implements Database Interraction Logics  
 


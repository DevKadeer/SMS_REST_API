### Code Assignment

# SMS fullstack challenge : Problem statement

### Your mission, should you choose to accept it

1. Setup a database of your choice and seed it from the `data.json`.
2. Write a backend that provides a RESTful interface to interact with this data
(CRUD).
3. Create a frontend that displays a table with the columns
**city**, **start date**, **end date**, **price**, **status**, **color**.
All columns should be sortable. The data is requested from the backend.
4. Above the grid, please add two date pickers to filter the object by date
range.

Though this is a small app, please pay attention to your application structure.
Host your code on github or bitbucket and include a README with instructions on
how to install and run your application. Bonus-points for providing a
docker-compose file to run your project :)

# Assignment Approach:

I have distributed the code challenge into two parts:
 
 1) SMS_REST_API : This includes the REST API for the requested resource.
 2) SMS-FrontEnd: This is a front end of the challenge. It consumes `SMS_REST_API` endpoints to meet the resource requests.


# SMS_REST_API

.Net Core Web API project for city CRUD operation.

NOTE:  sms-frontend(https://github.com/DevKadeer/sms-frontend) depends upon this project to get the realTime data.

## Dependencies

Using Microsoft SQL Server as DB server


## Running project via Command prompt

Run `dotnet run` to run the project.

REST API will start listening on: https://localhost:5111

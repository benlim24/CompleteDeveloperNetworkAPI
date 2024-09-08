# CompleteDeveloperNetworkAPI

### This is a Swagger Restful API project that allows users to update a list of freelancers within an Azure database (SQL server)
### Link to access the Restful API: https://completedevelopernetworkapi.azurewebsites.net/swagger/index.html
### This Restful API consists of 4 parts: 

## POST: Allows the user to create/edit details of the freelancer.
### Inputs: Id, Email, PhoneNumber, Skillsets, Hobbies, UserName

### To add new freelancer:
### Id input should be set to 0 to allow generation of new freelancer

### To edit new freelancer:
### Id input should be set to the Id of the existing freelancer in the database


## GET{id}: Allows the user to get details of a freelancer based on the inputted id. 
### Input: Id
### Outputs: Id, Email, PhoneNumber, Skillsets, Hobbies, UserName


## DELETE{id}: Allows the user to delete a record of a freelancer based on the inputted id.
### Input: Id

## GETALL: Allows the user to get a list of all the freelancer records in the database. 
### Input: No inputs required
### Outputs (Details of all freelancers): Id, Email, PhoneNumber, Skillsets, Hobbies, UserName

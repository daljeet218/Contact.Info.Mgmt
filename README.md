# Contact Information Management

# Folder Structure

 - The Main Project is Divided into 4 Projects namely: 
 
 - 1) Contact.Info.Mgmt.API:
 - This project includes subfolder to contain the controller, extensions, mappers, repository and other relevant resource files.

 - 2) Contact.Info.Mgmt.DataModel
 - This project contains all the necessary models, interfaces, repositories and enums in the respective folders.

 - 3) Contact.Info.Mgmt.ServiceGateways
 - This project contains only the service gateway folder containing the Contact Service to perform the main CRUD functionality.

 - 4) Contact.Info.Mgmt.UnitTest
 - This is a Xunit test project which contains 2 folders for controller endpoint unit tests and service mock needed for the respective tests
  

# How to Run

 - Clone/Download the repository and open the project using Visual Studio.
 - Open the Contact.Info.Mgmt.Sln solution and build it. 
 - If needed do a nuget package restore and run the project as usual.

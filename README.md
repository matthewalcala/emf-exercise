# emf-exercise
Coding Exercise for EMF


Installation:
- LocalDB Database: I am using localdb which installs with Visual Studio. If you have this installed you should be good to go for the dbcontext without changing the connectionstring.

- To run the migration and setup the database, run the following commands from the cloned repo directory:
 1. "cd emf.data"
 2. "dotnet ef database update -s ..\emf\emf.csproj"

Notes:
- You can toggle between in-memory data service and SQL data service (IoC) in startup.cs

To run the application:
- Open the solution in visual studio
- Build the solution
- Ctrl-F5

Next steps:
- Add unit testing
- Use automapper for updates vs setting each value
- Add toast like notification for add, update, and delete
- Remove Cascade Delete for Dept/Employees! (For every employee in dept, set dept to null) 
- Fix bug with tempdata which displays delete successful message. Plan was to use Toast notifications though

# EdtTest
A sample library API for EDT

## Setting Up the Database
In order to initialise the database, you must first add a connection string and ensure that you have LocalDB installed on your machine.  The connection string may either be added directly to appsettings.json in the API project or you may add it to your user secrets (preferred option). The key for the connection string must be "LibraryContextConnection". The value for the connection string may be as simple asthe following:

`Server=(localdb)\\mssqllocaldb;Database=edt-test-library-api;Trusted_Connection=True;MultipleActiveResultSets=true`

Once you have the connection string you must then ensure that you have LocalDB installed on your machine.  If you require assistance with installation, the following article on [Microsoft's website](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16) should guide you through the process of installation: 

https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16

Once both the connection string is ready and LocalDB is installed, the database will need to be created.  In visual studio, open the Package Manager Console.  If you need to find it go to View -> Other Windows -> Package Manager Console.  When you have the console open, ensure you have the correct project "EdtTest.Data" selected as the "Default project" in the right-hand drop-down menu at the top of the Package Manager Console window.  When you have confirmed you have the correct project selected, enter the following command and hit enter:

`Update-Database`

If the database exists, any migrations which have not been applied will be run to bring the schema up to date.  If it does not exist, a new database will be created with the name specified in the connection string and all migrations will be applied.

Now you are ready to launch the application in debug mode from Visual Studio.  Just press F5.


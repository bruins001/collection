# collection-dot-net
Orginizes phisical collections. This is a simple Create Read Update Delete application. It is currently in development, but it will support tools, books, commic-books and movies in the future.

# Installation
This documentation for installation in the development state.
## Prerequisites
- Command prompt / Powershell
- SDK .NET 9
- Git
- Docker / A native installation of Postgres
## Installation Steps
1. Clone the repository:
```
git clone https://github.com/bruins001/collection.git
```

2. Go inside the folder and build the project:
```
cd {git-folder}/collection
dotnet build
```

3. Validate the application runs:
```
dotnet watch
```
The application should run now, but there is no connection to the database.

4. Start the postgres server. If you use Docker and want to create a new database server run:
```
docker run --name {container-name} -p 5432:5432 -e POSTGRES_PASSWORD={password} -d postgres
```
:warning: **IMPORTANT: You should change the password of the database. It is set by the enviroment variable POSTGRES_PASSWORD and has {} around it. Don't forget to remove the {}.**
Replace container-name with the container name you want to use and remove the {}. You could add a ```--rm``` to remove the container when it you stop the server. You can also change the port from the container at -p the ports are mapped the following way ```host:container```. You can also change the container name at ```--name```.
If you get the error: ```docker: error during connect: Head "http://%2F%2F.%2Fpipe%2FdockerDesktopLinuxEngine/_ping": open //./pipe/dockerDesktopLinuxEngine: The system cannot find the file specified.``` check if docker is on.

5. Enter the commandline of the postgres server. If you use docker run the command below:
```
docker exec -it {container-name} psql -U postgres
```

6. Create a database. The database configured in the Default connection string in the project directory: ```collection/appsettings.Development.json```. The default database for the project is called collection, but you can change that if you wish:
```
CREATE DATABASE {database};
```
Replace database with the database name you want to use and remove {}. Remember that the default database name is collection and if you want to use another database name you should update ```collection/appsettings.Development.json```.

7. Create a user. And grant all permissions for the database.
```
CREATE USER {username} with encrypted password {'password'};
ALTER DATABASE {database} OWNER TO {username};
```
:warning: **IMPORTANT: You shouldn't give the user ownership of the database for security reasons. To do this safe contact your database administrator.**
You should change the username, password and database remove the {} but leave the ''.

8. Go to the project you cloned from github and go to the collection folder. Init the use of user-secrets for you project, add a user-secret for the username with the key "ConnectionStrings:DefaultUsername". And a password with the key "ConnectionStrings:DefaultPassword".
```
cd collection
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultUsername" {"username"} --project {"project-dir full path including your drive letter and collection folder"}
dotnet user-secrets set "ConnectionStrings:DefaultPassword" {'password'} --project {"project-dir full path including your drive letter and collection folder"}
```
Change the username, password and project path and remove the {}, but leave the "" and ''.

9. Create a migration and migrate it:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

10. Update the database. Add a brand and a tool. See step 5 for logging in to the database.
```
\c {database}
INSERT INTO public."Brands" ("Name") VALUES ('brand');
INSERT INTO public."Tools" ("Name", "BrandId", "Type", "Electrical", "ProductCode", "Ean13") VALUES ('name', 1, 'type', true, 'product code', '1234567891234');
```
Replace database with your database and remove {}.

11. You can start the server agian see step 3. The application should work now.
# Contributions
This repository is currently closed for contributions.

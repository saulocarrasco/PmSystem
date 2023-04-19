# PmSystem

## Local Environment Configuration Steps

### Data layer ConnectionString Configuration
#### Go to appSettings.json File in Data project and put your server in the corresponding variable
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/data-connectionString.jpg)

### Api ConnectionString Configuration
#### Go to appSettings.json File in Api project and put your server in the corresponding variable
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/api-connectionString.jpg)

### Go to Nuget Package Console
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/nuget-console-option.jpg)

##### Run migrations commands
```dotnet ef migrations add Init --project PmSystem.Infrastructure.Data```<br/>
##### Then Image Example:
```dotnet ef database update --project PmSystem.Infrastructure.Data```
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/nuget-command.jpg)

##### Config multiple projects:
###### Right clic into solutions file
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/right-clic.jpg)
###### Then set following configuration:
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/multiple-project-option.jpg)

##### Run the project
![alt text](https://github.com/saulocarrasco/PmSystem/blob/master/documentation/run-project.jpg)

[Technical Document]([path%20with%20spaces/other_file.md](https://docs.google.com/document/d/1fodMo5gKBYapf0DfvWENvwnOApN8D3UUSpwun1UPuME/edit?usp=sharing))

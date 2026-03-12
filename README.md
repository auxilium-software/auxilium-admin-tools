# auxilium-tools
A collection of tools for managing an instance of Auxilium.

```bash
$ git clone https://github.com/auxilium-software/auxilium-services-api.git
$ cd auxilium-services-api/AuxiliumTools
$ dotnet build
$ dotnet ef migrations add InitialCreate
$ dotnet ef database update
$ dotnet run -- create-admin
```

to reset a password:
```bash
$ dotnet run -- reset-password
```

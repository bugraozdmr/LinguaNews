<p align=center>
  <br>
  <span>LinguaNews getting migration and Applying it to database (you can also continue with the one named InitialCreate)</span>
  <br>
</p>

**Before all this actions make sure your docker up and running and don't forget to build the project and lastly run the docker compose**

### If you want to create new migration
* First locate to LinguaNews folder
```console
$ cd LinguaNews
```

* then run the commands
```console
## Creating new migration
$ dotnet ef migrations add CustomMigration -o Migrations -p LinguaNews.Infrastructure -s LinguaNews.Api

## Apply it to db
dotnet ef database update --startup-project ./LinguaNews.Api/
```

### If you want to use existing migration file
* just run the command
```console
dotnet ef database update --startup-project ./LinguaNews.Api/
```

#### Dont forget to run the app after getting migration apply to database. This will insert to data.
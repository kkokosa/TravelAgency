-----------------------------------------/
| Users                                 /
---------------------------------------/
test@test.pl / 1234

-----------------------------------------/
| Migrations                            /
---------------------------------------/

In Package Manager Console:

Enable-Migrations -ContextTypeName WebLearn1.Models.TripsOfferDbContext

Code First Migrations has two primary commands that you are going to become familiar with.

* Add-Migration <name> will scaffold the next migration based on changes you have made to your model since the last migration was created
* Update-Database will apply any pending migrations to the database
* Update-Database –TargetMigration: <name> may be used to downgrade
* Update-Database -Script -SourceMigration: $InitialDatabase -TargetMigration: AddPostAbstract - to produce SQL script for PRD 
	- "Starting with EF6, if you specify –SourceMigration $InitialDatabase then the generated script will be ‘idempotent’. Idempotent scripts can upgrade a database currently at any version to the latest version (or the specified version if you use –TargetMigration). The generated script includes logic to check the __MigrationsHistory table and only apply changes that haven't been previously applied."

Automatic migrations - You can intersperse automatic and code-based migrations but this is not recommended in team development scenarios. If you are part of a team of developers that use source control you should either use purely automatic migrations or purely code-based migrations. Given the limitations of automatic migrations we recommend using code-based migrations in team environments.

-----------------------------------------/
|Notes                                  /
---------------------------------------/

    <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-WebLearn1-20150403023301.mdf;Initial Catalog=aspnet-WebLearn1-20150403023301;Integrated Security=True" providerName="System.Data.SqlClient" />
    <add name="TripsOfferDbContext" connectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TripsOfferDb.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />

-----------------------------------------/
|Team City + Octopus                    /
---------------------------------------/

Tip: delayed package publishing
NuGet packages created from your build won't appear in the TeamCity NuGet feed until after the build fully completes. If you plan to trigger a deployment during a build, this creates a problem: the package won't be in the feed until the build is published, so you won't be able to deploy it.
The solution is to configure a secondary build configuration, and use a snapshot dependency and build trigger in TeamCity to run the deployment build configuration after the first build configuration completes. The video below demonstrates how to do this.
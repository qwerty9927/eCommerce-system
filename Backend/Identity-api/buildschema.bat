rmdir /S /Q Migrations

@REM dotnet ef database update 0 -c PersistedGrantDbContext
@REM dotnet ef database update 0 -c ConfigurationDbContext
@REM dotnet ef database update 0 -c ConfigurationDbContext

dotnet ef migrations remove -c PersistedGrantDbContext
dotnet ef migrations remove -c ConfigurationDbContext
dotnet ef migrations remove -c ApplicationDbContext

dotnet ef migrations add Grants -c PersistedGrantDbContext -o Migrations/PersistedGrantDb
dotnet ef migrations add Configuration -c ConfigurationDbContext -o Migrations/ConfigurationDb
dotnet ef migrations add Initial -c ApplicationDbContext -o Migrations

dotnet ef database update -c PersistedGrantDbContext
dotnet ef database update -c ConfigurationDbContext
dotnet ef database update -c ApplicationDbContext

@REM dotnet ef migrations script -c PersistedGrantDbContext -o Migrations/PersistedGrantDb.sql
@REM dotnet ef migrations script -c ConfigurationDbContext -o Migrations/ConfigurationDb.sql

dotnet run -- /seed
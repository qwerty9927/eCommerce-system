#!/bin/bash

rm -rf Migrations

dotnet ef migrations remove -c PersistedGrantDbContext
dotnet ef migrations remove -c ConfigurationDbContext
dotnet ef migrations remove -c ApplicationDbContext

dotnet ef migrations add Grants -c PersistedGrantDbContext -o Migrations/PersistedGrantDb
dotnet ef migrations add Configuration -c ConfigurationDbContext -o Migrations/ConfigurationDb
dotnet ef migrations add Initial -c ApplicationDbContext -o Migrations

dotnet ef database update -c PersistedGrantDbContext
dotnet ef database update -c ConfigurationDbContext
dotnet ef database update -c ApplicationDbContext

dotnet run -- /seed
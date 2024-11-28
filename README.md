# fashion-store

# Migration Commands

This section provides the commonly used Entity Framework Core (EF Core) commands for managing database migrations in the `Fashion` project.

## Adding a New Migration

To add a new migration, run the following command:

```bash
 dotnet ef migrations add <migration-name> \
 --project ./Fashion.Infrastructure/Fashion.Infrastructure.csproj \
 --startup-project ./Fashion.Presentation/Fashion.Presentation.csproj
```

Replace `<migration-name>` with a descriptive name for your migration.

Example:

```bash
 dotnet ef migrations add change-for-correct-db \
 --project ./Fashion.Infrastructure/Fashion.Infrastructure.csproj \
 --startup-project ./Fashion.Presentation/Fashion.Presentation.csproj
```

## Updating the Database

To apply the latest migrations to the database, run:

```bash
 dotnet ef database update \
 --project ./Fashion.Infrastructure/Fashion.Infrastructure.csproj \
 --startup-project ./Fashion.Presentation/Fashion.Presentation.csproj
```

## Removing the Last Migration

If you need to remove the last migration, use:

```bash
 dotnet ef migrations remove \
 --project ./Fashion.Infrastructure/Fashion.Infrastructure.csproj \
 --startup-project ./Fashion.Presentation/Fashion.Presentation.csproj
```

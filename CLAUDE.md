# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

.NET 7.0 FluentMigrator-based database migration system for the KODI/HEIDI municipal platform. Manages two tiers of MySQL databases: one core system database (`heidi_core`) and multiple per-city tenant databases (`heidi_city_*`).

## Build & Run Commands

All commands run from `DatabaseMigrations/` directory:

```bash
dotnet build                                                    # Build solution
dotnet run                                                      # Run all migrations up (default)
dotnet run dbType=core                                          # Core DB only
dotnet run dbType=city                                          # All city DBs only
dotnet run migrate=down dbType=core targetVersion=20250305143733 # Rollback core to version
```

Down migrations require both `dbType` (core or city, not all) and `targetVersion`.

## Architecture

- **DatabaseMigrations/** — Console app entry point. `Program.cs` parses CLI args, discovers city databases from `heidi_core.cities`, and runs FluentMigrator against each.
- **CoreDBMigrations/** — Migration classes for the core database (`heidi_core`): users, cities, roles, authentication, permissions, listings metadata.
- **CityDBMigrations/** — Migration classes for per-city tenant databases (`heidi_city_*`): villages, categories, listings, forums, appointments.

The runner dynamically loads the correct assembly (`CoreDBMigrations` or `CityDBMigrations`) via `Assembly.Load()` and uses a custom `versioninfo` table for tracking applied migrations.

## Writing Migrations

Each migration is a C# class in the appropriate `Migrations/` folder:

- **Filename format:** `YYYYMMDDHHmmss_DescriptiveName.cs`
- **Namespace:** `CoreDBMigrations.Migrations` or `CityDBMigrations.Migrations`
- **Pattern:** Inherit from `Migration`, apply `[Migration(timestamp)]` attribute, implement `Up()` and `Down()` using `Execute.Sql()` with raw MySQL SQL strings.
- **Timestamps must be unique** — they serve as the migration version number.

Place core-system changes (users, cities, roles, global config) in `CoreDBMigrations/Migrations/`. Place per-city tenant changes (listings content, local categories, forums) in `CityDBMigrations/Migrations/`.

## Local Setup

Requires MySQL 8.0 and .NET 7.0 SDK. Create schemas `heidi_core` and `heidi_city_0`, then create an `App.config` file in `DatabaseMigrations/` with connection strings (see README.md). This file is git-ignored as it contains credentials.

## Deployment

GitHub Actions workflows deploy via SSH. `release.yml` deploys to 14 production city servers on release publish. `stag-release.yaml` deploys to staging on push to `develop`.

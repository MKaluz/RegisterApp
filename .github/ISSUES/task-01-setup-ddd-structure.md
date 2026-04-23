---
title: "Task 1: Setup DDD Project Structure"
labels: ["DDD-transition", "Phase-1", "priority-high", "architecture"]
---

**Priority**: High  
**Estimated Effort**: 2-4 hours  
**Dependencies**: None

## Description
Create the foundational project structure following DDD principles with proper separation of concerns across Domain, Application, Infrastructure, and Presentation layers.

## Acceptance Criteria
- [ ] New solution structure with 4 class library projects created:
  - `RegisterApp.Domain` (netstandard2.1 or net6.0)
  - `RegisterApp.Application` (netstandard2.1 or net6.0)
  - `RegisterApp.Infrastructure` (netstandard2.1 or net6.0)
  - `RegisterApp.Api` (aspnetcore project)
- [ ] Project dependencies properly configured:
  - Domain: No external dependencies (except framework)
  - Application: References Domain only
  - Infrastructure: References Domain and Application
  - Api: References Application and Infrastructure
- [ ] Folder structure created in Domain project:
  - `UserManagement/` bounded context
  - `VisitScheduling/` bounded context
  - `Common/` for shared kernel
- [ ] Each bounded context has subfolders: Aggregates, ValueObjects, DomainEvents, DomainServices, Repositories
- [ ] README.md updated with new architecture explanation

## What's Needed
- Visual Studio or .NET CLI to create projects
- Understanding of .NET project types and dependencies
- Knowledge of DDD folder structure conventions

## Implementation Notes
```bash
# Commands to create structure
dotnet new sln -n RegisterApp
dotnet new classlib -n RegisterApp.Domain
dotnet new classlib -n RegisterApp.Application
dotnet new classlib -n RegisterApp.Infrastructure
dotnet new webapi -n RegisterApp.Api
dotnet sln add **/*.csproj
```

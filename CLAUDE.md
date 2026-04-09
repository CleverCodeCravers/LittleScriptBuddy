# CLAUDE.md

## Projektbeschreibung

LittleScriptBuddy ueberwacht Dateiaenderungen in C#-Dateien und fuehrt automatisch Skripte aus. Spezielle Kommentare im Code (`//lsb: script.ps1 "param"`) werden erkannt, das referenzierte PowerShell-Skript ausgefuehrt und die Ausgabe direkt in die Datei eingefuegt.

## TechStack

- .NET 10.0 (C#)
- NUnit (Tests)
- PowerShell (Skript-Ausfuehrung)

## Build und Test

```bash
# Build
dotnet build Source/LittleScriptBuddy

# Tests ausfuehren
dotnet test Source/LittleScriptBuddy

# Release-Build
dotnet build Source/LittleScriptBuddy --configuration Release
```

## Projektstruktur

- `Source/LittleScriptBuddy/CommandLineArguments/` - Kommandozeilen-Parser
- `Source/LittleScriptBuddy/LittleScriptBuddy.Console/` - Konsolenanwendung (Einstiegspunkt)
- `Source/LittleScriptBuddy/LittleScriptBuddy.Domain/` - Domaenenlogik
- `Source/LittleScriptBuddy/LittleScriptBuddy.Domain.Tests/` - Unit-Tests
- `Source/LittleScriptBuddy/LittleScriptBuddy.Persistence/` - Persistenzschicht

## Konventionen

- TreatWarningsAsErrors ist in allen Projekten aktiviert
- Nullable Reference Types sind aktiviert
- ImplicitUsings sind aktiviert
- Commit-Messages: `[ANFORDERUNGS_ID] <beschreibung>` oder konventionelle Beschreibung
- Anforderungen liegen unter `Anforderungen/`

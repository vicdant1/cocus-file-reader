# COCUS File Reader

A simple file reading library built incrementally, one user story per version (see the Git tags).

## Requirements

- .NET 10 SDK

## Build and test

```bash
dotnet build
dotnet test
```

## Run the CLI

```bash
dotnet run --project src/Cocus.FileReader.Cli
```

Sample files are available in the `samples` folder.

## Versions

| Tag | User story |
|-----|------------|
| v1  | A user should be able to read a text file |
| v2  | A user should be able to read an XML file |

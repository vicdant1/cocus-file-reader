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

## Encryption

Every `IEncryption` implementation in the library is discovered through reflection and listed by the CLI when reading an encrypted file. Adding a new algorithm only requires a new class; no existing code changes.

## Versions

| Tag | User story |
|-----|------------|
| v1  | A user should be able to read a text file |
| v2  | A user should be able to read an XML file |
| v3  | A user should be able to read an encrypted TEXT file |

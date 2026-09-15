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

## Extensibility

Every `IEncryption` and `IAccessPolicy` implementation in the library is discovered through reflection and listed by the CLI. Adding a new encryption algorithm or a real role based security system only requires a new class; no existing code changes.

## Role based security

`SimpleAccessPolicy` lets the `admin` role read every file, while other roles can only read files inside a `public` directory (e.g. `samples/public/heteronyms.xml`).

## Versions

| Tag | User story |
|-----|------------|
| v1  | A user should be able to read a text file |
| v2  | A user should be able to read an XML file |
| v3  | A user should be able to read an encrypted TEXT file |
| v4  | A user should be able to read XML files in role based security context |
| v5  | A user should be able to read an encrypted XML file |
| v6  | A user should be able to read TEXT files in role based security context |
| v7  | A user should be able to read JSON files |
| v8  | A user should be able to read encrypted JSON files |

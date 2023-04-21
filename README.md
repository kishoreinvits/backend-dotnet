# backend-dotnet
- [backend-dotnet](#backend-dotnet)
  - [Introduction](#introduction)
  - [Structure](#structure)
  - [Local development](#local-development)
  - [Build pipelines](#build-pipelines)

## Introduction

A backend project demonstrating capabilities of ASP.NET.

## Structure

The repo contains applications and respective UnitTests and ComponentTests:

- WebApi
  - WebApi.csproj
- WebApi.UnitTests
  - WebApi.UnitTests.csproj
- WebApi.ComponentTests
  - WebApi.ComponentTests.csproj

## Local development

This project uses standard dotnet projects.

```bash
# Restore nuget packages
dotnet restore
# build
dotnet build
# test
dotnet test
```

## Build pipelines

This project uses GitHub actions. Related configuration can be found in `.github\workflows` folder

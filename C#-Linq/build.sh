#!/usr/bin/env bash
cd dotnet restore && dotnet build -c Release
cd ParallelTest.UnitTests && dotnet restore && dotnet test -c Release

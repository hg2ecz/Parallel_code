#!/usr/bin/env bash
cd C#-Linq && dotnet restore && dotnet build -c Release
cd C# -Linq/ParallelTest.UnitTests && dotnet restore && dotnet test -c Release

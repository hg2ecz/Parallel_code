#!/usr/bin/env bash
cd C#-Linq && dotnet restore && dotnet build -c Release && dotnet test -c Release

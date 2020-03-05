@echo off
dotnet ef migrations add %1 --project ../Monies.Database/Monies.Database.csproj
#!/bin/bash
echo "*nix version"
dotnet ef migrations add $1 --project ../Monies.Database/Monies.Database.csproj
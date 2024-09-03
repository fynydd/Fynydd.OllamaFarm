if (Test-Path ".\Fynydd.OllamaFarm\nupkg") { Remove-Item ".\Fynydd.OllamaFarm\nupkg" -Recurse -Force }
. ./clean.ps1
Set-Location Fynydd.OllamaFarm
dotnet pack --configuration Release
Set-Location ..

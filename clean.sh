# Delete all build files and restore dependencies from nuget servers
# ------------------------------------------------------------------

rm -r Fynydd.OllamaFarm/bin
rm -r Fynydd.OllamaFarm/obj

dotnet restore Fynydd.OllamaFarm/Fynydd.OllamaFarm.csproj

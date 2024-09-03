rm -r Fynydd.OllamaFarm/nupkg
source clean.sh
cd Fynydd.OllamaFarm
dotnet pack --configuration Release
cd ..

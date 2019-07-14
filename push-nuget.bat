dotnet pack -c Release --include-symbols
cd bin\Release
dotnet nuget push -s https://api.nuget.org/v3/index.json *.symbols.nupkg
del *.symbols.nupkg
dotnet nuget push -s https://api.nuget.org/v3/index.json *.nupkg
del *.nupkg
cd ..
cd ..
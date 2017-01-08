cd ruge.lib
dotnet restore
dotnet build
cd ..\ruge.test
dotnet restore
dotnet build
dotnet test
cd ..
cd ..\FirstGame
dotnet restore
dotnet build
dotnet test


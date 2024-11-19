cd Lab3.Solving
dotnet pack -o ..\Repository -p:PackageId=VSemenchenko
rmdir bin /s /q
rmdir obj /s /q
cd ..\Lab3.Application
dotnet new nugetconfig
dotnet nuget add source ..\Repository
dotnet add package VSemenchenko
dotnet build

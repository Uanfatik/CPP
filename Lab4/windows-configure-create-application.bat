cd %USERPROFILE%\Desktop
mkdir Lab4
cd Lab4
dotnet new tool-manifest
dotnet tool install VSemenchenko --add-source http://10.0.2.2:5000/v3/index.json

cd %USERPROFILE%\Downloads
curl https://download.visualstudio.microsoft.com/download/pr/ba3a1364-27d8-472e-a33b-5ce0937728aa/6f9495e5a587406c85af6f93b1c89295/dotnet-sdk-8.0.404-win-x64.exe -o dotnet-installer.exe -L
dotnet-installer.exe /quiet /norestart
del dotnet-installer.exe

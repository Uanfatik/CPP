cd ~/Downloads
curl https://download.visualstudio.microsoft.com/download/pr/656d1b6e-cd8e-4767-bc91-e4cb6cd21cef/36f5b3664238acf0a030fc81efd4410c/dotnet-sdk-8.0.404-osx-x64.pkg -o dotnet-installer.pkg -L
sudo installer -pkg dotnet-installer.pkg -target /
rm dotnet-installer.pkg
source /etc/profile

cd ~/Desktop
mkdir Lab4
cd Lab4
dotnet new tool-manifest
dotnet tool install VSemenchenko --add-source http://10.0.2.2:5000/v3/index.json

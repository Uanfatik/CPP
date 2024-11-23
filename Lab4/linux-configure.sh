cd /usr/local/bin
sudo wget https://download.visualstudio.microsoft.com/download/pr/4e3b04aa-c015-4e06-a42e-05f9f3c54ed2/74d1bb68e330eea13ecfc47f7cf9aeb7/dotnet-sdk-8.0.404-linux-x64.tar.gz -O dotnet.tar.gz
sudo mkdir dotnet
sudo tar zxf dotnet.tar.gz -C dotnet
sudo rm dotnet.tar.gz
cd ~
cat > .bashrc << EOL
export DOTNET_ROOT=/usr/local/bin/dotnet
export PATH=\$PATH:/usr/local/bin/dotnet
EOL
source .bashrc

mkdir Lab4
cd Lab4
dotnet new tool-manifest
dotnet tool install VSemenchenko --add-source http://10.0.2.2:5000/v3/index.json

Remove-Item -Recurse -Force dist
dotnet publish ./WebApi/WebApi.csproj -c Release -o dist
docker build -t webapi:locallatest .
docker run -d -p 80:80 webapi:locallatest
# UFRCards

Start container:

docker run --name UFRCards -e POSTGRES_PASSWORD=secret -e POSTGRES_USER=root -d -p 5432:5432 postgres:latest

cd UFRCards.API

dotnet build
dotnet run

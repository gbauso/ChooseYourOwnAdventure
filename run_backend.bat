docker start neo4j || docker run -d --name neo4j -p 7687:7687 -p 7474:7474 -e NEO4J_AUTH=neo4j/Secr3t -v %cd%/docker/neo4j/data/:/data -v %cd%/docker/neo4j/plugins/:/plugins neo4j:3.5.14
dotnet restore
dotnet test
dotnet run --project .\backend\src\ChooseYourOwnAdventure.API\ChooseYourOwnAdventure.API.csproj
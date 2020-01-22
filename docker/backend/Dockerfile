FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["././backend/src/ChooseYourOwnAdventure.API/ChooseYourOwnAdventure.API.csproj", "backend/src/ChooseYourOwnAdventure.API/"]
COPY ["././backend/src/ChooseYourOwnAdventure.Application/ChooseYourOwnAdventure.Application.csproj", "backend/src/ChooseYourOwnAdventure.Application/"]
COPY ["././backend/src/ChooseYourOwnAdventure.Infrastructure/ChooseYourOwnAdventure.Infrastructure.csproj", "backend/src/ChooseYourOwnAdventure.Infrastructure/"]
COPY ["././backend/src/ChooseYourOwnAdventure.Domain/ChooseYourOwnAdventure.Domain.csproj", "backend/src/ChooseYourOwnAdventure.Domain/"]
COPY ["././backend/src/ChooseYourOwnAdventure.CrossCutting/ChooseYourOwnAdventure.CrossCutting.csproj", "backend/src/ChooseYourOwnAdventure.CrossCutting/"]

RUN dotnet restore "backend/src/ChooseYourOwnAdventure.API/ChooseYourOwnAdventure.API.csproj"
COPY . .
WORKDIR "/src/backend/src/ChooseYourOwnAdventure.API"
RUN dotnet build "ChooseYourOwnAdventure.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChooseYourOwnAdventure.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChooseYourOwnAdventure.API.dll"]
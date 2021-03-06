FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectExchange.API/Services/User/API/API.csproj", "ProjectExchange.API/Services/User/API/"]
COPY ["ProjectExchange.API/Services/User/Application/Application.csproj", "ProjectExchange.API/Services/User/Application/"]
COPY ["ProjectExchange.API/Services/User/Domain/Domain.csproj", "ProjectExchange.API/Services/User/Domain/"]
COPY ["ProjectExchange.API/Services/User/Infrastructure/Infrastructure.csproj", "ProjectExchange.API/Services/User/Infrastructure/"]
RUN dotnet restore "ProjectExchange.API/Services/User/API/API.csproj"
COPY . .
WORKDIR "/src/ProjectExchange.API/Services/User/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

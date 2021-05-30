FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectExchange.API/Services/Product/API/API.csproj", "ProjectExchange.API/Services/Product/API/"]
COPY ["ProjectExchange.API/Services/Product/Application/Application.csproj", "ProjectExchange.API/Services/Product/Application/"]
COPY ["ProjectExchange.API/Services/Product/Domain/Domain.csproj", "ProjectExchange.API/Services/Product/Domain/"]
COPY ["ProjectExchange.API/Services/Product/Infrastructure/Infrastructure.csproj", "ProjectExchange.API/Services/Product/Infrastructure/"]
RUN dotnet restore "ProjectExchange.API/Services/Product/API/API.csproj"
COPY . .
WORKDIR "/src/ProjectExchange.API/Services/Product/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5010

ENV ASPNETCORE_URLS=http://+:5010

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectExchange.API/ApiGateways/ExchangeGateway/ExchangeGateway.csproj", "ProjectExchange.API/ApiGateways/ExchangeGateway/"]
RUN dotnet restore "ProjectExchange.API/ApiGateways/ExchangeGateway/ExchangeGateway.csproj"
COPY . .
WORKDIR "/src/ProjectExchange.API/ApiGateways/ExchangeGateway"
RUN dotnet build "ExchangeGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExchangeGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExchangeGateway.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY Output/ .
ENTRYPOINT ["dotnet", "PortfolioFrontend.dll"]

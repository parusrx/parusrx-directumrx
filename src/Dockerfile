#Copyright (c) Parusnik. All rights reserved.
#Licensed under the MIT License. See LICENSE in the project root for license information.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sdk/EventBus/ParusRx.Sdk.EventBus/ParusRx.Sdk.EventBus.csproj", "Sdk/EventBus/ParusRx.Sdk.EventBus/"]
COPY ["Sdk/Stores/ParusRx.Sdk.Stores.Abstractions/ParusRx.Sdk.Stores.Abstractions.csproj", "Sdk/Stores/ParusRx.Sdk.Stores.Abstractions/"]
COPY ["Sdk/Stores/ParusRx.Sdk.Stores.Oracle/ParusRx.Sdk.Stores.Oracle.csproj", "Sdk/Stores/ParusRx.Sdk.Stores.Oracle/"]
COPY ["Sdk/Stores/ParusRx.Sdk.Stores.Postgres/ParusRx.Sdk.Stores.Postgres.csproj", "Sdk/Stores/ParusRx.Sdk.Stores.Postgres/"]
COPY ["Sdk/Xml/ParusRx.Sdk.Xml/ParusRx.Sdk.Xml.csproj", "Sdk/Xml/ParusRx.Sdk.Xml/"]
COPY ["Services/DirectumRx/DirectumRx.Api/DirectumRx.Api.csproj", "Services/DirectumRx/DirectumRx.Api/"]
RUN dotnet restore "Services/DirectumRx/DirectumRx.Api/DirectumRx.Api.csproj"
COPY . .
WORKDIR "/src/Services/DirectumRx/DirectumRx.Api"
RUN dotnet build "DirectumRx.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DirectumRx.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DirectumRx.Api.dll"]
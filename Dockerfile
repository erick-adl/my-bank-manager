FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

# ENV mongoConnection__server "mongodb://mongo:27017/bankflix"
# ENV rabbitmq__uri "amqp://guest:guest@rabbitmq:5672/rabbitmq-bankflix"

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY * ./

WORKDIR /src/MyBankManager.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyBankManager.Api.dll"]


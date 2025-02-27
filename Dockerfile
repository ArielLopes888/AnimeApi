
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build


WORKDIR /app


COPY . .


RUN dotnet restore


RUN dotnet build -c Release -o /app/build


RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .


ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "API.dll"]

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

COPY ApiJuros.Calculos.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ApiJuros.Calculos.dll"]
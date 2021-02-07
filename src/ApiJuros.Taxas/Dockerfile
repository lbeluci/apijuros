FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

COPY ApiJuros.Taxas ./
RUN dotnet restore ApiJuros.Taxas.csproj

COPY . ./
RUN dotnet publish ApiJuros.Taxas -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ApiJuros.Taxas.dll"]
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

COPY ApiJuros.Calculos.Dominio ./
RUN dotnet restore ApiJuros.Calculos.Dominio.csproj

COPY ApiJuros.Calculos ./
RUN dotnet restore ApiJuros.Calculos.csproj

COPY . ./
RUN dotnet publish ApiJuros.Calculos -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ApiJuros.Calculos.dll"]
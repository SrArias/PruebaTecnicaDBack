# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.sln .
COPY PruebaTecnicaDBack/*.csproj ./PruebaTecnicaDBack/
RUN dotnet restore

# Copiar el resto de los archivos y compilar la aplicación
COPY PruebaTecnicaDBack/. ./PruebaTecnicaDBack/
WORKDIR /app/PruebaTecnicaDBack
RUN dotnet publish -c Release -o out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/PruebaTecnicaDBack/out ./
CMD ["dotnet", "PruebaTecnicaDBack.dll"]
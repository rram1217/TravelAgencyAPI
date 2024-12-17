# Etapa 1: Compilación del proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0.100 AS build
WORKDIR /app

# Copiar los archivos del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todos los archivos y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Ejecución de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos compilados desde la etapa anterior
COPY --from=build /app/out ./

# Exponer el puerto en el que correrá tu API
EXPOSE 8080

# Comando para ejecutar tu aplicación
ENTRYPOINT ["dotnet", "TravelAgencyAPI.dll"]

# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia tudo
COPY . ./

# Restaura pacotes e compila
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Starta o projeto
ENTRYPOINT ["dotnet", "AmbienteEscolarCursoVideo.dll"]
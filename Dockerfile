# Usando a imagem oficial do .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiando os arquivos do projeto e restaurando as dependências
COPY . ./
RUN dotnet restore

# Construindo o projeto em Release
RUN dotnet publish -c Release -o out

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expondo a porta padrão da aplicação
EXPOSE 80

# Comando de inicialização
ENTRYPOINT ["dotnet", "ManagerAPI.dll"]

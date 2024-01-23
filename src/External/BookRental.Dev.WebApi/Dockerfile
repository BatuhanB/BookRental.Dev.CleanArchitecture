FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/External/BookRental.Dev.WebApi/BookRental.Dev.WebApi.csproj", "src/External/BookRental.Dev.WebApi/"]
COPY ["src/Core/BookRental.Dev.Application/BookRental.Dev.Application.csproj", "src/Core/BookRental.Dev.Application/"]
COPY ["src/Core/BookRental.Dev.Domain/BookRental.Dev.Domain.csproj", "src/Core/BookRental.Dev.Domain/"]
COPY ["src/External/BookRental.Dev.Infrastructure/BookRental.Dev.Infrastructure.csproj", "src/External/BookRental.Dev.Infrastructure/"]
RUN dotnet restore "src/External/BookRental.Dev.WebApi/BookRental.Dev.WebApi.csproj"
COPY . .
WORKDIR "/src/src/External/BookRental.Dev.WebApi"
RUN dotnet build "BookRental.Dev.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookRental.Dev.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookRental.Dev.WebApi.dll"]
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./src/Core/BookRental.Dev.Application/*.csproj ./src/Core/BookRental.Dev.Application/
COPY ./src/Core/BookRental.Dev.Domain/*.csproj ./src/Core/BookRental.Dev.Domain/
COPY ./src/External/BookRental.Dev.Infrastructure/*.csproj ./src/External/BookRental.Dev.Infrastructure/
COPY ./src/External/BookRental.Dev.WebApi/*.csproj ./src/External/BookRental.Dev.WebApi/
COPY *.sln ./
RUN dotnet restore

COPY . ./
RUN dotnet publish ./src/External/BookRental.Dev.WebApi/*.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BookRental.Dev.WebApi.dll"]
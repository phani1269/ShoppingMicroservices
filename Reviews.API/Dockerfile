#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Reviews.API/Reviews.API.csproj", "Reviews.API/"]
RUN dotnet restore "Reviews.API/Reviews.API.csproj"
COPY . .
WORKDIR "/src/Reviews.API"
RUN dotnet build "Reviews.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reviews.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reviews.API.dll"]

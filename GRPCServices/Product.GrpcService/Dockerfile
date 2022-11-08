#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GRPCServices/Product.GrpcService/Product.GrpcService.csproj", "GRPCServices/Product.GrpcService/"]
RUN dotnet restore "GRPCServices/Product.GrpcService/Product.GrpcService.csproj"
COPY . .
WORKDIR "/src/GRPCServices/Product.GrpcService"
RUN dotnet build "Product.GrpcService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.GrpcService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.GrpcService.dll"]

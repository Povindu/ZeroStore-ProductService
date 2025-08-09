# See https://aka.ms/customizecontainer to learn how to customize your debug container

# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only project file first for dependency caching
COPY ./ProductService.csproj ./

# Restore dependencies — this layer is cached unless csproj changes
RUN dotnet restore "./ProductService.csproj"

# Copy the rest of the source files
COPY . .

# Build
RUN dotnet build "./ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage (only necessary files)
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image (smallest possible)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ProductService.db . 
ENTRYPOINT ["dotnet", "ProductService.dll"]


# Use official image for .NET 8 SDK as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build the app using .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY ["WebApplication5.csproj", "."]
RUN dotnet restore "WebApplication5.csproj"

# Copy the rest of the application files
COPY . .
WORKDIR "/src"
RUN dotnet build "WebApplication5.csproj" -c Release -o /app/build


COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh




# Publish the app
FROM build AS publish
RUN dotnet publish "WebApplication5.csproj" -c Release -o /app/publish

# Final image for running the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication5.dll"]

# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution and project files
COPY Ecom.sln ./
COPY Ecom.API/Ecom.API.csproj Ecom.API/
COPY Ecom.Application/Ecom.Application.csproj Ecom.Application/
COPY Ecom.Domain/Ecom.Domain.csproj Ecom.Domain/
COPY Ecom.Infrastructure/Ecom.Infrastructure.csproj Ecom.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build the application
RUN dotnet publish Ecom.API/Ecom.API.csproj -c Release -o /out

# Use the official .NET runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /out ./

# Expose the port the application runs on
# EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Ecom.API.dll"]

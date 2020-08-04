FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /WebApp/src

# RUN dotnet tool install --global dotnet-sonarscanner

# copy just csproj/sln files
COPY Project1.Data/*.csproj Project1.Data/
COPY Project1.Domain/*.csproj Project1.Domain/
COPY Project1.Test/*.csproj Project1.Test/
COPY Project1.WebApp/*.csproj Project1.WebApp/
COPY *.sln ./
RUN dotnet restore

# copy rest of build context into /app/src
COPY . ./

# RUN dotnet sonarscanner begin ...

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS test

# RUN dotnet build

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS analyze

# COPY

# RUN dotnet test

# RUN dotnet sonarscanner end

# publish to /app/publish
RUN dotnet publish Project1.WebApp -o ../publish --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

# copy assemblies from build stage into this stage
COPY --from=build /app/publish ./

CMD dotnet Project1.WebApp.dll
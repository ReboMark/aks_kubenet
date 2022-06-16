FROM mcr.microsoft.com/dotnet/sdk AS build-env
WORKDIR /app
EXPOSE 80

ARG ServiceName
ENV Service=$ServiceName
ENV Entry="${Service}.api.dll"

# Copy csproj files, sln, and restore as distinct layers
COPY ./$Service/ ./$Service/

# RUN dotnet restore ./$Service/Moonlight.$Service.api/Moonlight.$Service.api.csproj
RUN dotnet publish ./$Service/$Service.api -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN apt-get update
RUN apt-get install tzdata -y
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", $Entry]
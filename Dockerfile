# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY Simbirsoft.Hakaton.ProjectD.Api/*.csproj .
RUN dotnet restore --use-current-runtime  

# copy everything else and build app
COPY Simbirsoft.Hakaton.ProjectD.Api/. .
RUN dotnet publish --use-current-runtime --self-contained false --no-restore -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-preview
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./Simbirsoft.Hakaton.ProjectD.Api"]

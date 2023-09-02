# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY Presentation/Simbirsoft.Hakaton.ProjectD.Api/Simbirsoft.Hakaton.ProjectD.Api.csproj Presentation/Simbirsoft.Hakaton.ProjectD.Api/
COPY Infrastructure/Simbirsoft.Hakaton.ProjectD.Persistence/Simbirsoft.Hakaton.ProjectD.Persistence.csproj Infrastructure/Simbirsoft.Hakaton.ProjectD.Persistence/
COPY Core/Simbirsoft.Hakaton.ProjectD.Application/Simbirsoft.Hakaton.ProjectD.Application.csproj Core/Simbirsoft.Hakaton.ProjectD.Application/
COPY Core/Simbirsoft.Hakaton.ProjectD.Domain/Simbirsoft.Hakaton.ProjectD.Domain.csproj Core/Simbirsoft.Hakaton.ProjectD.Domain/
COPY Core/Simbirsoft.Hakaton.ProjectD.Shared/Simbirsoft.Hakaton.ProjectD.Shared.csproj Core/Simbirsoft.Hakaton.ProjectD.Shared/

RUN dotnet restore Presentation/Simbirsoft.Hakaton.ProjectD.Api/Simbirsoft.Hakaton.ProjectD.Api.csproj --use-current-runtime

# copy everything else and build app
COPY . .

RUN dotnet publish "Presentation/Simbirsoft.Hakaton.ProjectD.Api/Simbirsoft.Hakaton.ProjectD.Api.csproj" -c Release --use-current-runtime --self-contained false --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-preview
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./Simbirsoft.Hakaton.ProjectD.Api"]

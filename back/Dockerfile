# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview AS build
WORKDIR /source

# copy csproj and restore as distinct layers

COPY back/Presentation/Simbirsoft.Hakaton.ProjectD.Api/Simbirsoft.Hakaton.ProjectD.Api.csproj back/Presentation/Simbirsoft.Hakaton.ProjectD.Api/
COPY back/Infrastructure/Simbirsoft.Hakaton.ProjectD.Persistence/Simbirsoft.Hakaton.ProjectD.Persistence.csproj back/Infrastructure/Simbirsoft.Hakaton.ProjectD.Persistence/
COPY back/Core/Simbirsoft.Hakaton.ProjectD.Application/Simbirsoft.Hakaton.ProjectD.Application.csproj back/Core/Simbirsoft.Hakaton.ProjectD.Application/
COPY back/Core/Simbirsoft.Hakaton.ProjectD.Domain/Simbirsoft.Hakaton.ProjectD.Domain.csproj back/Core/Simbirsoft.Hakaton.ProjectD.Domain/
COPY back/Core/Simbirsoft.Hakaton.ProjectD.Shared/Simbirsoft.Hakaton.ProjectD.Shared.csproj back/Core/Simbirsoft.Hakaton.ProjectD.Shared/
COPY back/Core/Simbirsoft.Hakaton.ProjectD.Simulator/Simbirsoft.Hakaton.ProjectD.Simulator.csproj back/Core/Simbirsoft.Hakaton.ProjectD.Simulator/

RUN dotnet restore back/Presentation/Simbirsoft.Hakaton.ProjectD.Api/Simbirsoft.Hakaton.ProjectD.Api.csproj --use-current-runtime

# copy everything else and build app
COPY . .

RUN dotnet publish "back/Presentation/Simbirsoft.Hakaton.ProjectD.Api/Simbirsoft.Hakaton.ProjectD.Api.csproj" -c Release --use-current-runtime --self-contained false --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-preview
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./Simbirsoft.Hakaton.ProjectD.Api"]

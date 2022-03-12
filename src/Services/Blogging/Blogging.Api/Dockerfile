FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY "Blogify.sln" "Blogify.sln"

COPY "src/Services/Blogging/Blogging.Api/Blogging.Api.csproj" "src/Services/Blogging/Blogging.Api/Blogging.Api.csproj"
COPY "src/Services/Blogging/Blogging.Domain/Blogging.Domain.csproj" "src/Services/Blogging/Blogging.Domain/Blogging.Domain.csproj"
COPY "src/Services/Blogging/Blogging.GraphQL/Blogging.GraphQL.csproj" "src/Services/Blogging/Blogging.GraphQL/Blogging.GraphQL.csproj"
COPY "src/Services/Blogging/Blogging.Infrastructure/Blogging.Infrastructure.csproj" "src/Services/Blogging/Blogging.Infrastructure/Blogging.Infrastructure.csproj"
COPY "src/Services/Identity/Identity.Api/Identity.Api.csproj" "src/Services/Identity/Identity.Api/Identity.Api.csproj"
COPY "src/Services/Identity/Identity.Domain/Identity.Domain.csproj" "src/Services/Identity/Identity.Domain/Identity.Domain.csproj"
COPY "src/Services/Identity/Identity.Infrastructure/Identity.Infrastructure.csproj" "src/Services/Identity/Identity.Infrastructure/Identity.Infrastructure.csproj"

RUN dotnet restore "Blogify.sln"

COPY . .
WORKDIR /src/Services/Blogging/Blogging.Api
RUN dotnet build && dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Blogging.Api.dll"]

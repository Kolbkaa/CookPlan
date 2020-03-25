FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY ["PlanFood.Mvc.csproj", "./"]
RUN dotnet restore "./PlanFood.Mvc.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "PlanFood.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlanFood.Mvc.csproj" -c Release -o /app/publish


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PlanFood.Mvc.dll"]
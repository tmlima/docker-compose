#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MessageAPI/MessageAPI.csproj", "MessageAPI/"]
RUN dotnet restore "MessageAPI/MessageAPI.csproj"
COPY . .
WORKDIR "/src/MessageAPI"
RUN dotnet build "MessageAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessageAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessageAPI.dll"]
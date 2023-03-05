FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["InfinityChat/InfinityChat.csproj", "InfinityChat/"]
RUN dotnet restore "InfinityChat/InfinityChat.csproj"
COPY . .
WORKDIR "/src/InfinityChat"
RUN dotnet build "InfinityChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfinityChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfinityChat.dll"]

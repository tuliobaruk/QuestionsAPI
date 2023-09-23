FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PBIC_CloudNative.csproj", "./"]
RUN dotnet restore "PBIC_CloudNative.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PBIC_CloudNative.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PBIC_CloudNative.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PBIC_CloudNative.dll"]

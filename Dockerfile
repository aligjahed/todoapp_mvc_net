FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["todoapp_mvc_net/todoapp_mvc_net.csproj", "todoapp_mvc_net/"]
RUN dotnet restore "todoapp_mvc_net/todoapp_mvc_net.csproj"
COPY . .
WORKDIR "/src/todoapp_mvc_net"
RUN dotnet tool install --global dotnet-ef
RUN dotnet ef database update 
RUN dotnet build "todoapp_mvc_net.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "todoapp_mvc_net.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "todoapp_mvc_net.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["email_sendler/email_sendler.csproj", "email_sendler/"]
RUN dotnet restore "email_sendler/email_sendler.csproj"
COPY . .
WORKDIR "/src/email_sendler"
RUN dotnet build "email_sendler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "email_sendler.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "email_sendler.dll"]

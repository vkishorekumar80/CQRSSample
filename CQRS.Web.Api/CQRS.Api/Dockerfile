FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CQRS.Web.Api/CQRS.Api/CQRS.Api.csproj", "CQRS.Web.Api/CQRS.Api/"]
RUN dotnet restore "CQRS.Web.Api/CQRS.Api/CQRS.Api.csproj"
COPY . .
WORKDIR "/src/CQRS.Web.Api/CQRS.Api"
RUN dotnet build "CQRS.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CQRS.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CQRS.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API_SCHOOL/API_SCHOOL.csproj", "API_SCHOOL/"]
COPY ["API_SCHOOL.Application/API_SCHOOL.Application.csproj", "API_SCHOOL.Application/"]
COPY ["API_SCHOOL.Domain/API_SCHOOL.Domain.csproj", "API_SCHOOL.Domain/"]
COPY ["API_SCHOOL.Models/API_SCHOOL.Models.csproj", "API_SCHOOL.Models/"]
RUN dotnet restore "API_SCHOOL/API_SCHOOL.csproj"
COPY . .
WORKDIR "/src/API_SCHOOL"
RUN dotnet build "API_SCHOOL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_SCHOOL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_SCHOOL.dll"]
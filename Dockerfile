#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web/TravelBooking.Web/TravelBooking.Web.csproj", "Web/TravelBooking.Web/"]
COPY ["TravelBooking.Common/TravelBooking.Common.csproj", "TravelBooking.Common/"]
COPY ["Data/TravelBooking.Data/TravelBooking.Data.csproj", "Data/TravelBooking.Data/"]
COPY ["Data/TravelBooking.Data.Models/TravelBooking.Data.Models.csproj", "Data/TravelBooking.Data.Models/"]
COPY ["Data/TravelBooking.Data.Common/TravelBooking.Data.Common.csproj", "Data/TravelBooking.Data.Common/"]
COPY ["Web/TravelBooking.Web.ViewModels/TravelBooking.Web.ViewModels.csproj", "Web/TravelBooking.Web.ViewModels/"]
COPY ["Services/TravelBooking.Services.Mapping/TravelBooking.Services.Mapping.csproj", "Services/TravelBooking.Services.Mapping/"]
COPY ["Services/TravelBooking.Services.Data/TravelBooking.Services.Data.csproj", "Services/TravelBooking.Services.Data/"]
COPY ["Services/TravelBooking.Services/TravelBooking.Services.csproj", "Services/TravelBooking.Services/"]
COPY ["Services/TravelBooking.Services.Messaging/TravelBooking.Services.Messaging.csproj", "Services/TravelBooking.Services.Messaging/"]
COPY ["Web/TravelBooking.Web.Infrastructure/TravelBooking.Web.Infrastructure.csproj", "Web/TravelBooking.Web.Infrastructure/"]
RUN dotnet restore "Web/TravelBooking.Web/TravelBooking.Web.csproj"
COPY . .
WORKDIR "/src/Web/TravelBooking.Web"
RUN dotnet build "TravelBooking.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelBooking.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelBooking.Web.dll"]
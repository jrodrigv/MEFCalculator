FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MEFCalculator/MEFCalculator.csproj", "MEFCalculator/"]
COPY ["Calculator.Core/Calculator.Core.csproj", "Calculator.Core/"]
COPY ["Operation.Sum/Operation.Sum.csproj", "Operation.Sum/"]
RUN dotnet restore "MEFCalculator/MEFCalculator.csproj"
COPY . .
WORKDIR "/src/MEFCalculator"
RUN dotnet build "MEFCalculator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MEFCalculator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MEFCalculator.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app
COPY Synel.sln .
COPY Synel.Web/*.csproj Synel.Web/
COPY Synel.Tests/*.csproj Synel.Tests/
RUN dotnet restore

COPY . .
RUN dotnet build --no-restore -c Release

FROM build as test
RUN dotnet test --no-build -c Release

FROM build as publish
WORKDIR /app/Synel.Web
RUN dotnet publish --no-build -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine as final
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /bin
COPY --from=publish /app/Synel.Web/out .
ENTRYPOINT [ "dotnet", "Synel.Web.dll" ]

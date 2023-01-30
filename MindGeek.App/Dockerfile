
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 3000

RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["./MindGeek.App.csproj", "MindGeek.App/"]
RUN dotnet restore "MindGeek.App/MindGeek.App.csproj"


WORKDIR "/src/MindGeek.App"
COPY . .
RUN dotnet build "MindGeek.App.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "MindGeek.App.csproj" -c Release -o /app/publish

FROM node:16 AS build-web
COPY ./ClientApp/package.json /MindGeek.App/ClientApp/package.json
COPY ./ClientApp/package-lock.json /MindGeek.App/ClientApp/package-lock.json
WORKDIR /MindGeek.App/ClientApp
RUN npm ci
COPY ./ClientApp/ /MindGeek.App/ClientApp
RUN npm run build


FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build-web /MindGeek.App/ClientApp/build ./ClientApp/build

ENTRYPOINT ["dotnet", "MindGeek.App.dll"]
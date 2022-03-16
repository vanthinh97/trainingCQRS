FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /App
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Production
ENV CONSULHOST=http://192.168.222.150:8500
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true
COPY bin/Release/netcoreapp3.1/publish/ .

ENTRYPOINT ["dotnet", "Communication.API.dll"]
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/* 
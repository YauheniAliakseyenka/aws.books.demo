#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY AWS.Books.WebAPI.Demo/AWS.Books.WebAPI.Demo.csproj AWS.Books.WebAPI.Demo/
COPY Books.Application/Books.Application.csproj Books.Application/
RUN dotnet restore AWS.Books.WebAPI.Demo/AWS.Books.WebAPI.Demo.csproj
COPY . .
WORKDIR /src/AWS.Books.WebAPI.Demo
RUN dotnet build AWS.Books.WebAPI.Demo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AWS.Books.WebAPI.Demo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AWS.Books.WebAPI.Demo.dll"]

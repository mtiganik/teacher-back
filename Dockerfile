FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY teacher/*.csproj ./teacher/
COPY teacher.Db/*.csproj ./teacher.Db/
COPY teacher.Models/*.csproj ./teacher.Models/
COPY teacher.Services/*.csproj ./teacher.Services/

# restore nuget packages
RUN dotnet restore teacher -nowarn:NU1605  -nowarn:CS8618 -nowarn:CS8613 -nowarn:CS0108

# copy everything else
COPY teacher/ teacher/
COPY teacher.Db/ teacher.Db/
COPY teacher.Models/ teacher.Models/
COPY teacher.Services/ teacher.Services/

WORKDIR /app/teacher

RUN dotnet build -c Release  -nowarn:CS8618 -nowarn:CS8613 -nowarn:CS0108

FROM build AS publish
RUN dotnet publish -c Release -o /out -nowarn:CS8618 -nowarn:CS8613 -nowarn:CS0108
WORKDIR /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
COPY --from=publish /out /app
WORKDIR /app

ENTRYPOINT ["dotnet", "teacher.dll"]
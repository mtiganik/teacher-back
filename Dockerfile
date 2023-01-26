FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY teacher/*.csproj ./teacher/
COPY teacher.Db/*.csproj ./teacher.Db/
COPY teacher.Models/*.csproj ./teacher.Models/
COPY teacher.Services/*.csproj ./teacher.Services/

# restore nuget packages
RUN dotnet restore teacher -nowarn:NU1605  -nowarn:CS8618 -nowarn:CS8613

# copy everything else
COPY . /app

WORKDIR /app/teacher
RUN dotnet build -c Release  -nowarn:CS8618 -nowarn:CS8613
FROM build AS publish
RUN dotnet publish -c Release -o /out -nowarn:CS8618 -nowarn:CS8613

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /out
#COPY --from=build /out .
#RUN apt-get update && apt-get install -y libgdiplus

ENTRYPOINT ["dotnet", "teacher.dll"]
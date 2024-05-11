#Первый запуск

git clone https://github.com/Vulfonk/CinemaRegistrator.git

dotnet restore

dotnet msbuild WebApplication4.sln

#Последующие запуски
git pull --rebase

dotnet restore

dotnet msbuild WebApplication4.sln

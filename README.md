<p align=center>
  <br>
  <span>LinguaNews level based english news platform</span>
  <br>
</p>

### Requirements
- .NET 8.0 
- Visual Studio/Rider 

### Devs
- [Buğra Özdemir](https://github.com/bugraozdmr)

**_Dont forget to run docker before_**

## Docker-Compose For Api and Database
```console
# clone the repo
$ git clone https://github.com/bugraozdmr/LinguaNews.git

# change the working directory to LinguaNews
$ cd LinguaNews

# compose up
$ sudo docker-compose -p linguanews up --build

# or
$ docker-compose -p linguanews up --build
```

## Dotnet Package Installation
```console
# change the working directory backend/LinguaNews
$ cd backend/LinguaNews

# install packages
$ dotnet restore

# check the project is working
$ dotnet build
```

## Licence MIT

Thanks for using LinguaNews 🎉
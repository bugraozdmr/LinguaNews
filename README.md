# 📖 LinguaNews

<p align="center">
  <br>
  <span>🌍 Level-based English news platform designed to improve language skills 🌟</span>
  <br>
</p>

## 🚀 About the Project

**LinguaNews** is an innovative platform where users can learn English by reading news articles tailored to their skill levels.  
Whether you're a beginner or an advanced learner, LinguaNews has something for everyone! 🎓



## 🛠️ Technologies Used

### **Frontend**
- **Framework**: [React Native](https://reactnative.dev/)
- **Environment**: [Expo](https://expo.dev/)

### **Backend**
- **Framework**: [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **API**: RESTful services for seamless communication.

### Requirements
- .NET 8.0 
- npm
- Visual Studio / Rider / Code
- Docker

### Devs
- [Buğra Özdemir](https://github.com/bugraozdmr)
- [Ahmet Nuri Eroğlu](https://github.com/anurieroglu)

**_Dont forget to run docker before_**

## Backend Guide

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

- Rest of the steps has been told in [here](https://github.com/bugraozdmr/LinguaNews/blob/main/backend/README.md)
- API endpoints [here](https://github.com/bugraozdmr/LinguaNews/tree/main/backend/LinguaNews#readme)

## Frontend Guide
## Running The App
```console
# change the working directory frontend
$ cd frontend

# install packages
$ npm install

# run the project
$ npx expo start
```

## Licence MIT

Thanks for using LinguaNews 🎉
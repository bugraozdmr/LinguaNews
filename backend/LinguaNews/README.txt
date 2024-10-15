Önce docker compose kaldırılmalı (sadece postgres)

sonra migration alınmalı

sonra dotnet ef database update

sonra uygulama çalıştırılmalı
dotnet ef database update --startup-project ./LinguaNews.Api/

en son kontrol edilmeli tablolar gelmiş mi diye

dotnet ef migrations add InitialCreate -o Migrations -p LinguaNews.Infrastructure -s LinguaNews.Api
(burda ana dizinde olman lazım[calistirmadan once] LinguaNews.Infrastructure vs hepsinde altta gözükmeli -- -p project zaten vs..)
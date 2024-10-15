Önce docker compose kaldırılmalı (sadece postgres)

sonra migration alınmalı

sonra dotnet ef database update

sonra uygulama çalıştırılmalı
dotnet ef database update --startup-project ./LinguaNews.Api/

en son kontrol edilmeli tablolar gelmiş mi diye

dotnet ef migrations add InitialCreate -o Migrations -p LinguaNews.Infrastructure -s LinguaNews.Api
(burda ana dizinde olman lazım[calistirmadan once] LinguaNews.Infrastructure vs hepsinde altta gözükmeli -- -p project zaten vs..)

Compose.yml backend içinde çalıştırılmalı burda olmalı

!/ eğer halen sorun varsa sudo docker builder prune 12gb cache gitti

** Docker Compose Cozumu : context bir ust dizini göstermeliki buildingblocks'ada erişilebilsin .Bu şekilde yollar tekrar ayarlandır teker teker.Eğer değişiklik yaparsan kontrol et.!!

*** tabiki bir tek yollar değil .csprojlarda düzeltilmeli ve ayrıca
COPY LinguaNews/ LinguaNews/
COPY BuildingBlocks/ BuildingBlocks/

artık dosyalarda kopyalanıyor
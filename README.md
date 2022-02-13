# RiseAssessment

## Gereksinimler

RabbitMQ ve PostgreSQL'i docker desktop üzerine kurulum gerçekleştirdim.

 - RabbitMQ
 - PostgreSQL




## Kurulum

Kurulum işlemleri için "Contact.Data" 'da ve "Report.Api" 'de migrate işlemleri gerekmektedir.

    cd ~/ProjectFolder/RiseAssessment/Contact.Data
    dotnet ef migrations add InitialMigration
    dotnet ef database update
    
    cd ~/ProjectFolder/RiseAssessment/Report.Api
    dotnet ef migrations add InitialMigration
    dotnet ef database update
    
    

## Connection String Ayarlamaları

Contact.Api, Report.Api ve Report.WorkerService altında appsettings.json dosyasından Postgresql ve RabbitMQ bağlantı bilgilerini değiştiriniz.
 

## Projenin Başlatılması

Projenin başlatılması için Solution üzerinden Set Startup Project üzerinden aşağıdaki ayarlamaların gerçekleştirilmesi gerekmektedir.

![image](https://user-images.githubusercontent.com/32467049/153752392-e9ab40db-0e59-4850-a62d-1fd64066f25b.png)

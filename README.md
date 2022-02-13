# RiseAssessment

## Kurulum

Kurulum işlemleri için "Contact.Data" 'da ve "Report.Api" 'de migrate işlemleri gerekmektedir.

    cd ~/ProjectFolder/RiseAssessment/Contact.Data
    dotnet ef migrations add InitialMigration
    dotnet ef database update
    
    cd ~/ProjectFolder/RiseAssessment/Report.Api
    dotnet ef migrations add InitialMigration
    dotnet ef database update
    
    
## Gereksinimler

 - RabbitMQ
 - PostgreSQL
    
    

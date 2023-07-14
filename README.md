# CrmApp

Bir LMS uygulaması olacak. Portal üzerinden;
<br>
1-öğretmentler <br>
2-öğrenciler <br>
3-sınıflar <br>
4-notlar <br>
5-duyurular <br>
6-dersler <br>
7-adresler <br>
gibi bilgiler yönetilecek. <br>

Proje 3 katmandan oluşuyor. <br>
1-Presentasyon Portal <br>
2-Presentasyon Portal Api <br>
3-Servis Crm Service <br>

Client -> Portal -> Portal Api -> Service şeklinde req/res olarak bilgi alışverişi sağlanacak. <br> 
Proje microservise kolayca çevirilebilecek şekilde SOA geliştirilecek. İleride bir IAM (login) servis geliştirilip login bilgileri buradan yapılabilir. Şu an tek DB ileride per DB / per service olabilir.

<br>
Restfull API'ler olarak geliştirilecek. <br>
DB MSSQL <br>
Cache redis kullanılabilir <br>

IAM servis için JWT kullanılabilir . IAM service için database olarak MongoDb kullanılmıştır .

<br>
Containerization  - Docker 
<br>
CI-CD - Azure Devops

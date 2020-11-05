First of all I would like to say, that I spent 2 evening on this task instaed of week before deadline comes. Unfortunately, I had no much time on this week. So, there are a lot of things can be improved:
Error handling, Logs, 
Architecture of DAL, web api, angular and so on..
Moreover, I did not have enough time for writing tests(I wanted use mock and  settup test framework).
Large file uploading(10000000 rows) - I tested load of huge file vioa Bulk insert to directly on back-end and it's works fine using BulkOperation, but - bulp update needs to be adjusted. 
Furthermore, I faced with issue about requirements of size in order to upload it to via webapi. I handed it by updating web.config(extend allowed size), it's started working on IIS. Then I got new issue that for some reason js httpclient doesnt send such big file, I had not time to figure out a cause, so I had to leave it. 

Dev Environmet details: 
I'm using MSSQLLocalDB with DropCreateDatabaseAlways, so as it test project, I did it in order to recreate datebase each run time. WebApi needs to be hosted on local IIS under "http://localhost/SalesManager". Also it could be needed to change identityType type to NetworkService. Angular project is located in solution root in Angular folder and can be runned via "ng serve". If you will get some cors issues in browser - e.g. chrome can be runned via "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --disable-web-security --disable-gpu --user-data-dir=~/chromeTemp" and it should helps to tests it. 


# FindFriends
<p><h4>FindFriends sample project.</h4></p>
<br />

<p><strong>Tools:</strong><p>

Visual Studio Community 2017

SQL Server Express 2017

C#

Asp.Net Core

EF Core with fluentApi

Postman

<br />
<br />

<p><strong>Instructions:</strong></p>

All database scripts are stored in folder 'DB Scripts'.

The sample requests are in folder 'Request samples' (screenshots included).

The connection string is in file 'appsettings.json' (FindFriends.WebApi project).


<br />
<br />

<p><strong>Summary:</strong></p>

a) There are 2 main methods in Web Api Controller:

- Add():
  Add a new friend into database ('Friends' table), containing name, city, country, latitude and longitude.
  
  The coordinates are in DD (decimal degrees). i.e.: Lat: 38.7222 , Long: -9.1393
  
  Negatives and positives numbers are accepted.
  
  To speed up the process, there are a DML script in 'DB Scripts' folder that inserts some sample rows.
  <br />
  
- GetNearbyFriends(string friendname):
  Search for 3 nearest friends of the friend passed as parameter (search by name).
  
  Every search saves a log to 'CalculateLog' table, wich contains all friends ordered by nearness.
  
  The nearest friends are listed first.


<br />

b) Additional methods

  Those methods make some Crud to 'Friends' table:

- GetById(int id)  
- GetAll()
- Update([FromBody] Friend friend)
- Delete(int id)






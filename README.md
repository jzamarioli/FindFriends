# FindFriends
<p><h4>FindFriends sample project.</h4></p>
<br />
This is a .Net Core Web Api project that stores the latitude/longitude coordinates of friends, and then allows the user to make a search for the 3 nearest friends of a friend passed as parameter.
<br />
That project doesn't use any geolocation Api, it's just a simple C# alghorithm to bring back a list of closest friends.
<br />
<br />
<p><strong>Tools used:</strong><p>

Visual Studio Community 2017

SQL Server Express 2017

C#

Asp.Net Core

EF Core with fluentApi

Postman

<br />
<br />

<p><strong>Instructions:</strong></p>

All database scripts are stored in 'DB Scripts' folder.

The sample requests are in 'Request samples' folder (screenshots included).

The connection string is in 'appsettings.json' file (FindFriends.WebApi project).


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






<Query Kind="Expression">
  <Connection>
    <ID>4e239046-efc0-4caf-884b-760de78e41d4</ID>
    <Persist>true</Persist>
    <Server>WA322-05</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//sample of query syntax to dump the Artist data
from x in Artists
select x

//sample of method syntax to dump the Artist data
Artists.Select (x => x)

//sort datainfo.Sort((x,y) => x.AttributeName.CompareTo(y.AttributeName))

//find any artist whose name contains the string "son"
from x in Artists
where x.Name.Contains("son")
select x

Artists
	.Where(x => x.Name.Contains("son"))
	.Select(x => x)
	
//create a list of albums released in 1970
Albums
	.Where(x => x.ReleaseYear == 1970)
	.Select(x => x)
//or
from x in Albums
where x.ReleaseYear == 1970
select x

//create a list of albums released in 1970 order by Title
from x in Albums
where x.ReleaseYear == 1970
orderby x.Title
select x
//or
Albums
	.Where(x => x.ReleaseYear == 1970)
	.OrderBy(x => x.Title)
	.Select(x => x)
	
//create a list of albums released between 2007 and 2018
//order by ReleaseYear then by title
from x in Albums
where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2018
orderby x.ReleaseYear descending, x.Title
select x

//note the difference in method names using the method syntax
// a descending orderby is .OrderByDescending
// secondary and beyond ordering is .ThenBy
Albums
	.Where (x => ((x.ReleaseYear >= 2007) && (x.ReleaseYear <=2018)))
	.OrderByDescending (x => x.ReleaseYear)
	.ThenBy (x => x.Title)
	
//can navigational properties be used in queries
//create a list of albums by Deep Purple
//show only the title, artist name, release year and release label

//use the navigational properties to obtain the Artist data
//new {...} create a new dataset (class definition)
from x in Albums
where x.Artist.Name.Contains("Deep Purple")
orderby x.ReleaseYear, x.Title
select new
{
	Title = x.Title,
	ArtistName = x.Artist.Name,
	RYear = x.ReleaseYear,
	RLabel = x.ReleaseLabel
}
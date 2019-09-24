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

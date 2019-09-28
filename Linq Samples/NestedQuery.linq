<Query Kind="Expression">
  <Connection>
    <ID>4e239046-efc0-4caf-884b-760de78e41d4</ID>
    <Persist>true</Persist>
    <Server>WA322-05</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//create a list of all album containing the album title and artist
//along with all the tracks (song name, genre and length) of that album
from x in Albums
select new
{
	title = x.Title,
	artist = x.Artist.Name,
	tracks = from y in x.Tracks
			select new
			{
				Song = y.Name,
				Genre = y.Genre.Name,
				Length = y.Milliseconds
			}
}
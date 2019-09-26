<Query Kind="Program">
  <Connection>
    <ID>4e239046-efc0-4caf-884b-760de78e41d4</ID>
    <Persist>true</Persist>
    <Server>WA322-05</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	var results  = from x in Albums
				where x.Artist.Name.Contains("Deep Purple")
				orderby x.ReleaseYear, x.Title
				select new AlbumsOfArtist
				{
					Title = x.Title,
					ArtistName = x.Artist.Name,
					RYear = x.ReleaseYear,
					RLabel = x.ReleaseLabel
				};
				
	results.Dump();
}

// Define other methods and classes here
public class AlbumsOfArtist
{
	public string Title {get; set;}
	public string ArtistName {get; set;}
	public int RYear {get; set;}
	public string RLabel {get; set;}
}
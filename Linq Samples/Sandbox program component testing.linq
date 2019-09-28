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
	string artistname = "Deep Purple";
	var results  = from x in Albums
				where x.Artist.Name.Contains(artistname)
				orderby x.ReleaseYear, x.Title
				select new AlbumsOfArtist
				{
					Title = x.Title,
					ArtistName = x.Artist.Name,
					RYear = x.ReleaseYear,
					RLabel = x.ReleaseLabel
				};
				
//	results.Dump();

	//create a list of all customers in alphabetical order by lastname, firstname who live in the US with a yahoo email.
	//List full name (last, first), city, state and email only. Create the class definition of this list.
	var customerList = from x in Customers
					where x.Country.Equals("USA") & x.Email.Contains("yahoo.com")
					orderby x.LastName, x.FirstName
					select new YahooCustomers
					{
						FullName = x.LastName + ", " + x.FirstName,
						City = x.City,
						State = x.State,
						Email = x.Email
					};
//	customerList.Dump();
	
	//who is the artist who sang Rag Doll (track). List the Artist Name, the Album Title, Release Year and Label, along with the song (track) composer
	var whosang = from x in Tracks
				where x.Name.Equals("Rag Doll")
				select new
				{
					ArtistName = x.Album.Artist.Name,
					AlbumTitle = x.Album.Title,
					AlbumYear = x.Album.ReleaseYear,
					AlbumLabel = x.Album.ReleaseLabel,
					Composer = x.Composer
				};
//	whosang.Dump();
	
	//create a list of album released in 2001. List the album title, artist name and label
	//if the release label is null, use the string "Unknown"
	var albumlist = from x in Albums
					where x.ReleaseYear.Equals("2001")
					select new
					{
						AlbumTitle = x.Title,
						ArtistName = x.Artist.Name,
						Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
					};
//	albumlist.Dump();
	
	//list of all albums specifying if they were release in the 70's, 80's, 90's or modern music. 
	//list the title and decade
	var titledecade = from x in Albums
					select new
					{
						Title = x.Title,
						Decade = x.ReleaseYear <= 1970 && x.ReleaseYear >= 1979 ? "70's" : 
								x.ReleaseYear <= 1980 && x.ReleaseYear <= 1989 ? "80's" :
								x.ReleaseYear <= 1990 && x.ReleaseYear <= 1999 ? "90's" : "Modern Music"
					};
	titledecade.Dump();
}

// Define other methods and classes here
public class AlbumsOfArtist
{
	public string Title {get; set;}
	public string ArtistName {get; set;}
	public int RYear {get; set;}
	public string RLabel {get; set;}
}

public class YahooCustomers
{
	public string FullName {get; set;}
	public string City {get; set;}
	public string State {get; set;}
	public string Email {get; set;}
}
<Query Kind="Statements">
  <Connection>
    <ID>4e239046-efc0-4caf-884b-760de78e41d4</ID>
    <Persist>true</Persist>
    <Server>WA322-05</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//to get both the albums with tracks and without tracks, you can use a .Union()
//in a union, you need to ensure cast typing is correct
//								 column cast types match identically
//                               each query has the same number of columns
//								 same order of columns


//create a list of all albums, show the Title, number of tracks, total cost
// of tracks, average length (milliseconds) of the tracks

//Problem exists for albums without any tracks. Summing and Averages need
// data to work. If an album has no tracks, you would get an abort

//Solution
//create 2 queries: a) with tracks and b) without tracks, then union the results

//syntax: (query1).Union(query2).Union(queryn).Orderby(first sort).ThenBy(sortn)

var unionsample = (from x in Albums
				  where x.Tracks.Count() > 0
				  select new
				  {
				  	title = x.Title,
					trackcount = x.Tracks.Count(),
					priceoftracks = x.Tracks.Sum(y => y.UnitPrice),
					avglengthA = x.Tracks.Average(y => y.Milliseconds)/1000.0,
					avglengthB = x.Tracks.Average(y => y.Milliseconds/1000.0)
				  }).Union(
					from x in Albums
				    where x.Tracks.Count() == 0
				    select new
				    {
				  		title = x.Title,
						trackcount = 0,
						priceoftracks = 0.00m,
						avglengthA = 0.00,
						avglengthB = 0.00
				  	}).OrderBy(y => y.trackcount).ThenBy(y => y.title);
//unionsample.Dump();

//boolean filters .All() or .Any()
//.Any() method iterates through the entire collection to see if
//  any of the items match the specific condition
//returns a true or false
//an instance of the collection that receives a true is selected for processing

//Genres.OrderBy(x => x.Name).Dump();

//list Genres that have tracks which are not on any playlist
var genretrack = from x in Genres
				where x.Tracks.Any(tr => tr.PlaylistTracks.Count() == 0)
				orderby x.Name
				select new
				{
					name = x.Name
				};
//genretrack.Dump();

//.All() method iterates through the entire collection to see if
//  all of the items match the specified condition
//returns a true or false
//an instance of the collection that receives a true is selected for processing

//list Genres that have all their tracks appearing at least once on a playlist
var populargenres = from x in Genres
					where x.Tracks.All(tr => tr.PlaylistTracks.Count() > 0)
					orderby x.Name
					select new
					{
						name = x.Name,
						thetracks = (from y in x.Tracks
										where y.PlaylistTracks.Count() > 0
										select new
										{
											song = y.Name,
											count = y.PlaylistTracks.Count()
										})
					};
//populargenres.Dump();

//sometimes you have two lists that need to be compared
//Usually you are looking for items that are the same (in both collections)
// OR you are looking for items that are different
//in either case: you are comparing one collection to a second collection

//obtain a distinct list of all playlist tracks for Roberto Almeida (username AlmeidaR)
var almeida = (from x in PlaylistTracks
				where x.Playlist.UserName.Contains("Almeida")
				orderby x.Track.Name
				select new
				{
					genre = x.Track.Genre.Name,
					id = x.TrackId,
					song = x.Track.Name
				}).Distinct();
//almeida.Dump();

//obtain a distinct list of all playlist tracks for Michelle Brooks (username BrooksM)
var brooks = (from x in PlaylistTracks
				where x.Playlist.UserName.Contains("Brooks")
				orderby x.Track.Name
				select new
				{
					genre = x.Track.Genre.Name,
					id = x.TrackId,
					song = x.Track.Name
				}).Distinct();
//brooks.Dump();

//list tracks that both Roberto and Michelle like
var likes = almeida.Where(a => brooks.Any(b => b.id == a.id))
					.OrderBy(a => a.genre)
					.Select(a => a);
//likes.Dump();

//list the Robert's tracks that Michelle does not have
var almeidadif = almeida.Where(a => !brooks.Any(b => b.id == a.id))
					.OrderBy(a => a.genre)
					.Select(a => a);
//almeidadif.Dump();

//list the Michelles's tracks that Robert does not have
var brooksdif = brooks.Where(a => !almeida.Any(b => b.id == a.id))
					.OrderBy(a => a.genre)
					.Select(a => a);
//brooksdif.Dump();

//Joins
//Joins can be used where navigational properties DO NOT exist
//Joins can be used between associate entities
//scenario pkey = fkey

//left side of the join should be the support data
//right side of the join is the record collection to be processed

//List albums showing title, releaseyear, label, artistname and track count

var results = from xRightSide in Albums
				join yLeftSide in Artists
				on xRightSide.ArtistId equals yLeftSide.ArtistId
				select new
				{
					title = xRightSide.Title,
					year = xRightSide.ReleaseYear,
					label = xRightSide.ReleaseLabel == null ? "Unknown" : xRightSide.ReleaseLabel,
					artistjoin = yLeftSide.Name, //this is using joins
					artistnav = xRightSide.Artist.Name, //this is using the navigational property
					trackcount = xRightSide.Tracks.Count()
				};
results.Dump();

//great examples at the following url
//www.dotnetlearners.com/linq
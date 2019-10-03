<Query Kind="Statements">
  <Connection>
    <ID>4e239046-efc0-4caf-884b-760de78e41d4</ID>
    <Persist>true</Persist>
    <Server>WA322-05</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//using multiple steps to obtain the required data query

//create a list showing whether a particular track length
//  is greater than, less than or the average track length (Milliseconds)

//problem, I need the average track length before testing
//  the individual track length agains the average

//---solution---

//what is the average track length?
//var resultavg = (from x in Tracks
//				select x.Milliseconds).Average();
var resultavg = Tracks.Average(x => x.Milliseconds);
resultavg.Dump();

//create query using the average track length.
var resultreport = from x in Tracks
					select new
					{
						song = x.Name,
						length = x.Milliseconds,
						LongShortAvg = x.Milliseconds > resultavg ? "Long" : 
										x.Milliseconds < resultavg ? "Short" :
										"Average"
					};
resultreport.Dump();

//list all the playlist which have a track showing the playlist name,
// number of tracks on the playlist, the cost of the playlist,
// the total storage size for the playlist in megabytes

var result3 = from pl in Playlists
				where pl.PlaylistTracks.Count() > 0
				select new
				{
					name = pl.Name,
					trackcount = pl.PlaylistTracks.Count(),
					cost = pl.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
					storage = pl.PlaylistTracks.Sum(plt => plt.Track.Bytes/100000.0)
					//another option: storage = (from plt in pl.PlaylistTracks select plt.Track.Bytes/100000.0).Sum()
				};
result3.Dump();

//list all albums with tracks showing the album title, artist name, number of tracks and the album cost

var result4 = from x in Albums
				where x.Tracks.Count() > 0
				select new
				{
					title = x.Title,
					artist = x.Artist.Name,
					trackcount = x.Tracks.Count()
				};
result4.Dump();

//What is the maximum album count for all the artist

var result5 = Artists.Select(x => x.Albums.Count()).Max();
result5.Dump();
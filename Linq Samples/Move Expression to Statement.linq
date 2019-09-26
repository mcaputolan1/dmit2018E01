<Query Kind="Statements">
  <Connection>
    <ID>4e239046-efc0-4caf-884b-760de78e41d4</ID>
    <Persist>true</Persist>
    <Server>WA322-05</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//when using the language C# statement(s)
//your work will need to confirm to C# statement syntax
//ie: datatype variable = expression;

//can navigational properties be used in queries
//create a list of albums by Deep Purple
//show only the title, artist name, release year and release label

//use the navigational properties to obtain the Artist data
//new {...} create a new dataset (class definition)
var results  = from x in Albums
				where x.Artist.Name.Contains("Deep Purple")
				orderby x.ReleaseYear, x.Title
				select new
				{
					Title = x.Title,
					ArtistName = x.Artist.Name,
					RYear = x.ReleaseYear,
					RLabel = x.ReleaseLabel
				};
				
//to display the contents of a variable in LinqPad
//use the method .Dump()
//this method is only used in LinqPad, it is NOT a C# method
results.Dump();
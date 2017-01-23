using System;
using Nest;

namespace ElasticDotNet
{
	public class Tweet
	{
		// public int Id { get; set; }
		// public Guid Id { get; set; }
		public string User { get; set; }
		public int UserId { get; set; }
		public DateTime PostDate { get; set; }
		public string Message { get; set; }
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			var node = new Uri("http://localhost:9200");
			var settings = new ConnectionSettings(node);
			settings.DefaultIndex("mytweetindex");

			var client = new ElasticClient(settings);

			var tweet = new Tweet
			{
				//Id = Guid.NewGuid(),
				User = "robert",
				UserId = 25,
				PostDate = new DateTime(2009, 11, 15),
				Message = "Trying out NEST, so far so good?"
			};

			var response = client.Index(tweet);
			Console.WriteLine(response.DebugInformation);
		}
	}
}

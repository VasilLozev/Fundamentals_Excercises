// Filename:  HttpServer.cs
// Author:    Benjamin N. Summerton <define-private-public>
// License:   Unlicense (http://unlicense.org/)

using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web
{

	class User {
		public int id {get; set;} = 1;
		public string name  {get; set;} = "John Doe";
	}

	class HttpServer
	{
		public static HttpListener listener;
		public static string url = "http://localhost:8000/";
		public static int pageViews = 0;
		public static int requestCount = 0;
		public static string pageData =
			"<!DOCTYPE>" +
			"<html>" +
			"  <head>" +
			"    <title>HttpListener Example</title>" +
			"  </head>" +
			"  <body>" +
			"    <p>Page Views: {0}</p>" +
			"    <form method=\"post\" action=\"shutdown\">" +
			"      <input type=\"submit\" value=\"Shutdown\" {1}>" +
			"    </form>" +
			"  </body>" +
			"</html>";


		public static async Task HandleIncomingConnections()
		{
			bool runServer = true;

			// While a user hasn't visited the `shutdown` url, keep on handling requests
			while (runServer)
			{
				// Will wait here until we hear from a connection
				HttpListenerContext ctx = await listener.GetContextAsync();

				// Peel out the requests and response objects
				HttpListenerRequest req = ctx.Request;
				HttpListenerResponse resp = ctx.Response;

				// Print out some info about the request
				Console.WriteLine("Request #: {0}", ++requestCount);
				Console.WriteLine(req.Url.ToString());
				Console.WriteLine(req.HttpMethod);
				Console.WriteLine(req.UserHostName);
				Console.WriteLine(req.UserAgent);
				Console.WriteLine();

				User user1 = new User { id = 1, name = "Krum L."};
				User user2 = new User { id = 2, name = "Vasil L."};
				if (req.HttpMethod == "GET" && req.Url.AbsolutePath == "/users") {
					var list = new List<User>(){user1, user2};
					byte[] encoded = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(list));
					resp.ContentType = "application/json";
					resp.ContentEncoding = Encoding.UTF8;
					resp.ContentLength64 = encoded.LongLength;

					// Write out to the response stream (asynchronously), then close it
					await resp.OutputStream.WriteAsync(encoded, 0, encoded.Length);
					resp.Close();
					continue;
				}

				// If `shutdown` url requested w/ POST, then shutdown the server after serving the page
				if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
				{
					Console.WriteLine("Shutdown requested");
					runServer = false;
				}
																	
				// Make sure we don't increment the page views counter if `favicon.ico` is requested
				if (req.Url.AbsolutePath != "/favicon.ico")
					pageViews += 1;

				// Write the response info
				string disableSubmit = !runServer ? "disabled" : "";
				byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
				resp.ContentType = "text/html";
				resp.ContentEncoding = Encoding.UTF8;
				resp.ContentLength64 = data.LongLength;

				// Write out to the response stream (asynchronously), then close it
				await resp.OutputStream.WriteAsync(data, 0, data.Length);
				resp.Close();
			}
		}


		public static void Main(string[] args) {
			// Create a Http server and start listening for incoming connections
			listener = new HttpListener();
			listener.Prefixes.Add(url);
			listener.Start();
			Console.WriteLine("Listening for connections on {0}", url);

			// Handle requests
			Task listenTask = HandleIncomingConnections();
			listenTask.GetAwaiter().GetResult();

			// Close the listener
			listener.Close();
		}
	}
}

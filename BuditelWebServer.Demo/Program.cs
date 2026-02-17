using BuditelWebServer.Server;
using BuditelWebServer.Server.HTTP;
using BuditelWebServer.Server.Responses;
using BuditelWebServer.Server.Views;

namespace BuditelWebServer.Demo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var server = new HttpServer(x =>
			x.MapGet("/html", new HtmlResponse("<h1 style=\"color:blue;\">Hello from my html response</h1>"))
			//.MapGet("/", new TextResponse("Hello from my server, now with routing table!!!"))
			.MapGet("/store", new HtmlResponse(Home.Html))
			.MapGet("/redirect", new RedirectResponse("https://github.com/"))
			.MapGet("/login", new HtmlResponse(Form.Html))
			.MapPost("/login", new TextResponse("",AddFormDataAction)));
			server.Start();
		}

		private static void AddFormDataAction(Request request, Response response)
		{
			response.Body = "";

			foreach (var (key,value) in request.FormData)
			{
				response.Body += $"{key} - {value}";
				response.Body += Environment.NewLine;
			}
		}
	}
}

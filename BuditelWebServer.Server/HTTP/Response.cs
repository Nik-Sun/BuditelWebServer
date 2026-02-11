using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.HTTP
{
	public class Response
	{
        public Response(StatusCode statusCode)
        {
			StatusCode = statusCode;
			Headers.Add(Header.Server,"MyWebServer");
			Headers.Add(Header.Date,$"{DateTime.UtcNow : r}");
		}

		public HeaderCollection Headers { get; } = new HeaderCollection();

        public StatusCode StatusCode { get; init; }
        public string Body { get; set; }

    }
}

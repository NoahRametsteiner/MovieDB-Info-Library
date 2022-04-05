using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MovieDB_Info_Library.Model;


namespace MovieDB_Info_Library.API
{
    class Call
    {
        static Movie movie { get; set; }
        private const string URL = "https://www.omdbapi.com/";
        private const string APIKey = "?apikey=17c4065b";
        
        public class DataObject
        {
            public string Title { get; set; }
            public int Year { get; set; }
        }
        public static string MovieTitle { get; set; }
        public static string getTitle(string Title)
        {
            APIcallAsync(Title);

            return MovieTitle;
        }
        public static async void APIcallAsync(string Title)
        {
            string Search = "&t=";
            string urlParameters;


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            urlParameters = APIKey + Search + Title;
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(urlParameters);  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var movieTest = response.Content.ReadAsAsync<DataObject>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                MovieTitle = movieTest.Title;
                
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            
        }

    }
}

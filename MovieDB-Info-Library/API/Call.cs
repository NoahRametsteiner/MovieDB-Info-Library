using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MovieDB_Info_Library.Model;
using MovieDB_Info_Library.ViewModel;

namespace MovieDB_Info_Library.API
{
    class Call
    {
        public static Movie movie { get; set; }
        public static Movie year { get; set; }
        private const string URL = "https://www.omdbapi.com/";
        private const string APIKey = "?apikey=17c4065b";
        
        public static string MovieTitle { get; set; }
        public static string MovieYear { get; set; }
        public static string MovieRated { get; set; }
        public static string MovieRuntime { get; set; }
        public static string MovieGenre { get; set; }
        public static string MovieDirector { get; set; }
        public static string MovieActors { get; set; }
        public static string MoviePlot { get; set; }
        public static String MovieLanguage { get; set; }
        



        public static Movie APICall(string Title)
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
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                movie = response.Content.ReadAsAsync<Movie>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                MovieTitle = movie.Title;
                MovieYear = movie.Year;
                MovieRated = movie.Rated;
                MovieRuntime = movie.Runtime;
                MovieGenre = movie.Genre;
                MovieDirector = movie.Director;
                MovieActors = movie.Actors;
                MoviePlot = movie.Plot;
                MovieLanguage = movie.Language;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return movie;
            
        }

    }
}

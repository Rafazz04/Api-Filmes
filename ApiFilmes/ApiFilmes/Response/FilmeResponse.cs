using Newtonsoft.Json;

namespace ApiFilmes.Response
{
    public class FilmeResponse
    {
        [JsonProperty("imdbID")]
        public int IdImdb { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
    }
}

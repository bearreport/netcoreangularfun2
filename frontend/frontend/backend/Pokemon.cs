using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace backend

{
    public class Pokemon

        //getters and setters
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string BaseExperience { get; set; }

        //public methods

        public static List<Pokemon> getPokemonList()
        {
            string getUrl = "https://pokeapi.co/api/v2/pokemon?limit=151";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            IRestResponse restResponse = restClient.Get(restRequest);
            List<Pokemon> pokeList = new List<Pokemon>();

            if (restResponse.IsSuccessful)
            {
                JObject content = JObject.Parse(restResponse.Content);
                var results = content.ToString();
                var pokeResults = JsonConvert.DeserializeObject<PokeResult>(results);

                foreach (var result in pokeResults.Results)
                {
                    Pokemon currentPokemon = new Pokemon();
                    currentPokemon.Name = result.Name;
                    pokeList.Add(currentPokemon);
                }

            }

            return pokeList;

        }
        
    }

   
}

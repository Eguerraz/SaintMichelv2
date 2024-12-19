using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class Event_API
    {
        public readonly string _baseUrl;

        public Event_API()
        {
            _baseUrl = "http://saintmichel.alwaysdata.net/";
        }



        public async Task<List<Event>> GetEventAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Construire l'URL pour la requête GET
                    string url = $"{_baseUrl}/GetAllEvent";

                    // Effectuer la requête GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Lire le contenu de la réponse
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Désérialiser la réponse JSON en une liste d'objets OffrePro
                    List<Event> eventList = JsonConvert.DeserializeObject<List<Event>>(jsonResponse);

                    return eventList;
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs, par exemple journaliser l'exception
                    Console.WriteLine($"Erreur lors de la récupération des offres : {ex.Message}");
                    return null;
                }
            }
        }


        public async Task<List<Event>> GetEventByDateAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    // Construire l'URL pour la requête GET
                    string url = $"{_baseUrl}/GetAllEvent";

                    // Effectuer la requête GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Lire le contenu de la réponse
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Désérialiser la réponse JSON en une liste d'objets OffrePro
                    List<Event> eventList = JsonConvert.DeserializeObject<List<Event>>(jsonResponse);

                    return eventList;
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs, par exemple journaliser l'exception
                    Console.WriteLine($"Erreur lors de la récupération des offres : {ex.Message}");
                    return null;
                }
            }
        }

        public async Task<List<Event>> GetEventByDateAsync(DateTime date)
{
    using (HttpClient client = new HttpClient())
    {
        try
        {
            // Formatage de la date pour l'URL (exemple : "2024-10-01")
            string formattedDate = date.ToString("yyyy-MM-dd");

            // Construire l'URL avec la date directement dans le chemin
            string url = $"{_baseUrl}/GetEventByDate/{formattedDate}";

            // Effectuer la requête GET
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Lire le contenu de la réponse
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Désérialiser la réponse JSON en une liste d'objets Event
            List<Event> eventList = JsonConvert.DeserializeObject<List<Event>>(jsonResponse);

            return eventList;
        }
        catch (Exception ex)
        {
            // Gérer les erreurs, par exemple journaliser l'exception
            Console.WriteLine($"Erreur lors de la récupération des événements : {ex.Message}");
            return null;
        }
    }
}

    }
}

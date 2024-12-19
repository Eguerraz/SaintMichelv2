using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintMichel
{
    public class OffrePro_API
    {
        private readonly string _baseUrl;

        public OffrePro_API()
        {
            _baseUrl = "http://saintmichel.alwaysdata.net/";
        }

        //public async Task<ToDoList> GetOffreAsync(string id)
        //{
        //    return await Task.FromResult(LsToDoList.FirstOrDefault(s => s.Id == id));
        //}

        //public async Task<IEnumerable<ToDoList>> GetItemsAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(LsToDoList);
        //}

        public async Task<List<OffrePro>> GetOffreProAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Construire l'URL pour la requête GET
                    string url = $"{_baseUrl}/GetAllOffrePro";

                    // Effectuer la requête GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Lire le contenu de la réponse
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Désérialiser la réponse JSON en une liste d'objets OffrePro
                    List<OffrePro> offreProList = JsonConvert.DeserializeObject<List<OffrePro>>(jsonResponse);

                    return offreProList;
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs, par exemple journaliser l'exception
                    Console.WriteLine($"Erreur lors de la récupération des offres : {ex.Message}");
                    return null;
                }
            }
        }

       


    }
}
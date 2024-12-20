using Microsoft.Maui.Controls.Handlers.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Icu.Text.CaseMap;
//using static Android.Util.EventLogTags;

namespace SaintMichel.ViewModel
{
    [QueryProperty(nameof(IDInterim), nameof(IDInterim))]
    public partial class OffreProDetailPageViewModel: BaseViewModel
    {
        
        public int IDInterim { get; set; }


        int nombre_offre = 0;

        [ObservableProperty]
        private ObservableCollection<OffrePro> _obsItems; // Les items à afficher dans le ListView

        OffrePro_API _API;
        
        public OffreProDetailPageViewModel(OffrePro_API api)
        {
            _API = api;
            ObsItems = new ObservableCollection<OffrePro>(); // Initialisation de la collection Observable
            OnAppearing();
        }
        // Méthode pour charger les éléments depuis l'API
        async void OnAppearing()
        {
            await LoadItems();
        }

        [RelayCommand]
        async Task LoadItems()
        {
            IsBusy = true;
            try
            {
                ObsItems.Clear();
                var items = (await _API.GetOffreProAsync()).FirstOrDefault(item => item.IDInterim == IDInterim); // Appel API pour récupérer les données
                ObsItems.Add(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}"); // Afficher les erreurs dans la console
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur est survenue.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        
    }
}

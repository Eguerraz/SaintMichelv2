using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Views;
using SaintMichel.Model;
namespace SaintMichel.ViewModel
{
    public partial class OffreProPageViewModel : BaseViewModel
    {
        public List<string> type_offre { get; set; }
        public List<string> SecteurAct { get; set; }

        private string _selectedTypeOffre;
        public string SelectedTypeOffre
        {
            get => _selectedTypeOffre;
            set
            {
                if (_selectedTypeOffre != value)
                {
                    _selectedTypeOffre = value;
                    OnPropertyChanged();
                    FilterOffresByTypeOffre();
                }
            }
        }
        private string _selectedSecteurAct;
        public string SelectedSecteurAct
        {
            get => _selectedSecteurAct;
            set
            {
                if (_selectedSecteurAct != value)
                {
                    _selectedSecteurAct = value;
                    OnPropertyChanged();
                    FilterOffresBySecteurAct();
                }
            }
        }

        [ObservableProperty]
        private ObservableCollection<OffrePro> _obsItems; // Les items à afficher dans le ListView

        OffrePro_API _API;

        public OffreProPageViewModel(OffrePro_API api)
        {
            _API = api;
            ObsItems = new ObservableCollection<OffrePro>(); // Initialisation de la collection Observable
            OnAppearing();

            type_offre = new List<string>
            {
                "Aucun filtre pour type d'offre","Stage", "Interim", "Travail", "Alternance"
            };
            SelectedTypeOffre = "Aucun filtre pour type d'offre";

            SecteurAct = new List<string>
            {
                "Aucun filtre pour secteur d'activité","Agriculture", "Sylviculture", "Pêche", "Industrie manufacturière", "Énergie et gestion de l'eau", "Construction", "Commerce", "Transports et entreposage", "Hébergement et restauration", "Information et communication", "Activités financières et assurance", "Activités immobilières", "Activités scientifiques et techniques", "Activités de services administratifs et de soutien", "Administration publique et défense", "Éducation", "Santé humaine et action sociale", "Arts", "Spectacles et activités récréatives", "Autres activités de services"
            };
            SelectedSecteurAct = "Aucun filtre pour secteur d'activité";
        }

        // Méthode pour charger les éléments depuis l'API
        async void OnAppearing()
        {
            ObsItems.Clear();
            await LoadItems();
        }

        [RelayCommand]
        async Task LoadItems()
        {
            IsBusy = true;
            try
            {
                ObsItems.Clear();
                var items = await _API.GetOffreProAsync(); // Appel API pour récupérer les données

                foreach (var itemm in items)
                {
                    ObsItems.Add(itemm);
                }
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
        async void FilterOffresBySecteurAct()
        {

            await LoadItems();

            if (SelectedSecteurAct != "Aucun filtre pour secteur d'activité" && SelectedTypeOffre != "Aucun filtre pour type d'offre")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.TypeOffre == SelectedTypeOffre && o.SecteurActivite == SelectedSecteurAct).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            // Si aucun secteur n'est sélectionné, afficher toutes les offres
            else if (SelectedSecteurAct != "Aucun filtre pour secteur d'activité" && SelectedTypeOffre == "Aucun filtre pour type d'offre")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.SecteurActivite == SelectedSecteurAct).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else if (SelectedSecteurAct == "Aucun filtre pour secteur d'activité" && SelectedTypeOffre != "Aucun filtre pour type d'offre")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.TypeOffre == SelectedTypeOffre).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else
            {
                ObsItems.Clear();
                await LoadItems();
                //return;
            }



        }
        async void FilterOffresByTypeOffre()
        {

            await LoadItems();
            if (SelectedSecteurAct != "Aucun filtre pour secteur d'activité" && SelectedTypeOffre != "Aucun filtre pour type d'offre")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.TypeOffre == SelectedTypeOffre && o.SecteurActivite == SelectedSecteurAct).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            // Si aucun secteur n'est sélectionné, afficher toutes les offres
            else if (SelectedSecteurAct != "Aucun filtre pour secteur d'activité" && SelectedTypeOffre == "Aucun filtre pour type d'offre")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.SecteurActivite == SelectedSecteurAct).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else if (SelectedSecteurAct == "Aucun filtre pour secteur d'activité" && SelectedTypeOffre != "Aucun filtre pour type d'offre")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.TypeOffre == SelectedTypeOffre).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else
            {
                ObsItems.Clear();
                await LoadItems();
                //return;
            }
        }

        [RelayCommand]
        async void offreTapped(OffrePro itemm)
        {
            //if (IsBusy) return;
            //IsBusy = true;
            //OffrePro_API param1Value = new OffrePro_API();
            //await Shell.Current.GoToAsync($"OffreProDetailPage?param1={param1Value}");
            //IsBusy = false;

        }
    }
}

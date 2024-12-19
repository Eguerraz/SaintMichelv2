

namespace SaintMichel.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        // Private field with camelCase (btnText) 
        [ObservableProperty]
        private string? btnText = "rff";  // This generates a property BtnText


        [ObservableProperty]
        private string? headtxt = "click bot";



        int count = 0;

        [RelayCommand]
        async void CounterBtn()
        {
            count++;

            if (count == 1)
                BtnText = $"Clicked {count} time";
            else
                BtnText = $"Clicked {count} time";

            SemanticScreenReader.Announce(BtnText);
        }

        [RelayCommand]
        async Task GotoTodoView()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.GoToAsync("ItemPage");
            IsBusy = false;
        }

        [RelayCommand]
        async Task offreproview()
        {
            if (IsBusy) return;
            IsBusy = true;
            OffrePro_API param1Value = new OffrePro_API();
            await Shell.Current.GoToAsync($"OffreProPage?param1={param1Value}");
            IsBusy = false;
        }

        [RelayCommand]
        async Task GoToEventView()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.GoToAsync("EventPage");
            IsBusy = false;
        }

    }
}
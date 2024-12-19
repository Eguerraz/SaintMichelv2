using SaintMichel.ViewModel;

namespace SaintMichel
{
    public partial class OffreProPage : ContentPage
    {
        public OffreProPage(OffreProPageViewModel viewModel)
        {
            InitializeComponent();

            // BindingContext est automatiquement injecté via DI
            BindingContext = viewModel;
        }
    }
}
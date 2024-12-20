//using AndroidX.Lifecycle;
//using static Android.App.Assist.AssistStructure;
using SaintMichel.ViewModel;

namespace SaintMichel.View
{
    public partial class OffreProDetailPage : ContentPage
    {
        public OffreProDetailPage(OffreProDetailPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
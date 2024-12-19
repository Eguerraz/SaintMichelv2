namespace SaintMichel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //register to the root
           
            Routing.RegisterRoute(nameof(ItemPage), typeof(ItemPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("OffreProPage", typeof(OffreProPage));
            Routing.RegisterRoute(nameof(EventPage), typeof(EventPage)); 

        }
    }
}

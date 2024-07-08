using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;


namespace ICTOAN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current = (App)Application.Current;

        public IServiceProvider ServiceProvider { get; private set; } = null!;

        /// <summary>
        /// Start up logic for the program. Adds framework objects, opens the Host Window and runs the Configure method.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection collection = new();
            collection.AddSingleton<HostWindow>();
            collection.AddSingleton<NavigationOrganiser>();
            collection.AddSingleton<PageOrganiser>();

            Configure(collection);

            ServiceProvider = collection.BuildServiceProvider();

            var window = ServiceProvider.GetRequiredService<HostWindow>();
            window.Show();
        }


        /// <summary>
        /// Adds the given services to the collection. This is where you insert your own important classes.
        /// </summary>
        /// <param name="collection"></param>
        private void Configure(IServiceCollection collection)
        {
            // Add your classes / pages here.
            // ex:
            //   collection.AddSingleton<PlayerManager>();
            //   collection.AddSingleton<MainPage>();



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ICTOAN
{
    /// <summary>
    /// Interaction logic for HostWindow.xaml
    /// </summary>
    public partial class HostWindow : Window
    {

        #region PROPERTIES

        NavigationOrganiser navigationManager;
        PageOrganiser pageOrganiser;

        #endregion

        public HostWindow(NavigationOrganiser nav, PageOrganiser page)
        {
            InitializeComponent();

            navigationManager = nav;
            pageOrganiser = page;

            SetupEventCommands();


            /*  Change this to your desired startup Page type  */
            //navigationManager.NavigateTo(typeof(MainPage));
        }

        /// <summary>
        /// Sets up all event handlers. By default only has the Navigation listener.
        /// </summary>
        private void SetupEventCommands()
        {
            navigationManager.Navigating += NavigationManager_Navigating;
        }

        /// <summary>
        /// Handles the Navigating event. Sets the content of the frame to the page gotten from the PageOrganiser of corresponding type.
        /// Can be adapted if needed (for example, for Transient pages).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationManager_Navigating(object sender, NavigationEventArgs args)
        {
            mainFrame.Content = pageOrganiser.PageList[args.PageType];
        }
    }
}

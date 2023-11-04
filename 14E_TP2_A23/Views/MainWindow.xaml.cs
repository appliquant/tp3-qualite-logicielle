using _14E_TP2_A23.Data;
using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.Services;
using _14E_TP2_A23.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _14E_TP2_A23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainViewModel MainViewModel = ServiceHelper.GetService<MainViewModel>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModel;
            IDALService db = ServiceHelper.GetService<IDALService>();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel == null)
            {
                return;
            }

            MainViewModel.LoginCommand.Execute(null);
        }
    }
}

using _14E_TP2_A23.Helpers;
using System.Windows;

namespace _14E_TP2_A23.Views.DashboardSubPages.Climbing
{
    /// <summary>
    /// Logique d'interaction pour AddClimbingRouteDifficultyRatingWindow.xaml
    /// </summary>
    public partial class AddClimbingRouteDifficultyRatingWindow : Window
    {
        AddClimbingRouteDifficultyRatingWindow _addClimbingRouteDifficultyRatingWindow = ServiceHelper.GetService<AddClimbingRouteDifficultyRatingWindow>();

        public AddClimbingRouteDifficultyRatingWindow()
        {
            InitializeComponent();
            this.DataContext = _addClimbingRouteDifficultyRatingWindow;
        }
    }
}

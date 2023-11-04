using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.ViewModels
{
    public partial class MainViewModel: ObservableRecipient
    {
        [ObservableProperty]
        private string? _username;

        [ObservableProperty]
        private string? _password;
    }
}

using MyBiblioteca.Service;
using MyBiblioteca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBiblioteca.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly AzureService azureService;

        public LoginPage()
        {
            InitializeComponent();
            azureService = DependencyService.Get<AzureService>();
            BindingContext = new LoginViewModel(Navigation, azureService);
            /* InitializeComponent();
            var azureService = DependencyService.Get<AzureService>();
            BindingContext = new LoginViewModel(Navigation, azureService);*/
        }
        /*public async void Button_OnClicked(object sender, EventArgs e)
        {
            var user = await azureService.LoginAsync();

            //InfoLabel.Text = (user != null) ? $"Bem vindo {user.UserId}" : "Erro";
            if (user != null)
            {
                InfoLabel.Text = "Logou";
            }
            else
            {
                InfoLabel.Text = "Erro";
            }
        }*/
    }
}
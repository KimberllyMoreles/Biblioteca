using MyBiblioteca.Service;
using MyBiblioteca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyBiblioteca
{
    public partial class MainPage : ContentPage
    {
        readonly AzureService azureService;

        public MainPage()
        {
            InitializeComponent();
            azureService = DependencyService.Get<AzureService>();
            BindingContext = new MainViewModel(Navigation, azureService);
        }

        /*protected override void OnAppearing()
        {
            (BindingContext as MainViewModel)?.LoginAsync();
            base.OnAppearing();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var livro = (sender as ListView)?.SelectedItem as Livro;
            (BindingContext as MainViewModel)?.ShowLivroCommand.Execute(livro);
        }*/
    }
}

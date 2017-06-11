using MyBiblioteca.Helpers;
using MyBiblioteca.Service;
using MyBiblioteca.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace MyBiblioteca.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));
        

        public LoginViewModel(INavigation nav, AzureService service)
        {
            azureService = service;
            navigation = nav;

        }

        private async Task ExecuteLoginCommandAsync()
        {
            /*
            try
            {
                await LoginAsync();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                throw;
            }*/
            if (IsBusy || !(await LoginAsync()))
                return;
            else
            {
                //Small delay
                await Task.Delay(100);
                                                
                var MainPage = new MainPage();
                await navigation?.PushAsync(MainPage);
                                
                RemovePageFromStack();
            
        }

        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(LoginPage))
                {
                    navigation.RemovePage(page);
                }
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return azureService.LoginAsync();
        }
    }
}

using MyBiblioteca.Model;
using MyBiblioteca.Service;
using MyBiblioteca.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyBiblioteca.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;
        
        public Command SearchCommand { get; }
        public Command<Livro> ShowLivroCommand { get; }

        private string _searchTerm;

        public ObservableCollection<Livro> Livros { get; }

        public MainViewModel(INavigation nav, AzureService service)
        {
            azureService = service;
            Livros = new ObservableCollection<Livro>();
            navigation = nav;
            ShowLivroCommand = new Command<Livro>(ExecuteShowLivroCommand);
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
        }

        private async void ExecuteShowLivroCommand(Livro livro)
        {
            await PushAsync<LivroViewModel>(azureService, livro);
        }

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (SetProperty(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }

        void ExecuteSearchCommand()
        {
            //Comandos para a busca
        }

        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}

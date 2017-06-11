using MyBiblioteca.Model;
using MyBiblioteca.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioteca.ViewModel
{
    public class LivroViewModel : BaseViewModel
    {
        AzureService azureService;
        private readonly Livro _livro;

        public ObservableCollection<Livro> Livros { get; }
        public string Title { get; private set; }

        public LivroViewModel(AzureService service, Livro livro)
        {
            azureService = service;
            _livro = livro;

            Livros = new ObservableCollection<Livro>();

            Title = "Livros";
        }
    }
}

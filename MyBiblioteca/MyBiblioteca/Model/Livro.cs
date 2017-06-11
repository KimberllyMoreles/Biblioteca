using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioteca.Model
{
    [DataTable("Livro")]
    public class Livro
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("autor")]
        public string Autor { get; set; }
    }
}

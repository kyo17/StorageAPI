using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AzureStorage.Models
{
    public class Catalogo
    {
        public Catalogo()
        {
            id = Guid.NewGuid().ToString();
        }

        [Key]
        public string id { get; set; }
        public string foto { get; set; }
        public string marca { get; set; }
        public int edicion { get; set; }
        public string nombre { get; set; }
        public bool activa { get; set; }
    }
}

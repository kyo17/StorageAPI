using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AzureStorage.Interface
{
    public interface IAzure
    {
        Task<string> savePhoto(string contenedor, byte[] archivo, string extension);
        Task<string> modify(string contenedor, string extension, string ruta, byte[] archivo);
        Task remove(string rutta, string contenedor);
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureStorage.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AzureStorage.AzureService
{
    public class Azure : IAzure
    {
        private string azure;

        public Azure(IConfiguration config)
        {
            azure = config.GetConnectionString("AzureStorage");
        }

        public async Task<string> savePhoto(string contenedor, byte[] archivo, string extension)
        {
            var client = new BlobContainerClient(azure, contenedor);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(fileName);
            using (var ms = new MemoryStream(archivo))
            {
                await blob.UploadAsync(ms);
            }
                return blob.Uri.ToString();
        }

        public async Task remove(string ruta, string contenedor)
        {
            if (string.IsNullOrEmpty(ruta))
            {
                return;
            }

            var client = new BlobContainerClient(azure, contenedor);
            await client.CreateIfNotExistsAsync();
            var archivo = Path.GetFileName(ruta);
            var blob = client.GetBlobClient(archivo);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> modify(string contenedor, string ruta, string extension, byte[] archivo)
        {
            await remove(ruta, contenedor);
            return await savePhoto(contenedor, archivo, extension);
        }
    }
}

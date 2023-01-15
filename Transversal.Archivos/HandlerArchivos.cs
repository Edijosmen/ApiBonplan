using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Transversal.Archivos
{
    public class HandlerArchivos
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public HandlerArchivos(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }

        public Task BorraArchivo(string ruta, string container)
        {
            string wwwrootPath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(wwwrootPath)) throw new Exception();

            var nombreArchivo = Path.GetFileName(ruta);
            string pathFinal = Path.Combine(wwwrootPath, container, nombreArchivo);
            if (File.Exists(pathFinal)) File.Delete(pathFinal);
            return Task.CompletedTask;
        }

        public async Task<string> CrearArchivo(byte[] file, string contenType, string extension, string container, string nombre)
        {
            string wwwrootPath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(wwwrootPath)) throw new Exception();
            string carpeta = Path.Combine(wwwrootPath, container);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            string nombreArchivo = $"{nombre}{extension}";
            string path = Path.Combine(carpeta, nombreArchivo);
            await File.WriteAllBytesAsync(path, file);
            string pahtActual = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            string dbUrl = Path.Combine(pahtActual, container, nombreArchivo).Replace("\\", "/");
            return dbUrl;
        }

        public async Task<string> GuardarImagen(IFormFile img, string capt)
        {
            using var stream = new MemoryStream();
            await img.CopyToAsync(stream);
            var fileBytes = stream.ToArray();
            var dbUrl = await CrearArchivo(fileBytes, img.ContentType, Path.GetExtension(img.FileName), capt, Guid.NewGuid().ToString());
            return dbUrl;
        }
    }
}
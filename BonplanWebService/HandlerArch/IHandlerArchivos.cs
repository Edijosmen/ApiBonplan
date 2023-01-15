namespace BonplanWebService.HandlerArch
{
    public interface IHandlerArchivos
    {
        Task<string> CrearArchivo(byte[] file, string contenType, string extension, string container, string nombre);
        Task BorraArchivo(string ruta, string container);
        Task<string> GuardarImagen(IFormFile img, string capt);
    }
}

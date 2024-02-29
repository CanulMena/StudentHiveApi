using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class ImageUploadService
{
    private readonly Cloudinary _cloudinary;

    public ImageUploadService(Cloudinary cloudinary)
    {
        this._cloudinary = cloudinary;
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("No file uploaded or file is empty");
        }

        using (var stream = file.OpenReadStream())
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                // Puedes agregar más opciones de configuración aquí, como el tamaño máximo de archivo, el formato permitido, etc.
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }

    public async Task DeleteImageAsync(string imageUrl)
    {
        // Parse la URL de la imagen para obtener el public ID que se necesita para eliminarla
        var publicId = GetPublicId(imageUrl);

        // Configuración de los parámetros para la eliminación
        var deleteParams = new DeletionParams(publicId)
        {
            ResourceType = ResourceType.Image
            // Puedes agregar más opciones de configuración aquí si es necesario
        };

        // Realizar la eliminación
        var result = await _cloudinary.DestroyAsync(deleteParams);

        // Verificar si la eliminación fue exitosa
        if (result.Result != "ok")
        {
            // La eliminación no fue exitosa, puedes manejar el error o lanzar una excepción si es necesario
            throw new Exception($"Failed to delete image. Cloudinary response: {result.Result}");
        }
    }

    // Método para extraer el Public ID de la URL de Cloudinary
    private string GetPublicId(string imageUrl)
    {
        var uri = new Uri(imageUrl);
        var publicId = Path.GetFileNameWithoutExtension(uri.Segments.Last());

        return publicId;
    }
}

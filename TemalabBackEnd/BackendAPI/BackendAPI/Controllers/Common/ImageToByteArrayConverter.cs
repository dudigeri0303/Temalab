using SixLabors.ImageSharp;

namespace BackendAPI.Controllers.Common
{
    public class ImageToByteArrayConverter
    {
        public async static Task<byte[]> PathToByteArray(string fileName) 
        {
            string workingDirectoy = Environment.CurrentDirectory;
            string fullPath = Path.Combine(workingDirectoy + "/Assets/" + fileName + ".jpg");
            Image img = await Image.LoadAsync(fullPath);
            using (var ms = new MemoryStream())
            {
                await img.SaveAsJpegAsync(ms);
                return ms.ToArray();
            }
        }
        public async static Task<byte[]> FileToByteArray(IFormFile imageFile) 
        {
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

using StayFit.Models;

namespace StayFit.helpers
{
    public static class FileUpload
    {
        public static async Task<bool> imageUpload(IFormFile Photo, string path)
        {
            if (Photo != null && Photo.Length > 0)
            {
                    // var fileName = exercicio.Name.ToLower() + Path.GetFileName(Photo.FileName).ToLower()  ;
                    var fileName = Path.GetFileName(Photo.FileName).ToLower();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(fileStream);
                    }
                
                return true;
            }
            return false;
        }

        public static async Task<bool> videoUpload(IFormFile Video, string path)
        {
            if (Video != null && Video.Length > 0)
            {
                //var fileName = exercicio.Name.ToLower()+Path.GetFileName(Video.FileName).ToLower();
                var fileName = Path.GetFileName(Video.FileName).ToLower();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Video.CopyToAsync(fileStream);
                }
                return true;
            }
            return false;
        }
    }
}

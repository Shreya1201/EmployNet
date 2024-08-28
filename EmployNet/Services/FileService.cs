namespace AspnetIdentityRoleBasedTutorial.Services
{
    public class FileService : IFileService
    {
        // To get the environment details like web root path
        IWebHostEnvironment environment;

        // Constructor to initialize the environment variable
        public FileService(IWebHostEnvironment env)
        {
            environment = env;
        }

        // Method to save the image to the server
        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                // Get the wwwroot path
                var wwwPath = this.environment.WebRootPath;

                // Combine the wwwroot path with the "Uploads" folder
                var path = Path.Combine(wwwPath, "Uploads");

                // Create the "Uploads" folder if it doesn't exist
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extensions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

                // If the file extension is not allowed, return an error message
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                // Generate a unique string for the file name to avoid conflicts
                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);

                // Save the file to the specified path
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();

                // Return success and the new file name
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                // Return an error message if an exception occurs
                return new Tuple<int, string>(0, "Error has occurred");
            }
        }

        // Method to delete the image from the server
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                // Get the wwwroot path
                var wwwPath = this.environment.WebRootPath;

                // Combine the wwwroot path with the "Uploads" folder and the file name
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);

                // If the file exists, delete it
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Return false if an exception occurs
                return false;
            }
        }
    }
}

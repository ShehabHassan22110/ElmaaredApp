namespace ElmaaredApp.BLL.Helper
{
    public static class FileUploader
    {
        public static string UploadFile(string LocalPath, IFormFile File)
        {

            try
            {
                // 1 ) Get Directory
                string FilePath = Directory.GetCurrentDirectory() + LocalPath;


                //2) Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);


                // 3) Merge Path with File Name
                string FinalPath = Path.Combine(FilePath, FileName);


                //4) Save File As Streams "Data Overtime"

                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }


                return FileName;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}

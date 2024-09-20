namespace Company.Route.PL.Helpers
{
    public class DocumentSetting
    {
        //1.Upload
        public static string UploadFile(IFormFile file, string foldername) 
        {//1. Get Location Folder Path
         // string folderpath = $"C:\\Users\\youusseff\\source\\repos\\Company.Route Solution\\Company.Route.PL\\wwwroot\\files\\{foldername}";
           
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", foldername);
            //Directory.GetCurrentDirectory() + @"wwwroot\files" + foldername;      //get the current path of PL automatically
            //2. Get File Name make it unique
            string filename = $"{Guid.NewGuid()}{file.FileName}";

        //3. Get File Path --> folderPath + fileName
        string filepath = Path.Combine(folderpath, filename);

        //4. save file as stream : data per time
          using  var filestream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(filestream);
            return filename ;
        }


        // 2. Delete

        public static void DeleteFile(string filename , string foldername) 
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", foldername , filename);

            if (File.Exists(filepath)) File.Delete(filepath);
        }
    }
}

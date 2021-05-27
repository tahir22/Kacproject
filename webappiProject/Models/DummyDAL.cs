using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public static class DummyDAL
    {
        static List<FileDTO> files= new List<FileDTO>();
        public static void SaveFileInDB( FileDTO dto)
        {
            files.Add(dto);
        }

        public static FileDTO GetFileByUniqueID(string UniqueName)
        {
            return files.Where(p => p.FileUniqueName == UniqueName).FirstOrDefault();
        }

        public static List<FileDTO> GetAllFiles( )
        {
            return files;
        }

    }
    public class FileDTO
    {
        public string FileUniqueName { get; set; }
        public string FileActualName { get; set; }
        public string ContentType { get; set; }
        public string FileExt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using webappiProject.Models;

namespace webappiProject.Controllers
{
    public class FilesDataControllerController : ApiController
    {



        [Route("api/FilesDataController/UploadFiless")]
        [HttpPost]
        
        public HttpResponseMessage UploadFiless(Employee obj )
        {
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                  foreach (var fileName in HttpContext.Current.Request.Files.AllKeys)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[fileName];
                        //string base64ImageRepresentation = Convert.ToBase64String(file);
                        //HttpPostedFileBase filee = Convert.ToBase64String(file);

                        if (file != null  )
                        {
                        if(file.FileName != "")
                        {
                            FileDTO fileDTO = new FileDTO();
                            fileDTO.FileActualName = file.FileName;
                            fileDTO.FileExt = Path.GetExtension(file.FileName);
                            fileDTO.ContentType = file.ContentType;
                            //Generate a unique name using Guid
                            fileDTO.FileUniqueName = Guid.NewGuid().ToString();
                            //Get physical path of our folder where we want to save images
                            var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                            var fileSavePath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);
                            file.SaveAs(fileSavePath);
                        }
                            


                        }
                    }
               
            } 
           //HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            ////Convert the File to Byte Array.
            //BinaryReader br = new BinaryReader(postedFile.InputStream);
            //byte[] bytes = br.ReadBytes(postedFile.ContentLength);



            ////HttpPostedFile file = Request.Files["myFile"];

          
            //if (postedFile != null && postedFile.ContentLength > 0)
            //{
            //    string fname = Path.GetFileName(postedFile.FileName);
            //    //file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));

            //    var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
            //    var fileSavePath = System.IO.Path.Combine(rootPath, fname);
            //    postedFile.SaveAs(fileSavePath);
            //}


           // var hh = Convert.ToBase64String(bytes, 0, bytes.Length);
            //Send the Base64 string to the Client.
          //  return Request.CreateResponse(HttpStatusCode.OK, Convert.ToBase64String(bytes, 0, bytes.Length));
            return Request.CreateResponse(HttpStatusCode.OK );
        }

        //GET api/values/5

        [Route("api/FilesDataController/UploadFile")]
        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                try
                {
                    foreach (var fileName in HttpContext.Current.Request.Files.AllKeys)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[fileName];
                        //string base64ImageRepresentation = Convert.ToBase64String(file);
                        //HttpPostedFileBase filee = Convert.ToBase64String(file);

                        if (file != null)
                        {
                            FileDTO fileDTO = new FileDTO();
                            fileDTO.FileActualName = file.FileName;
                            fileDTO.FileExt = Path.GetExtension(file.FileName);
                            fileDTO.ContentType = file.ContentType;
                            //Generate a unique name using Guid
                            fileDTO.FileUniqueName = Guid.NewGuid().ToString();
                            //Get physical path of our folder where we want to save images
                            var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                            var fileSavePath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);
                            file.SaveAs(fileSavePath);
                            byte[] imageArray = System.IO.File.ReadAllBytes(fileSavePath);
                            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                            byte[] bytes = Convert.FromBase64String(base64ImageRepresentation);

                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                var Imager = Image.FromStream(ms);
                            }














                            // Save the uploaded file to "UploadedFiles" folder
                            file.SaveAs(fileSavePath);
                            //file.SaveAs(fileSavePath);

                            EncDecHelper.EncryptFile(file.InputStream, fileSavePath);
                           
                            //Save File Meta data in Database

                            DummyDAL.SaveFileInDB(fileDTO);
                        }
                    }//end of foreach
                }
                catch (Exception ex)
                { }
            }//end of if count > 0
            var age = HttpContext.Current.Request["Age"];
        }
        [Route("api/FilesDataController/DownloadFile")]
        [HttpGet]
        public Object DownloadFile(String uniqueName)
        {
            //Physical Path of Root Folder
            var rootPath = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles");
            //Find File from DB against unique name
            var fileDTO = DummyDAL.GetFileByUniqueID(uniqueName);
            if (fileDTO != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var fileFullPath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);

                byte[] file = System.IO.File.ReadAllBytes(fileFullPath);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(file);
                //byte[] file = System.IO.File.ReadAllBytes(fileFullPath);
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(file);

                //byte[] file = EncDecHelper.DecryptFile(fileFullPath);
                response.Content = new ByteArrayContent(file);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                //String mimeType = MimeType.GetMimeType(file); //You may do your hard coding here based on file extension
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(fileDTO.ContentType);// obj.DocumentName.Substring(obj.DocumentName.LastIndexOf(".") + 1, 3);
                response.Content.Headers.ContentDisposition.FileName = fileDTO.FileActualName;
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }

        }


        public static class EncDecHelper
        {
            private static string EncryptionKey = "MAKV2SPBNI99212";
            public static void EncryptFile(string inputFilePath, string outputfilePath)
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fsInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }

            public static void EncryptFile(Stream fsInput, string outputfilePath)
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (fsInput)
                            {
                                int data;
                                while ((data = fsInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }

            public static void DecryptFile(string inputFilePath, string outputfilePath)
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                            {
                                int data;
                                while ((data = cs.ReadByte()) != -1)
                                {
                                    fsOutput.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }

            public static byte[] DecryptFile(string inputFilePath)
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            MemoryStream ms = new MemoryStream();
                            cs.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }

                return null;
            }

        }




        [Route("api/FilesDataController/UploadFileNew")]
        [HttpPost]
        public void UploadFileNew()
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                try
                {
                    foreach (var fileName in HttpContext.Current.Request.Files.AllKeys)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[fileName];
                        //string base64ImageRepresentation = Convert.ToBase64String(file);
                        //HttpPostedFileBase filee = Convert.ToBase64String(file);

                        if (file != null)
                        {
                            FileDTO fileDTO = new FileDTO();
                            fileDTO.FileActualName = file.FileName;
                            fileDTO.FileExt = Path.GetExtension(file.FileName);
                            fileDTO.ContentType = file.ContentType;
                            //Generate a unique name using Guid
                            fileDTO.FileUniqueName = Guid.NewGuid().ToString();
                            //Get physical path of our folder where we want to save images
                            var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                            var fileSavePath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);
                            file.SaveAs(fileSavePath);
                        
                             
                        }
                    }//end of foreach
                }
                catch (Exception ex)
                { }
            }//end of if count > 0
            var age = HttpContext.Current.Request["Age"];
        }

    }
}
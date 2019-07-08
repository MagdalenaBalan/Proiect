using ISA_TWAAOS.Models.ViewModel;
using ISA_TWAAOS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using ISA_TWAAOS.Utils;

namespace ISA_TWAAOS.BussinesLogic
{
    public class FileLogic
    {



        public FileWriteResponse WriteFileToDisk(string fileBase64, string fileName)
        {
            FileWriteResponse response = new FileWriteResponse();
            try
            {
                if (!FileExist(fileName))
                {
                    var pathLocation = HttpContext.Current.Server.MapPath(Utils.GetAppSettings.GetAttachmentDirectoryPath());
                    string fileLocation = Path.Combine(pathLocation, fileName);
                    //fileBase64 = fileBase64.Substring(fileBase64.IndexOf(",") + 1);
                    File.WriteAllBytes(fileLocation, Convert.FromBase64String(fileBase64));


                    response.Text = "File uploaded successfull!";

                }
                else
                {
                    throw new Exception("File already  exist!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("File can not be uploaded!");
            }

            return response;
        }
        public FileWriteResponse WriteFileToDisk(byte[] fileByteArray, string fileName)
        {
            FileWriteResponse response = new FileWriteResponse();
            try
            {
                if (!FileExist(fileName))
                {
                    var pathLocation = HttpContext.Current.Server.MapPath(Utils.GetAppSettings.GetAttachmentDirectoryPath());
                    string fileLocation = Path.Combine(pathLocation, fileName);
                    using (var fs = new FileStream(fileLocation, FileMode.Create, FileAccess.ReadWrite))
                    {
                        fs.Write(fileByteArray, 0, fileByteArray.Length);
                        // Set the stream position to the beginning of the file.
                        fs.Seek(0, SeekOrigin.Begin);

                    }


                    response.Text = "File uploaded successfull!";

                }
                else
                {
                    throw new Exception("File already  exist!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("File can not be uploaded!");
            }

            return response;
        }

        public FileReadResponse ReadFileFromDisk(string fileName)
        {
            FileReadResponse response = new FileReadResponse();

            try
            {
                if (FileExist(fileName))
                {
                    string path = HttpContext.Current.Server.MapPath(Utils.GetAppSettings.GetAttachmentDirectoryPath());
                 FileInfo[] fit = new DirectoryInfo(path).GetFiles(fileName);

                    response.Text = "File read successful!";
                    response.File = fit;
                }
                else
                {
                    throw new Exception("File not exist!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("File can not be read!");
            }


            return response;
        }


        public byte[] ReadFileBytesFromDisk(string path)
        {
            byte[] fileBytes = null;
            try
            {
                fileBytes = File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                throw new Exception("cannot read file", ex);
            }

            return fileBytes;
        }

        public string RemoveFile(string fileName)
        {
            try
            {
                if (FileExist(fileName))
                {
                    var path = HttpContext.Current.Server.MapPath(Utils.GetAppSettings.GetAttachmentDirectoryPath() + "/" + fileName);
                    File.Delete(path);
                    return "OK!";
                }

                throw new Exception("File not exist!");

            }
            catch (Exception ex)
            {
                throw new Exception("File can not be deleted!");
            }

        }

        public bool FileExist(string fileName)
        {
            try
            {
                var path = HttpContext.Current.Server.MapPath(Utils.GetAppSettings.GetAttachmentDirectoryPath() + "/" + fileName);
                if (File.Exists(path))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File not exist!");
            }

        }

      

    }
}
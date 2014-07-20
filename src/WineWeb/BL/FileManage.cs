using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WineWeb.BL
{
  static  public class Liu_FileV1
    {
      /// <summary>
        /// 三个参数的文件上传方法SaveFile
      /// </summary>
      /// <param name="UpFile"></param>
      /// <param name="ServerSavePath"></param>
      /// <param name="URL"></param>
      /// <returns></returns>
       public static string SaveFile(HttpPostedFileBase UpFile, string ServerSavePath,string URL)
        {
            string filePath = string.Empty;

            HttpPostedFileBase file = UpFile;
            if (file.ContentLength > 0 || !string.IsNullOrEmpty(file.FileName))
                    
            {
                //获取文件名
                string filename = Path.GetFileName(file.FileName);

                //判断文件是否存在
                string _filePath = Path.Combine(ServerSavePath, Path.GetFileName(file.FileName));
                string tempfileName = "";
                if (System.IO.File.Exists(_filePath))
                {
                    int counter = 2;
                    while (System.IO.File.Exists(_filePath))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = counter.ToString() + filename;
                        _filePath = Path.Combine(ServerSavePath, tempfileName);
                        counter++;
                    }
                    filePath = URL + tempfileName;
                }
                else
                {
                    filePath = URL + filename;
                }
                file.SaveAs(_filePath);
              
            }
            else
            {
              
            }
                return filePath;
            }
      
    }
}

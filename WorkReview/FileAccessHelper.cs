using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WorkReview
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {

            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);//appdataにフルパスを作成
            //"C:\Users\ユーザー名\AppData\Local\Packages\com.companyname.workreview_9zz4h110yvjzm\LocalState\product.db3"がフルパス
        }
    }
}

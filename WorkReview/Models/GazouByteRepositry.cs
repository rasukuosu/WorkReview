using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkReview.Models;

namespace WorkReview.Models
{
    public class GazouByteRepositry
    {
        string _gazoudbPath;
        public string GazouStatusMessage { get; set; }

        private SQLiteConnection gazouconn;

        public GazouByteRepositry(string gazoudbPath)
        {
            _gazoudbPath = gazoudbPath;
        }

        private void Init() //dbに接続後テーブル作成
        {
            if (gazouconn is not null)
                return;
            gazouconn = new SQLiteConnection(_gazoudbPath);

            gazouconn.CreateTable<GazouByte>();

        }

        public void AddNewGazouByte(string gazouName, byte[] gazouBinary, string gazouExtension)//画像データをDBへ挿入
        {
            ArgumentNullException.ThrowIfNull(gazouName, nameof(gazouExtension));
            ArgumentNullException.ThrowIfNull(gazouBinary, nameof(gazouBinary));
            ArgumentNullException.ThrowIfNull(gazouName, nameof(gazouName));
            int gazouResult = 0;
            try
            {
                Init();

                gazouResult = gazouconn.Insert(new GazouByte { GazouName = gazouName, GazouBinary = gazouBinary, GazouExtension = gazouExtension });
                Console.WriteLine($"Insert result: {gazouResult}");
                GazouStatusMessage = string.Format("{0} record(s) added (GazouName: {1})", gazouResult, gazouName);
            }
            catch (Exception ex)
            {
                GazouStatusMessage = string.Format("Failed to add {0}. Error: {1}", gazouName, ex.Message);
            }
        }
        public List<GazouByte> GetAllGazouBytes()//テーブルを取得
        {
            try
            {
                Init();
                return gazouconn.Table<GazouByte>().ToList();
            }
            catch (Exception ex)
            {
                GazouStatusMessage = string.Format("Failed to retrieve data .{0}", ex.Message);
            }
            return new List<GazouByte>();
        }


        

    }
}
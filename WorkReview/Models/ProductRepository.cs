using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WorkReview.Models;


namespace WorkReview.Models
{
    public class ProductRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        public ProductRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private  void Init() //Tabeleがすでに作成されていたらreturnを返すそうでなければ新たにTableを作成する
        {
            if (conn is not null)
                return;
            conn = new SQLiteConnection(_dbPath); //_dbPathのパスでsqlコネクションを新しくインスタンス作成

            conn.CreateTable<Product>();

        }
        public void AddNewProduct(string name)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));//name自体とname文字列をうけとりnullのときスローする
            int result = 0;
            try
            {
                Init();

                result = conn.Insert(new Product { Name = name });
                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }
        public List<Product> GetAllProducts()
        {
            try
            { 
                Init ();
                return conn.Table<Product>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Product>();
        }
    } 
}

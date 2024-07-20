using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReview.Models;
[Table("products")]
public class Product
{

    [PrimaryKey, AutoIncrement, MaxLength(250), Unique] //主キーと列を追加するたびにインクリメントをする、それぞれユニークな列値をとる 以下行
    public string Name { get; set; }
    [MaxLength(250), Unique]
    public string Author { get; set; }
   //[MaxLength(250), Unique]
    //public string Description { get; set; }
    
    ///[MaxLength(250), Unique]
    //public string WorksDirectory { get; set; }
}
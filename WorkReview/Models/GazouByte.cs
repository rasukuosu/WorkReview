using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit;

namespace WorkReview.Models;
[Table("gazouByte")]
public class GazouByte
{
[PrimaryKey, AutoIncrement]
public int Id { get; set; }
public string GazouName { get; set; }
public byte[] GazouBinary { get; set; } //画像のバイナリ用
public string GazouExtension { get; set; }

}

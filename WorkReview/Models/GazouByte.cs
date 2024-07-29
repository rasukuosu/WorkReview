using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkReview.Models;
[Table("gazouByte")]
public class GazouByte
{
[PrimaryKey, AutoIncrement]
public int Number { get; set; }
[MaxLength(10), Unique]
public string GazouName { get; set; }
[MaxLength(10), Unique]
public byte[] Content { get; set; }
}

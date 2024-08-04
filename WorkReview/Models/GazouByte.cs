﻿using SQLite;
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
public int Number { get; set; }
[MaxLength(10), Unique]
public string GazouName { get; set; }
[MaxLength(10), Unique]
public byte[] Content { get; set; } //画像のbitmap
[MaxLength(10), Unique]
public byte[] ContentBinary { get; set; } //画像のバイナリ用

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using WorkReview.Models;

namespace WorkReview.ViewModels;


public partial class MainviewModel: ObservableObject
{
///ここの変数にユーザーからMainViewを通して与えられてファイルのパスなどをいれる。またここの値をModelのGazouByteやRepositryに伝える
[ObservableProperty]
string GazouPath;
[ObservableProperty]
byte[] GazouBynary;
[ObservableProperty]
byte[] GazouBitmap;
}

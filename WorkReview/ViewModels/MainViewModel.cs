using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using WorkReview.Models;

namespace WorkReview.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private GazouByteRepositry _gazouByteRepositry;

        public MainViewModel()
        {
            _gazouByteRepositry = new GazouByteRepositry("gazouByte.db3");

                    
         }

        [ObservableProperty]
        public string gazouName;

        [ObservableProperty]
        public string gazouPath;
        [ObservableProperty]
        public byte[] gazouBinary;


    }
}

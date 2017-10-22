using Android.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace PlanilhaDoHugo.ViewModels
{
    public class EntryItemCollection<T> : ObservableCollection<T>
    {
        protected override event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            //Log.Debug("", e.PropertyName);
            base.OnPropertyChanged(e);
        }
    }
}

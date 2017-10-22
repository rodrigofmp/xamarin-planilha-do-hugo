using PlanilhaDoHugo.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;

namespace PlanilhaDoHugo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private int _arrivalTime;
        private int _lunchBreakTime;
        private int _lunchReturnTime;
        private int _goHomeTime;


        public int ArrivalTime {
            get
            {
                return _arrivalTime;
            }
            set
            {
                if (EntryList.Count == 0 && value > 0)
                {
                    _arrivalTime = value;
                    OnPropertyChanged(nameof(ArrivalTime));
                    AddEntryItem();
                }
            }
        }

        private void AddEntryItem()
        {
            EntryList.Add(new EntryItem(ArrivalTime, 0, "", "", false));
        }

        public int LunchBreakTime {
            get
            {
                return _lunchBreakTime;
            }
            set
            {
                _lunchBreakTime = value;
                OnPropertyChanged(nameof(LunchBreakTime));
            }
        }

        public int LunchReturnTime {
            get
            {
                return _lunchReturnTime;
            }
            set
            {
                _lunchReturnTime = value;
                OnPropertyChanged(nameof(LunchReturnTime));
            }
        }

        public int GoHomeTime {
            get
            {
                return _goHomeTime;
            }
            set
            {
                _goHomeTime = value;
                OnPropertyChanged(nameof(GoHomeTime));
            }
        }

        public ObservableCollection<EntryItem> EntryList { get; private set; }

        public MainPageViewModel()
        {
            EntryList = new ObservableCollection<EntryItem>();
        }

    }
}

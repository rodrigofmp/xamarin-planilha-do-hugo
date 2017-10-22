using System.Collections.ObjectModel;
using System;

namespace PlanilhaDoHugo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private TimeSpan _workTime;
        private TimeSpan _arrivalTime;
        private TimeSpan _lunchBreakTime;
        private TimeSpan _lunchReturnTime;
        private string _goHomeTime;

        public TimeSpan WorkTime
        {
            get
            {
                return _workTime;
            }
            set
            {
                _workTime = value;
                OnPropertyChanged(nameof(WorkTime));
                CalculateGoHomeTime();
            }
        }
        
        public TimeSpan ArrivalTime {
            get
            {
                return _arrivalTime;
            }
            set
            {
                _arrivalTime = value;
                OnPropertyChanged(nameof(ArrivalTime));
                CalculateGoHomeTime();
                AddEntryItem();
            }
        }

        private void AddEntryItem()
        {
            if (EntryList.Count == 0)
                EntryList.Add(new EntryItemViewModel(this, ArrivalTime.ToString(), ArrivalTime, "10000", "Descrição da Tarefa", false));
        }

        public EntryItemViewModel AddEntryItemFromChild(TimeSpan newTime)
        {
            EntryItemViewModel entryItemViewModel = new EntryItemViewModel(this, newTime.ToString(), newTime, "20000", "", false);
            EntryList.Add(entryItemViewModel);
            return entryItemViewModel;
        }

        public TimeSpan LunchBreakTime {
            get
            {
                return _lunchBreakTime;
            }
            set
            {
                _lunchBreakTime = value;
                OnPropertyChanged(nameof(LunchBreakTime));
                CalculateGoHomeTime();
            }
        }

        public TimeSpan LunchReturnTime {
            get
            {
                return _lunchReturnTime;
            }
            set
            { 
                _lunchReturnTime = value;
                OnPropertyChanged(nameof(LunchReturnTime));
                CalculateGoHomeTime();
            }
        }

        public string GoHomeTime {
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

        public ObservableCollection<EntryItemViewModel> EntryList { get; private set; }

        public MainPageViewModel()
        {
            EntryList = new ObservableCollection<EntryItemViewModel>();
            WorkTime = new TimeSpan(8, 30, 00);
            ArrivalTime = new TimeSpan(8, 00, 00);
            LunchBreakTime = new TimeSpan(12, 00, 00);
            LunchReturnTime = new TimeSpan(13, 30, 00);
        }
        
        private void CalculateGoHomeTime()
        {
            TimeSpan goHome = ArrivalTime + WorkTime + (LunchReturnTime - LunchBreakTime);            
            GoHomeTime = goHome.ToString();
        }

    }
}

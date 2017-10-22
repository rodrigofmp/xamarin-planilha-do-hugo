using System;
using System.Collections.Generic;
using System.Text;

namespace PlanilhaDoHugo.ViewModels
{
    public class EntryItemViewModel : BaseViewModel
    {
        private string _startTime;
        private TimeSpan _endTime;
        private string _task;
        private string _description;
        private string _hoursWorked;
        private bool _registered;

        public string StartTime {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        public TimeSpan EndTime {
            get
            {
                return _endTime;
            }
            set
            {
                // Allows to edit endTime only if next endTime is not edited
                if (NextEntryItemViewModel == null || !NextEntryItemViewModel.IsEndTimeDefined())
                { 
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                    CalculateWorkedHours();
                    
                    // endTime was definied and there is not next entry item
                    if (IsEndTimeDefined() && NextEntryItemViewModel == null)
                    {
                        NextEntryItemViewModel = MainPageViewModel?.AddEntryItemFromChild(EndTime);
                    }

                }
            }
        }

        public string Task {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }
        public string Description {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool Registered {
            get
            {
                return _registered;
            }
            set
            {
                _registered = value;
                OnPropertyChanged(nameof(Registered));
            }
        }

        public string HoursWorked
        {
            get
            {
                return _hoursWorked;
            }
            set
            {
                _hoursWorked = value;
                OnPropertyChanged(nameof(HoursWorked));
            }
        }

        public MainPageViewModel MainPageViewModel { get; private set; }
        public EntryItemViewModel NextEntryItemViewModel { get; private set; }

        public bool IsEndTimeDefined()
        {
            return ! EndTime.ToString().Equals(StartTime);
        }

        public EntryItemViewModel(MainPageViewModel mainPageViewModel, string startTime, TimeSpan endTime, string task, string description, bool registered)
        {
            MainPageViewModel = mainPageViewModel;
            StartTime = startTime;
            EndTime = endTime;
            Task = task;
            Description = description;
            Registered = registered;
        }

        private void CalculateWorkedHours()
        {
            TimeSpan tsHoursWorked = EndTime - TimeSpan.Parse(StartTime);
            HoursWorked = tsHoursWorked.ToString();
        }

        public bool EndTime_IsEnabled()
        {
            return false;
        }
    }
}

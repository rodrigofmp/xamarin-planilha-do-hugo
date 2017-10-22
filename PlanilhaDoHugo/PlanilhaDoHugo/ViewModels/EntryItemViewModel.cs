using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
        private bool _endTime_IsEnabled;

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
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
                CalculateWorkedHours();
                    
                // endTime was definied and there is not next entry item
                if (IsEndTimeDefined() && NextEntryItemViewModel == null)
                {
                    NextEntryItemViewModel = MainPageViewModel?.AddEntryItemFromChild(this, EndTime);
                    EndTime_IsEnabled = false;
                }

                if (NextEntryItemViewModel != null)
                {
                    if (!Registered)
                    {
                        NextEntryItemViewModel.StartTime = EndTime.ToString();
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
                EndTime_IsEnabled = !Registered;
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
        public EntryItemViewModel PriorEntryItemViewModel { get; private set; }

        public bool IsEndTimeDefined()
        {
            return ! EndTime.ToString().Equals(StartTime);
        }

        public EntryItemViewModel(MainPageViewModel mainPageViewModel, EntryItemViewModel priorEntryItemViewModel, string startTime, TimeSpan endTime, string task, string description, bool registered)
        {
            MainPageViewModel = mainPageViewModel;
            PriorEntryItemViewModel = priorEntryItemViewModel;
            StartTime = startTime;
            EndTime = endTime;
            Task = task;
            Description = description;
            Registered = registered;
            EndTime_IsEnabled = true;

            EraseCommand = new Command(ExecuteEraseCommand, CanExecuteEraseCommand);
        }

        private bool CanExecuteEraseCommand(object arg)
        {
            // Never erase first record
            if (PriorEntryItemViewModel == null)
            {
                return false;
            }

            // Don't allow remove if is registered
            if (Registered)
            {
                return false;
            }

            // If next is defined don't allow to remove
            if (NextEntryItemViewModel != null)
            {
                if (NextEntryItemViewModel.IsEndTimeDefined())
                {
                    return false;
                }
            }

            return true;
        }

        private void ExecuteEraseCommand(object obj)
        {
            PriorEntryItemViewModel.EndTime_IsEnabled = true;
            PriorEntryItemViewModel.NextEntryItemViewModel = null;
            MainPageViewModel.RemoveItem(this);
        }

        private void CalculateWorkedHours()
        {
            TimeSpan tsHoursWorked = EndTime - TimeSpan.Parse(StartTime);
            HoursWorked = tsHoursWorked.ToString();
        }

        public bool EndTime_IsEnabled
        {
            get
            {
                return _endTime_IsEnabled;
            }
            set
            {
                _endTime_IsEnabled = value;
                OnPropertyChanged(nameof(EndTime_IsEnabled));
            }
        }

        public Command EraseCommand { get; private set; }
    }
}

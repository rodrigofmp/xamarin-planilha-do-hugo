using System;
using System.Collections.Generic;
using System.Text;

namespace PlanilhaDoHugo.Model
{
    public class EntryItem
    {
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }
        public string Task { get; }
        public string Description { get; }
        public bool Registered { get; }

        public EntryItem(TimeSpan startTime, TimeSpan endTime, string task, string description, bool registered)
        {
            StartTime = startTime;
            EndTime = endTime;
            Task = task;
            Description = description;
            Registered = registered;
        }
    }
}

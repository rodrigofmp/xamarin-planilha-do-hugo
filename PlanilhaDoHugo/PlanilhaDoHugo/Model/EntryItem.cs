using System;
using System.Collections.Generic;
using System.Text;

namespace PlanilhaDoHugo.Model
{
    public class EntryItem
    {
        public int StartTime { get; }
        public int EndTime { get; }
        public string Task { get; }
        public string Description { get; }
        public bool Registered { get; }

        public EntryItem(int startTime, int endTime, string task, string description, bool registered)
        {
            StartTime = startTime;
            EndTime = endTime;
            Task = task;
            Description = description;
            Registered = registered;
        }
    }
}

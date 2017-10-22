using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PlanilhaDoHugo
{
    /// <summary>
    /// Based on ThatCSharpGuy implementation:
    /// https://github.com/ThatCSharpGuy/FormattedNumberEntry/blob/master/FormattedNumberEntry.cs
    /// </summary>
    public class TimeEntry : Entry
    {
        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(int), typeof(TimeEntry), 0);

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public bool ShouldReactToTextChanges { get; set; }

        public TimeEntry()
        {
            ShouldReactToTextChanges = true;
        }

        public static int DumbParse(string input)
        {
            if (input == null) return 0;

            var number = 0;
            int multiply = 1;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(input[i]))
                {
                    number += (input[i] - '0') * (multiply);
                    multiply *= 10;
                }
            }
            return number;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (nameof(this.Text).Equals(propertyName))
            {
                if (!ShouldReactToTextChanges) return;

                ShouldReactToTextChanges = false;

                var oldText = this.Text;
                var number = DumbParse(oldText);
                var newText = $"{number:##:##}";

                this.Text = newText;

                ShouldReactToTextChanges = true;
            }
            base.OnPropertyChanged(propertyName);
        }
    }
}

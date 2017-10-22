using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PlanilhaDoHugo;
using PlanilhaDoHugo.Droid;
using Android.Text;
using System;

[assembly: ExportRenderer(typeof(TimeEntry), typeof(TimeEntryRenderer))]
namespace PlanilhaDoHugo.Droid
{
    class TimeEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                Control.AfterTextChanged -= Control_AfterTextChanged;
            }
            if (e.NewElement != null)
            {
                Control.AfterTextChanged += Control_AfterTextChanged;
            }
        }

        private void Control_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            var element = ((TimeEntry)Element);

            // 1. Stop listening for changes on our control Text property
            if (!element.ShouldReactToTextChanges) return;
            element.ShouldReactToTextChanges = false;

            // 2. Get the current cursor position
            var cursorPosition = Control.SelectionStart;

            // 3. Take the control’s text, lets name it oldText
            var oldText = Control.Text;

            // 4. Parse oldText into a number, lets name it number
            var number = TimeEntry.DumbParse(oldText);

            // 5. Format number, and place the formatted text in newText
            var newText = $"{number:##:##}";

            // 6. Set the Text property of our control to newText
            Control.Text = newText;

            // 7. Calculate the new cursor position
            var change = oldText.Length - newText.Length;

            // 8. Set the new cursor position
            Control.SetSelection(cursorPosition - change);

            // 9. Start listening for changes on our control’s Text property
            element.ShouldReactToTextChanges = true;
        }
    }
}
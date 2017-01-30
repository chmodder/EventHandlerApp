using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace EventHandlerApp.Common
{
    public static class MessageBox
    {
        public static async void Show(string content, string title)
        {
            ContentDialog messageDialog = new ContentDialog
            {
                Content = content,
                Title = title,
                PrimaryButtonText = "Close"
            };
            messageDialog.Hide();

            await messageDialog.ShowAsync();
            
        }

        public static async Task<int> Confirm(string content, string title)
        {
            //Source:
            //http://www.reflectionit.nl/blog/2015/windows-10-xaml-tips-messagedialog-and-contentdialog

            var yesCommand = new UICommand("Delete Event") { Id = 0 };
            var noCommand = new UICommand("Cancel") { Id = 1 };


            MessageDialog confirmationDialog = new MessageDialog(content,title);

            confirmationDialog.Commands.Add(yesCommand);
            confirmationDialog.Commands.Add(noCommand);

            confirmationDialog.DefaultCommandIndex = 1;
            confirmationDialog.CancelCommandIndex = 1;
            var result = await confirmationDialog.ShowAsync();
            return Int32.Parse(result.Id.ToString());
            //var btn = sender as Button;
            //btn.Content = $"Result: {result.Label} ({result.Id})";

        }

    }
}

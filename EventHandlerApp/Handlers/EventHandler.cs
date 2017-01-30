using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using EventHandlerApp.Common;
using EventHandlerApp.Converters;
using EventHandlerApp.Model;
using EventHandlerApp.Persistency;
using EventHandlerApp.Validation;
using EventHandlerApp.View;
using EventHandlerApp.ViewModel;

namespace EventHandlerApp.Handlers
{
    public class EventHandler
    {
        private EventViewModel ViewModel { get; set; }

        public EventHandler(EventViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public async Task CreateEventAsync()
        {
            //Should maybe check if list contains an item with the same Id property

            CustomValidation validatonService = new CustomValidation();
            //bool isValidInput = validatonService.IsValidInput(ViewModel.Id, ViewModel.Name, ViewModel.Description, ViewModel.Place);
            //string validationMessage = validatonService.ErrorMessagesToString().ToString();
            await ViewModel.EventCatalogSingleton.Add(ViewModel.Id, ViewModel.Name, ViewModel.Description, ViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel.Date, ViewModel.Time));

            //if (isValidInput)
            //{
            //    await ViewModel.EventCatalogSingleton.Add(ViewModel.Id, ViewModel.Name, ViewModel.Description, ViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel.Date, ViewModel.Time));

            //}
            //else
            //{

            //    MessageBox.Show(validationMessage,"Please check your input");
            //}

        }

        public async Task DeleteEventAsync()
        {

            if (ViewModel.SelectedEvent != null)
            {
                int result = await MessageBox.Confirm("Click \"Delete Event\" to procees, or CANCEL to abort", "Warning: You are about to DELETE the selected event!");

                if (result == 0)
                {
                    await ViewModel.EventCatalogSingleton.Remove(ViewModel.SelectedEvent);
                }

            }
            else
            {
                MessageBox.Show("", "No items selected");
            }
        }
    }
}

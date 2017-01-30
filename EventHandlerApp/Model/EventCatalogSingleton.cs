using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using Windows.ApplicationModel;
using EventHandlerApp.Common;
using EventHandlerApp.Persistency;
using WinUX.Extensions;

namespace EventHandlerApp.Model
{
    public sealed class EventCatalogSingleton
    {
        public ObservableCollection<Event> Events { get; set; }

        public static EventCatalogSingleton Instance { get; } = new EventCatalogSingleton();

        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            List<Event> tempEvents = new List<Event>(PersistencyService.LoadEventsFromJsonAsync().Result);
            Events = new ObservableCollection<Event>(tempEvents);
        }

        public async Task Add(int id, string name, string place, string description, DateTime dateTime)
        {
            Events.Add(new Event(id, name, place, description, dateTime));

            try
            {
                await PersistencyService.SaveEventsAsJsonAsync(this.Events);
                MessageBox.Show("", "Event created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public async Task Remove(Event selectedEvent)
        {
            Events.Remove(selectedEvent);

            try
            {
                await PersistencyService.SaveEventsAsJsonAsync(this.Events);
                MessageBox.Show("", "Event deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }
        }
    }
}

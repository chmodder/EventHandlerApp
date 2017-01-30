using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using EventHandlerApp.Common;
using EventHandlerApp.Model;
using Newtonsoft.Json;

namespace EventHandlerApp.Persistency
{
    class PersistencyService
    {

        //Notice: NuGet - Json.Net from Newtonsoft is installed, provides: JsonConvert 

        private static string eventFileName = "EventsAsJson.dat";


        public static async Task SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            try
            {
                string eventsJsonString = JsonConvert.SerializeObject(events);
                await SerializeEventsFileAsync(eventsJsonString, eventFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save the Event in file!");
            }
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;
        }


        public static async Task SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"File of Events not found! - Loading for the first time? \n {ex.FileName}", "File not found!");
                return null;
            }
        }
    }
}

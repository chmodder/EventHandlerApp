using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerApp.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Place { get; set; }
        public DateTime TheDateTime { get; set; }


        public Event(int id, string name, string description, string place, DateTime dateTime)
        {
            Id = id;
            Name = name;
            Description = description;
            Place = place;
            TheDateTime = dateTime;
        }



        #region Overrides of Object

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}, Description: {Description} Place: {Place} DateTime: {TheDateTime}";
        }

        #endregion
    }
}

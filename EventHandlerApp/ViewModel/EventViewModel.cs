using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventHandlerApp.Annotations;
using EventHandlerApp.Common;
using EventHandlerApp.Model;

namespace EventHandlerApp.ViewModel
{
    public sealed class EventViewModel : INotifyPropertyChanged
    {
        public EventCatalogSingleton EventCatalogSingleton { get; set; }
        public Handlers.EventHandler EventHandler { get; set; }

        //private string _notification;
        //private ICommand _deleteEventCommand;

        //public string Notification
        //{
        //    get { return _notification; }
        //    set { _notification = value; OnPropertyChanged(nameof(Notification)); }
        //}

        #region EventProperties  
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public DateTimeOffset Date { get; set; }

        //public TimeSpan Time { get; set; }

        private TimeSpan _time;
        /// <summary>
        /// activate and test numberconverter or delete this property
        /// </summary>
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                if (value != _time)
                {
                    _time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }


        public Event SelectedEvent { get; set; }

        private bool _isInValidDescription;

        public bool IsInValidDescription
        {
            get { return _isInValidDescription; }
            set
            {
                if (value != _isInValidDescription)
                {
                    _isInValidDescription = value;
                    OnPropertyChanged(nameof(IsInValidDescription));
                    OnPropertyChanged(nameof(IsValidAll));

                }
            }
        }

        private bool _isInValidPlace;

        public bool IsInValidPlace
        {
            get { return _isInValidPlace; }
            set
            {
                if (value != _isInValidPlace)
                {
                    _isInValidPlace = value;
                    OnPropertyChanged(nameof(IsInValidPlace));
                    OnPropertyChanged(nameof(IsValidAll));

                }
            }
        }

        private bool _isInValidName;

        public bool IsInValidName
        {
            get { return _isInValidName; }
            set
            {
                if (value != _isInValidName)
                {
                    _isInValidName = value;
                    OnPropertyChanged(nameof(IsInValidName));
                    OnPropertyChanged(nameof(IsValidAll));

                }
            }
        }

        private bool _isInValidId;

        public bool IsInValidId
        {
            get { return _isInValidId; }
            set
            {
                if (value != _isInValidId)
                {
                    _isInValidId = value;
                    OnPropertyChanged(nameof(IsInValidId));
                    OnPropertyChanged(nameof(IsValidAll));

                }
            }
        }

        private bool _isValidAll;

        public bool IsValidAll
        {
            get
            {
                if ((IsInValidDescription == false) && (IsInValidPlace == false) && (IsInValidName == false) && (IsInValidId == false))
                {
                    _isValidAll = true;
                }
                else
                {
                    _isValidAll = false;
                }
                return _isValidAll;
            }
            private set
            {
                _isValidAll = value;
                OnPropertyChanged(nameof(IsValidAll));
            }
        }

        #endregion

        #region Constructors
        public EventViewModel()
        {
            EventCatalogSingleton = EventCatalogSingleton.Instance;


            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            EventHandler = new Handlers.EventHandler(this);
            //CreateEventCommand = new RelayCommand(EventHandler.CreateEventAsync);
            //DeleteEventCommand = new RelayCommand(EventHandler.DeleteEventAsync);
        }


        #endregion

        #region ICommand
        //public ICommand CreateEventCommand { get; set; }
        //public ICommand DeleteEventCommand { get; set; }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;


namespace EventHandlerApp.Validation

{
    public class CustomValidation
    {
        #region Instance Fields
        private List<bool> _isValidatedList;
        private List<string> _errorMessageList;
        #endregion

        public CustomValidation()
        {
            _isValidatedList = new List<bool>();

            _errorMessageList = new List<string>();
        }

        #region public methods

        public bool IsValidInput(
            int id,
            string name,
            string description,
            string place
            )
        {
            //Return value default is set
            bool result = true;



            //Adds items to validationlist before validation
            IsValidatedList.Add(CheckName(name));
            IsValidatedList.Add(CheckPlace(place));
            IsValidatedList.Add(CheckDescription(description));
            IsValidatedList.Add(CheckId(id));
            
            //if all IndividualSubscription properties er true set all, then result is set to true, which means the user input is valid
            foreach (bool b in _isValidatedList)
            {
                if (b == false)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public StringBuilder ErrorMessagesToString()
        {
            //Creates the string which should contain all items in the ErrorMessageList
            StringBuilder errorMessageString = new StringBuilder();


            //If the ErrormessageList has items make a long string of all the errors with each item on a new line (by using "\n")
            if (ErrorMessageList.Count() != 0)
            {
                int lastItem = ErrorMessageList.Count() - 1;


                for (int i = 0; i < ErrorMessageList.Count(); i++)
                {
                    //Adds an item to the string
                    errorMessageString.Append(ErrorMessageList[i]);
                    //adds comma separation between each item. If it is the last item in the list, then a period is added.
                    errorMessageString.Append(i != lastItem ? ",\n " : ".");
                }
            }
            return errorMessageString;
        }
        #endregion

        #region private methods

        #region dev info
        //A thought: this could maybe be refactored to have only one "checkItem" method with 2 parameters:
        //- object parameter for the object that needs checking
        //- rule parameter. eg. email which then import the email rules from another class called ValidationRules


        #endregion

        //ValidationRules
        private bool CheckName(string name)
        {
            //check if input is null or empty
            if (name == null)
            {
                _errorMessageList.Add("The Event must have a name");
                return false;
            }

            //Check if input match validation rules for Name
            //if Name is validated flag true
            //else flag false
            bool isNameLengthMin = name.Length >= 2 && name.Length != 0;


            //Adds an errormessage to the list if name rules does not match input
            if (!isNameLengthMin)
            {
                _errorMessageList.Add("The name is too short");
            }
            return isNameLengthMin;
        }

        private bool CheckPlace(string place)
        {
            if (place == null)
            {
                _errorMessageList.Add("The Place field is empty");
                return false;
            }

            //Check if input match validation rules for Address
            //if Name is validated flag true
            //else flag false
            bool isplaceLengthMin = place.Length >= 2 && place.Length != 0;


            //Adds an errormessage to the list if name rules does not match input
            if (!isplaceLengthMin)
            {
                _errorMessageList.Add("Place name is too short");
            }
            return isplaceLengthMin;
        }

        private bool CheckDescription(string description)
        {
            if (description == null)
            {
                _errorMessageList.Add("Description field is empty");
                return false;
            }
            bool isDescriptionMinLenght = description.Length >= 2 && description.Length != 0;


            //Adds an errormessage to the list if name rules does not match input
            if (!isDescriptionMinLenght)
            {
                _errorMessageList.Add("Description is too short");
            }
            return isDescriptionMinLenght;

        }

        private bool CheckId(int number)
        {
            if (number < 0)
            {
                _errorMessageList.Add("Phone number is a negative number");
                return false;
            }

            return true;
        }


        #endregion

        #region properties


        private List<string> ErrorMessageList { get { return _errorMessageList; } set { _errorMessageList = value; } }


        private List<bool> IsValidatedList { get { return _isValidatedList; } set { _isValidatedList = value; } }
        #endregion




    }
}

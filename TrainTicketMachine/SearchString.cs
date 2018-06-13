using System.Text.RegularExpressions;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine
{
    public class SearchString : ISearchString
    {
        private string _value;
        public SearchString(string searchString)
        {
            _value = searchString;
            Validate();
        }

        public string Value
        {
            get { return _value; }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value;  }
        }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid;  }
            set { _isValid = value; }
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                _isValid = false;
                _error = "Input is not valid";
            }
            else
            {
                Regex r = new Regex("^[a-zA-Z]*$");
                if (r.IsMatch(Value))
                {
                    _isValid = true;
                }
                else
                {
                    _isValid = false;
                    _error = "only Letters are expected";
                }
            }
            return _isValid;
        }
    }
}

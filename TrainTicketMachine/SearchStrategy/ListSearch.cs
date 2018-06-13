using System;
using System.Collections.Generic;
using System.Text;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine
{
    public class ListSearch : SearchStrategy, ISearchStation
    {
        IStationReader _stationReader;
        ISearchString _searchString;
        public ListSearch(IStationReader stationReader, ISearchString searchString)
        {
            _stationReader = stationReader;
            _searchString = searchString;

            _filteredStations = new List<string>();
        }
        private bool IsSearchPerformed { get; set; }

        private List<string> _filteredStations;
        public virtual List<string> FilteredStations
        {
            get { return _filteredStations; }
            set { _filteredStations = value; }
        }

        public string AllowedCharacters { get; set; }
        
        public override void Search()
        {
            var nextAllowedCharacters = new StringBuilder();
            var delimeter = ",";
            if (_searchString.IsValid)
            {
                foreach (var station in _stationReader.AllStations)
                {
                    if (station.StartsWith(_searchString.Value))
                    {
                        FilteredStations.Add(station);

                        if (station.Length > _searchString.Value.Length)
                        {
                            nextAllowedCharacters.Append(station.Substring(_searchString.Value.Length, 1));
                            nextAllowedCharacters.Append(delimeter);
                        }
                    }
                }
                this.AllowedCharacters = nextAllowedCharacters.ToString().TrimEnd(',');
                IsSearchPerformed = true;
            }
        }

        public List<string> GetFilteredStations()
        {
            return this.FilteredStations;
        }

        public string GetAllowedCharacters()
        {
            return this.AllowedCharacters;
        }

        public Tuple<List<string>, string> ReturnStationAndValidCharacters()
        {
            if (!IsSearchPerformed)
            {
                throw new InvalidOperationException("Search is not performed yet, No Results to return");
            }

            var validStations = GetFilteredStations();
            var validCharacters = GetAllowedCharacters();

            return Tuple.Create(validStations, validCharacters);
        }
    }
}

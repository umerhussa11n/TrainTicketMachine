using System;
using System.Collections.Generic;
using System.Linq;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine
{
    public class LinqSearch : SearchStrategy
    {
        ISearchString _searchString;
        IStationReader _stationReader;
        public LinqSearch(IStationReader stationReader, ISearchString searchString)
        {
            _searchString = searchString;
            _stationReader = stationReader;
        }

        public Tuple<List<string>, string> SearchResult { get; set; }

        private bool IsSearchPerformed { get; set; }

        public override void Search()
        {
            var searchStringLength = _searchString.Value.Length;
            var filteredStations = _stationReader.AllStations.Where(s => s.StartsWith(_searchString.Value));
            var NextCharacters = filteredStations.Where(x => x.Length != searchStringLength).Select(x => x.Substring(searchStringLength, 1)).ToList();
            var strNextCharacters = string.Join(",", NextCharacters.ToArray());

            SearchResult = Tuple.Create(filteredStations.ToList(), strNextCharacters);
            IsSearchPerformed = true;
        }

        public Tuple<List<string>, string> ReturnStationAndValidCharacters()
        {
            if (IsSearchPerformed)
                return SearchResult;
            else
                throw new InvalidOperationException();
        }
    }
}

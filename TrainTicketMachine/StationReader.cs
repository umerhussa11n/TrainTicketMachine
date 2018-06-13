using System;
using System.Collections.Generic;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine
{
    public class StationReader : IStationReader
    {
        public List<string> _allStations;
        public List<string> AllStations
        {
            get { return _allStations; }
            set { _allStations = value;  }
        }
        public List<string> Read()
        {
            throw new NotImplementedException();
        }
    }
}

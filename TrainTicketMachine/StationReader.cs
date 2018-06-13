using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine
{
    public class StationReader : IStationReader
    {
        public List<string> _allStations;
        public List<string> AllStations
        {
            get { return _allStations; }
            set { _allStations = value; }
        }
        public List<string> Read()
        {
            List<string> AllStations = new List<string>();
            var path = ConfigurationManager.AppSettings["StationListXMLLocation"];

            XElement root = XElement.Load(path);
            _allStations = root.Descendants("Station").Select(x => x.Value).ToList();
            return AllStations;
        }
    }
}

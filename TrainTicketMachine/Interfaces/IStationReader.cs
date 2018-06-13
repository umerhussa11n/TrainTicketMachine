using System.Collections.Generic;

namespace TrainTicketMachine.Interfaces
{
    public interface IStationReader
    { 
        List<string> AllStations
        {
            get;
            set;
        }
        List<string> Read();
    }
}

using System;
using System.Collections.Generic;

namespace TrainTicketMachine.Interfaces
{
    public interface ISearchStation
    {
        void Search();

        Tuple<List<string>, string> ReturnStationAndValidCharacters();
    }
}



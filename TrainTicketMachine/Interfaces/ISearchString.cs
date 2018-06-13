namespace TrainTicketMachine.Interfaces
{
    public interface ISearchString
    {
         string Value { get; }

         string Error { get; }

         bool IsValid { get; }

         bool Validate();


    }
}

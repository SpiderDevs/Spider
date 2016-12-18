namespace Spider.App.Interfaces
{
    public interface IFault
    {
        string ShortMessage { get; set; }

        string LongMessage { get; set; }
    }
}
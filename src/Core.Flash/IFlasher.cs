namespace Core.Flash2
{
    public interface IFlasher
    {
        void Flash(string type, string message, bool dismissable = false);
    }
}

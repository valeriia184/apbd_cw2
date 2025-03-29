namespace apbd_cw2
{
    public interface IHazardNotifier
    {
        void NotifyHazard(string message, string containerNumber);
    }
}
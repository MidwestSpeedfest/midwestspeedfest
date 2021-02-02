namespace MWSFBlazorDemo.Data.DummyDataAccess
{
    public interface IDummyDataAccess
    {
        string headline { get; set; }
        string details { get; set; }
        bool showLogo { get; set; }
        bool showCountdown { get; set; }
        string countDownTitle { get; set; }
        bool showAdminMenu { get; set; }
    }
}
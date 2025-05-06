using FlaUI.Core.Input;
using FlaUIPoC.Reapit.Window.MainLoginWindow;
using FlaUIPoC.Base;
using static AutomationHelper;

public class BaseSetup
{
    public ApplicationLaunchSetUp App { get; private set; }

    public MainBaseWindow MainWindow { get; private set; }
    private DateTime startTime;
    private DateTime endTime;

    [SetUp]
    public void Setup()
    {
        startTime = DateTime.Now;
        Console.WriteLine("Test start time : " + startTime);
        App = new ApplicationLaunchSetUp();
        App.Init();

        // Create main login window
        MainWindow = new MainBaseWindow(App);
        Wait.UntilResponsive(MainWindow.Window);
        MaximiseWindow();
        Thread.Sleep(50);
    }

    [TearDown]
    public void TearDown()
    {
        App?.Cleanup();
        endTime = DateTime.Now;
        Console.WriteLine("Test endTime :" + endTime);
        var duration = endTime - startTime;
        Console.WriteLine("Total test duration  :" + duration);
    }

    private void MaximiseWindow()
    {
        AutomationHelper.ClickButton(MainWindow.Window, IdentifyElement.byId, "btnMaximise");
    }
}

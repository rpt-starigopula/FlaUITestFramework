using FlaUI.Core.Input;
using FlaUIPoC.Reapit.Window.MainLoginWindow;
using FlaUIPoC.Base;
using FlaUIPoC.Reapit.Window.MainLoginWindow;
using static AutomationHelper;

public class BaseSetup
{
    public ApplicationLaunchSetUp App { get; private set; }

    public MainBaseWindow MainWindow { get; private set; }

    [SetUp]
    public void Setup()
    {
        App = new ApplicationLaunchSetUp();
        App.Init();

        // Create main login window
        MainWindow = new MainBaseWindow(App);
        Wait.UntilResponsive(MainWindow.Window);
        MaximiseWindow();
    }

    [TearDown]
    public void TearDown()
    {
        // App?.Cleanup();
    }

    private void MaximiseWindow()
    {
        AutomationHelper.ClickButton(MainWindow.Window, IdentifyElement.byId, "btnMaximise");
    }
}

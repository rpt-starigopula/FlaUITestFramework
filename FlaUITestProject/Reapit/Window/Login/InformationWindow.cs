using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.Login
{
    public class InformationWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _informationWindow;

        public InformationWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _informationWindow = window.FindFirstDescendant(cf => cf.ByName("Reapit"));
            Assume.That(_informationWindow, Is.Not.Null);
        }

        public void AssertMessageDetailsAndAccept(string expectedMessage)
        {
            var actualMessage = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "tbkMessage");
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            ClickOk();
        }

        public void ClickOk()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "btnOk");
        }
    }
}

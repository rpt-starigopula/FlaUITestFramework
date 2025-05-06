using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;
namespace FlaUIPoC.Reapit.Window.Applicant
{
    public class ApplicantWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _applicantWindow;
        public ApplicantWindow(FlaUI.Core.AutomationElements.Window window)
        {
           Wait.UntilResponsive(window);
           _window = window;
           _applicantWindow = window.FindFirstDescendant(cf => cf.ByAutomationId("appControl"));
           Assume.That(_applicantWindow, Is.Not.Null);
        }
        public void CheckMatchButtonExists()
        {
            Assert.IsTrue(AutomationHelper.IsElementEnabled(_window, IdentifyElement.byId, "aid_btnMatch"));
        }
    }

}
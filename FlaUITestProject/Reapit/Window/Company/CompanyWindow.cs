using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.Company
{
    public class CompanyWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _companyWindow;

        public CompanyWindow(FlaUI.Core.AutomationElements.Window window)
        { 
            Wait.UntilResponsive(window);
            _window = window;
            _companyWindow = window.FindFirstDescendant(cf => cf.ByName("Company Details"));
            Assume.That(_companyWindow, Is.Not.Null);
        }
        public void CheckDocumentButtonExists()
        {
           Assert.IsTrue(AutomationHelper.IsElementEnabled(_window, IdentifyElement.byId, "aid_btnDocs"));
        }
    }
}
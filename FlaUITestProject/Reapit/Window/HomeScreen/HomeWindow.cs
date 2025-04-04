using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using NUnit.Framework.Constraints;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.Login
{
    public class HomeWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _homeScreenWindow;

        public HomeWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _homeScreenWindow = window.FindFirstDescendant(cf => cf.ByName("Reapit - rps_demo"));
            Assume.That(_homeScreenWindow, Is.Not.Null);
        }

        public void ClickMainMenuItem(string menuItemName)
        {
            switch (menuItemName)
            {
                case "Organiser":
                    break;
                case "Dairy":
                    break;
                case "Applicant":
                    break;
                case "Property":
                    break;
                case "Lettings":
                    break;
                case "Block":
                    AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnEstate");
                    break;
                case "Contact":
                    AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnContacts");
                    break;
                case "Company":
                    break;
                case "Reports":
                    AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnReports");
                    break;
                default:
                    new ArgumentOutOfRangeException("Menu item not found!");
                    break;
            }
        }

        public void ClickCloseButton()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnClose");
        }
    }
}

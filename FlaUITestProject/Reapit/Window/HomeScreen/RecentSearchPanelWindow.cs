using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.HomeScreen
{
    public class RecentSearchPanelWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _recentSearchPanelWindow;
        public RecentSearchPanelWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _recentSearchPanelWindow = window.FindFirstDescendant(cf => cf.ByAutomationId("recentPanel"));
            Assume.That(_recentSearchPanelWindow, Is.Not.Null);
            _window.Focus();
        }

        public void EnterTextAndSearch(string text)
        {
            Keyboard.Type(text);
            Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
        }

        public void ClickAddContact()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnAdd");
        }

        public void ClickOnRecentContact()
        {
            AutomationHelper.MoveMouseToElementAndLeftClick(_window, IdentifyElement.byId, "aid_txtActivityDetail_Contact_0");
            //AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_txtActivityDetail_Contact_0");            
        }

        public void CheckRecentRecordInSearchPanelIs(string expectedName)
        {
            var getRecentContactNameFromSearchPanel = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "aid_txtActivityDetail_Contact_0");
            Assert.IsTrue(string.Equals(getRecentContactNameFromSearchPanel, expectedName, StringComparison.OrdinalIgnoreCase));
        }

        public void ClickSubMenuItem(string subMenuItem)
        {
            string autoIdValue = "";
            switch (subMenuItem.ToLower())
            {
                case "mi analysis":
                    autoIdValue = "aid_tvi_expander_MI_Analysis";
                    break;
                case "offers & pipeline reports":
                    autoIdValue = "aid_tvi_expander_Offers_&_Pipeline_Reports";
                    break;
                default:
                    Console.WriteLine($"Please cross check the submenu entered: {subMenuItem}, its not found");
                    throw new Exception();
            }
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, autoIdValue);
        }
    }
}

using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.Contact
{
    public class AddingNewContactDialogueWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _addingNewContactDialogueWindow;

        public AddingNewContactDialogueWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _addingNewContactDialogueWindow = window.FindFirstDescendant(cf => cf.ByName("Adding new Contact"));
            Assume.That(_addingNewContactDialogueWindow, Is.Not.Null);
        }

        public void EnterTheSearchDetails(string searchDetails)
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "txtPhone", searchDetails);
            Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.TAB);
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnSearch");
        }
    }
}

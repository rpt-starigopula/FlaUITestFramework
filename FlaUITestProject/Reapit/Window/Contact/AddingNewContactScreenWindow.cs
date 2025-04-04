using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.Contact
{
    public class AddingNewContactWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _addingNewContactScreenWindow;
        public AddingNewContactWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _addingNewContactScreenWindow = window.FindFirstDescendant(cf => cf.ByName("Contact Screen"));
            Assume.That(_addingNewContactScreenWindow, Is.Not.Null);
        }

        public void CheckTheMobileNumber(string expectedMobileNumber)
        {
            var mobileNumberFromApp = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "aid_btnDetail_Mobile");
            Assert.That(mobileNumberFromApp, Is.EqualTo(expectedMobileNumber));
        }

        public void CheckingSurname(string expectedSurname)
        {
            var surnameFromApp = AutomationHelper.GetText(_window, IdentifyElement.byId, "aid_txtSurname");
            Assert.IsTrue(string.Equals(surnameFromApp, expectedSurname, StringComparison.OrdinalIgnoreCase));
        }

        public void CheckingFirstName(string expectedFirstname)
        {
            var firstNameFromApp = AutomationHelper.GetText(_window, IdentifyElement.byId, "aid_txtInitials");
            Assert.IsTrue(string.Equals(firstNameFromApp, expectedFirstname, StringComparison.OrdinalIgnoreCase));
        }

        public void CheckingEmailAddress(string expectedEmailAddress)
        {
            var emailAddressFromApp = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "aid_btnDetail_E-mail");
            Assert.IsTrue(string.Equals(emailAddressFromApp, expectedEmailAddress, StringComparison.OrdinalIgnoreCase));
        }

        public void EnterFirstName(string firstName)
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "aid_txtInitials", firstName);
        }

        public void EnterTitle(string title)
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "aid_txtTitle", title);
        }

        public void ClickSave()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnSave");
        }

        public void ClickExit()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnExit");
        }

        public void SelectConsentMenuItem(string contextMenuItem)
        {
            AutomationHelper.SelectContextMenu(_window, IdentifyElement.byId, "aid_btnMktgConsentQuestion", contextMenuItem);
        }

        public void CheckGreenTickEnabled()
        {
            AutomationHelper.IsElementEnabled(_window, IdentifyElement.byId, "aid_icon_StatusOK");
        }

        public void EnterEmailAddress(string emailaddress)
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnDetail_E-mail");
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "aid_txtEditDetail", emailaddress);
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnPath_txtEditDetail");
        }

        public void EnterHouseNumberAndAddress(string houseNum, string addressFirstLine)
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "aid_txtHseName", houseNum);
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "aid_txtAddress1", addressFirstLine);
        }

        public void SelectSourceMenu(string listItem)
        {
            AutomationHelper.SelectItemFromComboDropDownMenu(_window, IdentifyElement.byId, "aid_lsbSource", listItem);
        }

        public void CheckActivityFeedContains(string content)
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byId, "aid_txtFilter", content);
            Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
            var textFromActivityFeed = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "aid_txtjnlText_0");
            Assert.IsTrue(textFromActivityFeed.Contains(content, System.StringComparison.CurrentCultureIgnoreCase));
        }

        public void GetWindowTitleAndCheckItContains(string expectedText)
        {
            var windowTitle = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "aid_tbTitle");
            Assert.IsTrue(windowTitle.Contains(expectedText, System.StringComparison.CurrentCultureIgnoreCase));
        }

        public void NewContactRecordCreatedContains(string contactRecord)
        {
            var newRecord = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, "aid_btnPrimaryKey");
            Assert.IsTrue(newRecord.Contains(contactRecord, System.StringComparison.CurrentCultureIgnoreCase));
        }
    }
}

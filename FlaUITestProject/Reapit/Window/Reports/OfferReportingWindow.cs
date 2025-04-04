using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.Reapit.Window.Reports
{
    public class OfferReportingWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _offerReportingScreenWindow;
        public OfferReportingWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _offerReportingScreenWindow = window.FindFirstDescendant(cf => cf.ByName("Offer Reporting"));
            Assume.That(_offerReportingScreenWindow, Is.Not.Null);
        }

        public void ClickOfferReportRadioButton()
        {
            AutomationHelper.ClickRadioButton(_window, IdentifyElement.byId, "rdoOffers");
        }

        public void CheckOfferReportRadioButtonIsSelected()
        {
            Assert.IsTrue(AutomationHelper.CheckIfRadioButtonIsSelected(_window, IdentifyElement.byId, "rdoOffers"));
        }

        public void ClickReportButton()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "btnSave");
        }
        public void ClickClose()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnClose");
        }
    }
}

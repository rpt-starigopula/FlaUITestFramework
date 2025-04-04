using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationHelper;

namespace FlaUITestProject.Reapit.Window.OffersWindow
{
      
   public class OffersWindow
   {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _offerWindow;
        public OffersWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _offerWindow = window.FindFirstDescendant(cf => cf.ByName("Offers"));
            Assume.That(_offerWindow, Is.Not.Null);
        }

        public string GetBuyerName(string rowNum)
        {
            var buyerName = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, $"aid_gridCell_aid_gridRow_{rowNum}_0");
            return buyerName;
        }

        public void doubleClickTheFirstRecordInGrid()
        {
            AutomationHelper.DoubleClickButton(_window, IdentifyElement.byId, "aid_gridCell_aid_gridRow_0_0");
        }
        public void ClickExitButton()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnExit");
        }
    }
}

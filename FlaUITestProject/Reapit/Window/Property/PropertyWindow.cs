using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationHelper;

namespace FlaUITestProject.Reapit.Window.Property
    {
    public class PropertyWindow
        {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _propertyWindow;
        public PropertyWindow(FlaUI.Core.AutomationElements.Window window)
            {
            Wait.UntilResponsive(window);
            _window = window;
            _propertyWindow = window.FindFirstDescendant(cf => cf.ByAutomationId("frameMain"));
            Assume.That(_propertyWindow, Is.Not.Null);
            }

        public string GetHouseNameFromProperty()
            {
            var seNameFromProperty = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, $"aid_txtHseName");
            return seNameFromProperty;
            }
        public string GetAddresslineOneFromProperty()
            {
            var GetAddresslineOneFromProperty = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, $"aid_txtAddress1");
            return GetAddresslineOneFromProperty;
            }
        public string GetAddresslineTwoFromProperty()
            {
            var GetAddresslineTwoFromProperty = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, $"aid_txtAddress2");
            return GetAddresslineTwoFromProperty;
            }
        public string GetAddresslineThreeFromProperty()
            {
            var GetAddresslineThreeFromProperty = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, $"aid_txtAddress3");
            return GetAddresslineThreeFromProperty;
            }
        public string GetPostcodeFromProperty()
            {
            var GetPostcodeFromProperty = AutomationHelper.GetTextUsingElementNameProperty(_window, IdentifyElement.byId, $"aid_txtAddress3");
            return GetPostcodeFromProperty;
            }
        public void ClickExit()
            {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "aid_btnExit");
            }
        }
    }

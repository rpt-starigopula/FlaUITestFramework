using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;



namespace FlaUIPoC.Base
{
    public class WindowAdaptor
    {
        protected AutomationElement _FormControl;
        public Window Window => _FormControl as Window;

        public WindowAdaptor(ApplicationLaunchSetUp app, string automationId)
        {
            // Find window
            using (var automation = new UIA3Automation())
            {
                do
                {
                    _FormControl = app.FindWindow((win) => win.AutomationId == automationId);
                } while (_FormControl == null);

                _FormControl.Focus();
                Wait.UntilResponsive(_FormControl);
            }
        }

    }
}

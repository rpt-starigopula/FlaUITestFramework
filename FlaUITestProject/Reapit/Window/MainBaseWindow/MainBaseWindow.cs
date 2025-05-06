using FlaUI.Core.Input;
using FlaUIPoC.Reapit.Pages.Login;
using FlaUIPoC.Reapit.Window.Contact;
using FlaUIPoC.Reapit.Window.HomeScreen;
using FlaUIPoC.Reapit.Window.Login;
using FlaUIPoC.Base;
using FlaUIPoC.Reapit.Window.Reports;
using FlaUITestProject.Reapit.Window.Property;
using FlaUITestProject.Reapit.Window.OffersWindow;
using FlaUIPoC.Reapit.Window.Company;
using FlaUIPoC.Reapit.Window.Applicant;

namespace FlaUIPoC.Reapit.Window.MainLoginWindow
{
    public class MainBaseWindow : WindowAdaptor
    {

        public LoginWindow LoginScreen
        {
            get { return _LoginWindow ??= new LoginWindow(Window); }
        }

        public InformationWindow InformationDialogue
        {
            get { return _InformationDialogue ??= new InformationWindow(Window); }
        }

        public HomeWindow HomeScreen
        {
            get { return _HomeWindow ??= new HomeWindow(Window); }
        }

        public RecentSearchPanelWindow RecentSearchPanel
        {
            get { return _RecentSearchPanelWindow ??= new RecentSearchPanelWindow(Window); }
        }

        public AddingNewContactDialogueWindow AddingNewContactDialogue
        {
            get { return _AddingNewContactDialogueWindow ??= new AddingNewContactDialogueWindow(Window); }
        }

        public AddingNewContactWindow AddingNewContactWindow
        {
            get { return _AddingNewContactWindow ??= new AddingNewContactWindow(Window); }
        }

        public OfferReportingWindow OfferReportingWindow
        {
            get { return _OfferReportingWindow ??= new OfferReportingWindow(Window); }
        }

        public OffersFoundWindow OffersFoundWindow
        {
            get { return _OfferFoundWindow ??= new OffersFoundWindow(Window); }
        }

        public PropertyWindow PropertyWindow
        {
            get { return _PropertyWindow ??= new PropertyWindow(Window); }
        }

        public CompanyWindow CompanyWindow
        {
            get { return _CompanyWindow ??= new CompanyWindow(Window); }
        }

        public ApplicantWindow ApplicantWindow
        {
            get { return _ApplicantWindow ??= new ApplicantWindow(Window); }
        }


        public OffersWindow OffersWindow
        {
            get { return _OffersWindow ??= new OffersWindow(Window); }
        }

        LoginWindow _LoginWindow;
        ApplicationLaunchSetUp _Application;
        InformationWindow _InformationDialogue;
        HomeWindow _HomeWindow;
        RecentSearchPanelWindow _RecentSearchPanelWindow;
        AddingNewContactDialogueWindow _AddingNewContactDialogueWindow;
        AddingNewContactWindow _AddingNewContactWindow;
        OfferReportingWindow _OfferReportingWindow;
        OffersFoundWindow _OfferFoundWindow;
        PropertyWindow _PropertyWindow;
        OffersWindow _OffersWindow;
        CompanyWindow _CompanyWindow;
        ApplicantWindow _ApplicantWindow;

        public MainBaseWindow(ApplicationLaunchSetUp app) : base(app, "MainWindow")
        {
            Wait.UntilResponsive(Window);
            _Application = app;
            Window.Focus();
            Wait.UntilResponsive(Window);
        }
    }
}

using FlaUITestProject.Base;

namespace FlaUITestProject.Reapit.Tests.Company
{
    internal class CompanyTests : BaseSetup
    {
        [Test]
        public void UsingTheExistingCompanyRecordAndCheckTheDisplayAndContentIsConsistentUsingScreenshot_OpenCvSharp()
        {
            // step	1. Given I am logged in as Test User	AC is open with the Home screen showing
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();
            //2.And I click the Company menu button  Then the Company menu opens showing the Search pane And the pane lists recently visited Contact records MainScreen  SubScreen
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Company");
            //step	3. And I type <Surname> into the search field	Then the search field populates with the typed text And the 'Advanced Search' button displays and is active And the '+ Add Company' button displays and is inactive							
            //step	4. And I press the Enter key	Then AC performs a search using the typed search text And search results are listed under 'Contacts' and 'Archived Contacts' headings And the '+ Add Company' button is now active window keys
            var searchPanel = MainWindow.RecentSearchPanel;
            //step 5. And I search for a record that exist in data back-up
             searchPanel.EnterTextAndSearch("Green Labourers Plc");
             searchPanel.ClickOnRecentUniversalSearchPanel();
             var openCompanyScreen = MainWindow.CompanyWindow;
            openCompanyScreen.CheckDocumentButtonExists();
             bool sectionExists = ImageComparisionHelper.CaptureScreenshotAndCheckTheExpectedImageSectionExistingWithThresholdUsingOpenCVSharp(Constants.ScreenshotBasePath + "\\CompanyScreen\\CompanyScreenWithDetails.png", 98);
             Assert.IsTrue(sectionExists, "The expected image does not exist in the actual screenshot.");
        }
    }
}

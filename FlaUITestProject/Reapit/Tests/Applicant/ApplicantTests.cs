using FlaUITestProject.Base;

namespace FlaUITestProject.Reapit.Tests.Applicant
{
    internal class ApplicantTests : BaseSetup
        {
        [Test]
        public void UsingTheExistingApplicantRecordAndCheckTheDisplayAndContentIsConsistentUsingScreenshot_OpenCvSharp()
            {
            //step	1. Given I am logged in as Test User	AC is open with the Home screen showing
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();
            //2.And I click the Applicant menu button  Then the Applicant menu opens showing the Search pane And the pane lists recently visited Applicant records MainScreen  SubScreen
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Applicant");
            //step	3. And I type <Surname> into the search field	Then the search field populates with the typed text And the 'Advanced Search' button displays 
            //step	4. And I press the Enter key	Then AC performs a search using the typed search text 
            var searchPanel = MainWindow.RecentSearchPanel;
            //step 5. And I search for a record that exist in data back-up
            searchPanel.EnterTextAndSearch("Aisha Learmonth");
            searchPanel.ClickOnRecentRecordInApplicantSearchPanel();
            var openApplicantScreen = MainWindow.ApplicantWindow;
            openApplicantScreen.CheckMatchButtonExists();
            bool sectionExists = ImageComparisionHelper.CaptureScreenshotAndCheckTheExpectedImageSectionExistingWithThresholdUsingOpenCVSharp(Constants.ScreenshotBasePath + "\\ApplicantScreen\\ApplicantScreenWithDetails.png", 93);
            Assert.IsTrue(sectionExists, "The expected image does not exist in the actual screenshot.");
            }
        }
}

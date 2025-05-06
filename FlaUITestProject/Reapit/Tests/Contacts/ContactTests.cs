using FlaUITestProject.Base;

namespace FlaUIPoC.Reapit.Tests.Contacts
{
    internal class ContactTests : BaseSetup
    {

        [Test]
        public void UsingTheContactSearchToAddANewContactRecordToTheSystem()
        {
            // step	1. Given I am logged in as Test User	AC is open with the Home screen showing
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();
            //2.And I click the Contact menu button  Then the Contact menu opens showing the Search pane And the pane lists recently visited Contact records MainScreen  SubScreen
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Contact");
            //step	3. And I type <Surname> into the search field	Then the search field populates with the typed text And the 'Advanced Search' button displays and is active And the '+ Add Contact' button displays and is inactive							
            //step	4. And I press the Enter key	Then AC performs a search using the typed search text And search results are listed under 'Contacts' and 'Archived Contacts' headings And the '+ Add Contact' button is now active window keys
            var searchPanel = MainWindow.RecentSearchPanel;
            var surname = AutomationHelper.RandomStringGenerator(6);
            searchPanel.EnterTextAndSearch(surname);
            //step 5. And I click the '+ Add Contact' button	Then the 'Adding New Contact' screen appears
            searchPanel.ClickAddContact();
            //step	6. And I type <Mobile Phone Number> in the search field	Then the search field populates with the typed text
            //step	7. And I click the Search button	Then the 'Adding New Contact...' screen appears And the <Surname> added populates the Surname field And the entered <Mobile Phone Number> shows against the Mobile entry in the Contact Details section							
            var addingNewContactDialogue = MainWindow.AddingNewContactDialogue;
            var mobileNum = AutomationHelper.RandomNumberGenerator(11);
            addingNewContactDialogue.EnterTheSearchDetails(mobileNum);
            var addingNewContactScreen = MainWindow.AddingNewContactWindow;
            addingNewContactScreen.CheckTheMobileNumber(mobileNum);
            addingNewContactScreen.CheckingSurname(surname);
            //step	8. And I type a <Title> and <Name> in the Name section	Then the Title and Name fields populate with the entered text							
            var firstName = AutomationHelper.RandomStringGenerator(6);
            addingNewContactScreen.EnterFirstName(firstName);
            addingNewContactScreen.EnterTitle("Mr");
            //step	9. And I click the the Marketing Consent option	Then the Marketing Consent dropdown menu appears
            //step  10.And I select 'Consent given'    Then the Marketing Consent dropdown menu closes And the icon next to the Marketing Consent option turns into a green tick							
            addingNewContactScreen.SelectConsentMenuItem("Consent given");
            addingNewContactScreen.CheckGreenTickEnabled();
            //step	11. And I add click the Add… link next to E-mail	Then the E-mail option changes to Edit mode	
            //step	12. And I type <E-mail Address>	Then the E-mail option populates with the typed text
            //step	13. And I click the tick icon to the right of the entered text	Then the E-mail option changes back to View mode
            var emailAddress = surname + "@reapit.com";
            addingNewContactScreen.EnterEmailAddress(emailAddress);
            //step	14. And I type <HseNo> and <Address1> in the Address section	Then the Address > House No and Address 1 fields populate with the typed text	
            addingNewContactScreen.EnterHouseNumberAndAddress("67", "Saffron Hill");
            //step	15. And I click the Source > Select… link	Then the Source menu opens
            //step	16. And I choose 'Rightmove'	Then the Source menu closes	
            addingNewContactScreen.SelectSourceMenu("Rightmove");
            //step	17. When I click the Save button	Then the title of the screen will update to show <Title> <Name> <Surname> - Registered [Today's Date] - Unique Reference And AC will not throw an error							
            addingNewContactScreen.ClickSave();
            //step	18. When I click the Save button	And the Activity Feed will update to show Contact Registered and Marketing Consent Journal entries
            addingNewContactScreen.CheckActivityFeedContains($"Contact registered: Mr {firstName} {surname}");
            addingNewContactScreen.CheckActivityFeedContains("Marketing consent set to given");
            var todayDate = DateTime.Now.ToString("dd/MM/yyyy");
            addingNewContactScreen.GetWindowTitleAndCheckItContains($"Mr {firstName} {surname} - Registered {todayDate} - ");
            addingNewContactScreen.NewContactRecordCreatedContains("BED");
            //step	19. And I click the Exit button	Then the Contact screen will close And AC will not throw an errorAnd I will not be prompted to SaveAnd I return to the Home screen							
            addingNewContactScreen.ClickExit();
            //step	20. And I click the Contact menu button	Then the Contact menu opens showing the Search paneAnd the pane lists recently visited Contact records with the newly added record at the top							
            homeScreen.ClickMainMenuItem("Contact");
            searchPanel.CheckRecentRecordInContactSearchPanelIs($"Mr {firstName} {surname}");
            searchPanel.ClickOnRecentContact();
            //step	21. And I click the newly added Contact record	Then the newly added Contact will reopenAnd all information entered in previous steps shows in the record							
            addingNewContactScreen.CheckTheMobileNumber(mobileNum);
            addingNewContactScreen.CheckingSurname(surname);
            addingNewContactScreen.CheckingFirstName(firstName);
            addingNewContactScreen.CheckingEmailAddress(emailAddress);
            addingNewContactScreen.CheckGreenTickEnabled();
            addingNewContactScreen.CheckActivityFeedContains($"Contact registered: Mr {firstName} {surname}");
            addingNewContactScreen.CheckActivityFeedContains("Marketing consent set to given");
            addingNewContactScreen.GetWindowTitleAndCheckItContains($"Mr {firstName} {surname} - Registered {todayDate} - ");
            addingNewContactScreen.NewContactRecordCreatedContains("BED");
            // step	22. And I click the Exit button	Then the Contact screen will closeAnd AC will not throw an errorAnd I will not be prompted to SaveAnd I return to the Home screen	
            addingNewContactScreen.ClickExit();
            homeScreen.ClickCloseButton();
        }

        [Test]
        public void UsingTheExistingContactRecordAndCheckTheDisplayAndContentIsConsistentUsingScreenshot_ImageSharp()
        {           
            // step	1. Given I am logged in as Test User	AC is open with the Home screen showing
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();
            //2.And I click the Contact menu button  Then the Contact menu opens showing the Search pane And the pane lists recently visited Contact records MainScreen  SubScreen
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Contact");
            //step	3. And I type <Surname> into the search field	Then the search field populates with the typed text And the 'Advanced Search' button displays and is active And the '+ Add Contact' button displays and is inactive							
            //step	4. And I press the Enter key	Then AC performs a search using the typed search text And search results are listed under 'Contacts' and 'Archived Contacts' headings And the '+ Add Contact' button is now active window keys
            var searchPanel = MainWindow.RecentSearchPanel;
            //step 5. And I search for a record that exist in data back-up
            searchPanel.EnterTextAndSearch("Arthur Bell");
            searchPanel.ClickOnRecentUniversalSearchPanel();
            //step	6. And I open that contact record and checking the green tick via auto id and template using screenshot
            var addingNewContactScreen = MainWindow.AddingNewContactWindow;
            addingNewContactScreen.CheckGreenTickEnabled();
            //App.CaptureScreenshot("ContactScreenWithDetails.png");
            string tempFilePath = Path.Combine(Path.GetTempPath(), "ActualScreenShot.png");
            Console.WriteLine("The temp path is : "+tempFilePath);
            App.CaptureScreenshot(tempFilePath);
            bool sectionExists = App.CompareImageSectionWithThreshold(Constants.ScreenshotBasePath + "\\ContactScreen\\ContactScreenWithDetails.png", tempFilePath,95);
            Assert.IsTrue(sectionExists, "The expected image does not exist in the actual screenshot.");
        }

        [Test]
        public void UsingTheExistingContactRecordAndCheckTheDisplayAndContentIsConsistentUsingScreenshot_OpenCvSharp()
            {
            // step	1. Given I am logged in as Test User	AC is open with the Home screen showing
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();
            //2.And I click the Contact menu button  Then the Contact menu opens showing the Search pane And the pane lists recently visited Contact records MainScreen  SubScreen
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Contact");
            //step	3. And I type <Surname> into the search field	Then the search field populates with the typed text And the 'Advanced Search' button displays and is active And the '+ Add Contact' button displays and is inactive							
            //step	4. And I press the Enter key	Then AC performs a search using the typed search text And search results are listed under 'Contacts' and 'Archived Contacts' headings And the '+ Add Contact' button is now active window keys
            var searchPanel = MainWindow.RecentSearchPanel;
            //step 5. And I search for a record that exist in data back-up
            searchPanel.EnterTextAndSearch("Arthur Bell");
            searchPanel.ClickOnRecentUniversalSearchPanel();
            //step	6. And I open that contact record and checking the green tick via auto id and template using screenshot
            var addingNewContactScreen = MainWindow.AddingNewContactWindow;
            addingNewContactScreen.CheckGreenTickEnabled();
            bool sectionExists = ImageComparisionHelper.CaptureScreenshotAndCheckTheExpectedImageSectionExistingWithThresholdUsingOpenCVSharp(Constants.ScreenshotBasePath + "\\ContactScreen\\ContactScreenWithDetails.png", 98);
            Assert.IsTrue(sectionExists, "The expected image does not exist in the actual screenshot.");
            }

        [Test]
        public void CreateABasicContact()
        {
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Contact");
            var searchPanel = MainWindow.RecentSearchPanel;
            var surname = AutomationHelper.RandomStringGenerator(6);
            searchPanel.EnterTextAndSearch(surname);
            searchPanel.ClickAddContact();
            var addingNewContactDialogue = MainWindow.AddingNewContactDialogue;
            var mobileNum = AutomationHelper.RandomNumberGenerator(11);
            addingNewContactDialogue.EnterTheSearchDetails(mobileNum);
            var addingNewContactScreen = MainWindow.AddingNewContactWindow;
            addingNewContactScreen.CheckTheMobileNumber(mobileNum);
            addingNewContactScreen.CheckingSurname(surname);
            var firstName = AutomationHelper.RandomStringGenerator(6);
            addingNewContactScreen.EnterFirstName(firstName);
            addingNewContactScreen.EnterTitle("Mr");
            addingNewContactScreen.ClickSave();
            addingNewContactScreen.ClickExit();
        }
    }
}

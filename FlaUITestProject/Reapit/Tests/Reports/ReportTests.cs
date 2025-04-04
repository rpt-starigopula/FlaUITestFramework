using FlaUI.Core.Tools;
using NUnit.Framework;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace FlaUIPoC.Reapit.Tests.Reports
{
    internal class ReportTests : BaseSetup
    {

        [Test]
        public void RPT_33_Run_the_Offers_Report_and_open_a_result_from_the_report_output()
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Start time : " + startTime);

            // step	1. Given I am logged in as Test User	AC is open with the Home screen showing
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterValidCredentialsAndLogin();

            // step	2. And I click the Reports menu button	Then the Reports menu opens	
            var homeScreen = MainWindow.HomeScreen;
            homeScreen.ClickMainMenuItem("Reports");

            //step	3. And I click the MI Analysis header	Then the MI Analysis section expands
            var searchPanel = MainWindow.RecentSearchPanel;
			searchPanel.ClickSubMenuItem("MI analysis");

            //step	4. And I click the option 'Offers & Pipeline Reports'	
            //Then the Reports menu closes And the Offer Reporting screen opens									
			searchPanel.ClickSubMenuItem("Offers & Pipeline Reports");

			//step  5.And I click the Offer Report radiobutton Then the Offer Report radiobutton shows as selected
			var offerReporting = MainWindow.OfferReportingWindow;
			offerReporting.ClickOfferReportRadioButton();
			offerReporting.CheckOfferReportRadioButtonIsSelected();

			// step	6. When I click the Report button bottom right	
			// Then the Offer results window opens And results are listed in the pane with Property addresses and Buyer names in the first two columns respectively									
			offerReporting.ClickReportButton();
			var offersFoundWindow = MainWindow.OffersFoundWindow;
			var firstBuyerName = offersFoundWindow.GetBuyerName("0").ToLower();
            var firstPrpAddress = offersFoundWindow.GetPropertyAddress("0");

			// step    7.When I double-click the first entry in the listing   
			//Then the Property screen opens And the Offers screen opens And the Buyer name for that row in the listing shows selected in the Offers screen listing
			offersFoundWindow.DoubleClickPropertyColumnOnRow("0");
			var offersScreen = MainWindow.OffersWindow;
            var buyerNameFromOffers = offersScreen.GetBuyerName("0").ToLower();
            Assert.IsTrue(buyerNameFromOffers.Contains(firstBuyerName));

            // step    8.And I click the Exit button
			// Then the Offers screen closes And I return to the Property screen And the Property address for that row in the listing shows in the Address field of the Property
			offersScreen.ClickExitButton();
            var propertyScreen = MainWindow.PropertyWindow;
			var houseNameFromProperty = propertyScreen.GetHouseNameFromProperty();
			Assert.IsTrue(firstPrpAddress.Contains(houseNameFromProperty));
			var addressLineOne = propertyScreen.GetAddresslineOneFromProperty();
            Assert.IsTrue(firstPrpAddress.Contains(addressLineOne));
            var addressLineTwo = propertyScreen.GetAddresslineTwoFromProperty();
            Assert.IsTrue(firstPrpAddress.Contains(addressLineTwo));
            var addressLineThree = propertyScreen.GetAddresslineThreeFromProperty();
            Assert.IsTrue(firstPrpAddress.Contains(addressLineThree));
            var postcodeFromProperty = propertyScreen.GetPostcodeFromProperty();
            Assert.IsTrue(firstPrpAddress.Contains(postcodeFromProperty));

            //9.And I click the Exit button Then the Property screen closes And I return to the Offer results window
            propertyScreen.ClickExit();

            // 10.And I click the Exit button Then the Offer results window closes And I return to the Offer Reporting screen
            offersFoundWindow.ClickExit();

            //11.And I click the Exit button Then the Offer Reporting screen closes And I return to the Home screen
            offerReporting.ClickClose();
            homeScreen.ClickCloseButton();
            DateTime endTime = DateTime.Now;
            Console.WriteLine("EndTime :" + endTime);
            var duration = endTime - startTime;
            Console.WriteLine("Duration  :" + duration);        			


  					
               
        }
    }
}

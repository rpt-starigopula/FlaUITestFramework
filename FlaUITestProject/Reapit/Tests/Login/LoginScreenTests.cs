using FlaUIPoC.Reapit.Pages.Login;
using FlaUITestProject.Base;


namespace FlaUIPoC.Reapit.Tests.Login
{
    internal class LoginScreenTests : BaseSetup
    {
        private LoginWindow _loginScreenPage;

        [Test]
        public void CheckTheLoginFunctionalityWithValidCredentails()
        {
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterLoginCredentials("ATT", "password");
            var informationDialogue = MainWindow.InformationDialogue;
            informationDialogue.AssertMessageDetailsAndAccept("rps_demo");
        }

        [Test]
        public void CheckTheLoginFunctionalityWithInValidCredentails()
        {
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterLoginCredentials("ATT", "wrong");
            var informationDialogue = MainWindow.InformationDialogue;
            informationDialogue.AssertMessageDetailsAndAccept("Incorrect user name or password. Please try again.");
        }

        [Test]
        public void CheckTheLoginScreenHasReapitLogo()
        {
            var loginPage = MainWindow.LoginScreen;
            App.CaptureScreenshot("ActualScreenShot.png");
            //bool sectionExists = App.CompareImageSection(Constants.ScreenshotBasePath + "\\LoginWindow\\ReapitLogo.png", "ActualScreenShot.png");
            bool sectionExists = ImageComparisionHelper.CaptureScreenshotAndCheckTheExpectedImageSectionExistingWithThresholdUsingOpenCVSharp(Constants.ScreenshotBasePath + "\\LoginWindow\\ReapitLogo.png", 96);
            Console.WriteLine($"Expected image section exists in actual screenshot: {sectionExists}");
            Assert.IsTrue(sectionExists, "The expected image does not exist in the actual screenshot.");
        }

        [Test]
        public void CheckTheLoginScreenWithoutEnteringCredentails()
        {
            var loginPage = MainWindow.LoginScreen;
            bool sectionExists = ImageComparisionHelper.CaptureScreenshotAndCheckTheExpectedImageSectionExistingWithThresholdUsingOpenCVSharp(Constants.ScreenshotBasePath + "\\LoginWindow\\LoginCredentails.png", 96);
            Console.WriteLine($"Expected image section exists in actual screenshot: {sectionExists}");
            Assert.IsTrue(sectionExists, "The expected image section does not exist in the actual screenshot.");
        }
    }
}
                 
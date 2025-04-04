using FlaUIPoC.Reapit.Pages.Login;


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
            bool sectionExists = App.CompareImageSection("C:\\Users\\starigopula\\source\\FlaUITestFramework\\FlaUITestProject\\Reapit\\Screenshots\\LoginWindow\\ReapitLogo.png", "ActualScreenShot.png");
            Console.WriteLine($"Expected image section exists in actual screenshot: {sectionExists}");
            Assert.IsTrue(sectionExists, "The expected image section does not exist in the actual screenshot.");
        }

        [Test]
        public void CheckTheLoginScreenWithoutEnteringCredentails()
        {
            var loginPage = MainWindow.LoginScreen;
            App.CaptureScreenshot("ActualScreenShot.png");
            bool sectionExists = App.CompareImageSection("C:\\Users\\starigopula\\source\\FlaUITestFramework\\FlaUITestProject\\Reapit\\Screenshots\\LoginWindow\\LoginCredentails.png", "ActualScreenShot.png");
            Console.WriteLine($"Expected image section exists in actual screenshot: {sectionExists}");
            Assert.IsTrue(sectionExists, "The expected image section does not exist in the actual screenshot.");
        }
    }
}
                 
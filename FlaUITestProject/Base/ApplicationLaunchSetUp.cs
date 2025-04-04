using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Diagnostics;
using System.Drawing.Imaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace FlaUIPoC.Base
{
    public class ApplicationLaunchSetUp
    {
        public static Application Application { get; set; }
        public static UIA3Automation Automation { get; set; }

        public ApplicationLaunchSetUp() { }

        public void Init()
        {
            Automation = new UIA3Automation();
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.LoadUserProfile = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.FileName = @"C:\\Automation\\Utility\\12_206_0_RC10\\RPS.Bootstrapper.exe";
            Application = Application.AttachOrLaunch(processStartInfo);
            WaitForApplicationLaunch();
        }

        private static void WaitForApplicationLaunch()
        {
            int windowCount = 0;
            int count = 0;
            do
            {
                try
                {
                    windowCount = Application.GetAllTopLevelWindows(Automation).Length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while accessing the application :" + ex);
                }

                Thread.Sleep(1000);
                count++;
            }
            while (windowCount < 1 && count < 150);
        }

        public void Cleanup()
        {
            Automation.Dispose();
            Application.Close();
            Application.Kill();
        }

        public Window FindWindow(Func<Window, bool> predicateFunc)
        {
            using (var automation = new UIA3Automation())
            {
                return Application.GetAllTopLevelWindows(automation).FirstOrDefault(predicateFunc);
            }
        }

        public void CaptureScreenshot(string filePath)
        {
            var window = Application.GetMainWindow(Automation);
            var screenshot = window.Capture();
            using (var memoryStream = new MemoryStream())
            {
                screenshot.Save(memoryStream, ImageFormat.Png);
                using (var image = SixLabors.ImageSharp.Image.Load<Rgba32>(memoryStream.ToArray()))
                {
                    image.Save(filePath);
                }
            }
        }

        public bool CompareImageSection(string expectedImagePath, string actualImagePath)
        {
            using (var expectedImage = SixLabors.ImageSharp.Image.Load<Rgba32>(expectedImagePath))
            using (var actualImage = SixLabors.ImageSharp.Image.Load<Rgba32>(actualImagePath))
            {
                for (int y = 0; y <= actualImage.Height - expectedImage.Height; y++)
                {
                    for (int x = 0; x <= actualImage.Width - expectedImage.Width; x++)
                    {
                        var section = actualImage.Clone(ctx => ctx.Crop(new Rectangle(x, y, expectedImage.Width, expectedImage.Height)));
                        if (ImagesAreEqual(expectedImage, section))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool ImagesAreEqual(Image<Rgba32> img1, Image<Rgba32> img2)
        {
            if (img1.Width != img2.Width || img1.Height != img2.Height)
                return false;

            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {
                    if (img1[x, y] != img2[x, y])
                        return false;
                }
            }
            return true;
        }
    }
}
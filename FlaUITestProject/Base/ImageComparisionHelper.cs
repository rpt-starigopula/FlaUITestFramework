using FlaUI.Core;
using FlaUI.Core.Capturing;
using FlaUI.UIA3;
using OpenCvSharp;


namespace FlaUITestProject.Base
{
    public static class ImageComparisionHelper
    {
        private static string actualFullScreenPath = Path.Combine(Path.GetTempPath(), "ActualScreenShot.png");
        public static FlaUI.Core.AutomationElements.Window GetMainWindow(Application app, UIA3Automation automation)
        {
            return app.GetMainWindow(automation);
        }

        public static void CaptureScreenshotUsingOpenCVSharp()
        {
            var screenshot = Capture.Screen();
            screenshot.ToFile(actualFullScreenPath);
        }

        public static bool CaptureScreenshotAndCheckTheExpectedImageSectionExistingWithThresholdUsingOpenCVSharp(string expectedImagePath, double matchThreshold = 98)
        {
            //Capturing the full screenshot of the screen with reapit application
            CaptureScreenshotUsingOpenCVSharp();

            var fullScreenshot = Cv2.ImRead(actualFullScreenPath);
            var expectedSection = Cv2.ImRead(expectedImagePath);

            Mat result = new Mat();
            Cv2.MatchTemplate(fullScreenshot, expectedSection, result, TemplateMatchModes.CCoeffNormed);

            double minVal, maxVal;
            Point minLoc, maxLoc;
            Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);
            Console.WriteLine($"Max value: {maxVal}");
            Console.WriteLine($"matchThreshold: {matchThreshold/100}");
            if (maxVal >= matchThreshold / 100)  // Thresold for match logic 
                {
                return true; // Match found
                }
            else
                {
                return false; // No match found
                }

        }
    }
 }

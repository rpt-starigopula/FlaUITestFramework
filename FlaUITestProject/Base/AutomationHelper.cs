using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using System.Drawing;

public static class AutomationHelper
{
    public static Window GetMainWindow(Application app, UIA3Automation automation)
    {
        return app.GetMainWindow(automation);
    }

    public enum SearchType
    {
        ByName,
        ById,
        ByClassName,
        ByText
    }

    public static class IdentifyElement
    {
        public const SearchType defaultSearchType = SearchType.ById;
        public const SearchType byName = SearchType.ByName;
        public const SearchType byId = SearchType.ById;
        public const SearchType byClassName = SearchType.ByClassName;
        public const SearchType byText = SearchType.ByText;
    }

    private static AutomationElement FindAndWaitForElement(Window window, SearchType searchType, string searchValue)
    {
        Wait.UntilInputIsProcessed();
        int count = 0;
        bool elementFound = false;
        AutomationElement element;
        do
        {
            element = FindElement(window, searchType, searchValue);
            var elementExists = Retry.WhileNull(() => element, TimeSpan.FromSeconds(1)).Result;
            if (elementExists != null)
            {
                elementFound = true;
            }
            count++;

        }
        while (count < 60 && elementFound == false);
        Assert.IsTrue(WaitForElementEnabled(element));
        return element;
    }

    private static AutomationElement FindElement(Window window, SearchType elementIdType, string elementIdValue)
    {
        return elementIdType
        switch
        {
            SearchType.ByName => window.FindFirstDescendant(cf => cf.ByName(elementIdValue).And(cf.ByControlType(ControlType.ListItem)))
                                 ?? window.FindFirstDescendant(cf => cf.ByName(elementIdValue).And(cf.ByControlType(ControlType.Button)))
                                 ?? window.FindFirstDescendant(cf => cf.ByName(elementIdValue).And(cf.ByControlType(ControlType.Text)))
                                 ?? window.FindFirstDescendant(cf => cf.ByName(elementIdValue).And(cf.ByControlType(ControlType.Edit)))
                                 ?? window.FindFirstDescendant(cf => cf.ByName(elementIdValue).And(cf.ByControlType(ControlType.Custom)))
                                 ?? window.FindFirstDescendant(cf => cf.ByName(elementIdValue).And(cf.ByControlType(ControlType.RadioButton))),
            SearchType.ById => window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.ListItem)))
                                  ?? window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.Button)))
                                  ?? window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.Text)))
                                  ?? window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.Edit)))
                                  ?? window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.Custom)))
                                  ?? window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.RadioButton))),
            SearchType.ByClassName => window.FindFirstDescendant(cf => cf.ByClassName(elementIdValue).And(cf.ByControlType(ControlType.ListItem)))
                                  ?? window.FindFirstDescendant(cf => cf.ByClassName(elementIdValue).And(cf.ByControlType(ControlType.Button)))
                                  ?? window.FindFirstDescendant(cf => cf.ByClassName(elementIdValue).And(cf.ByControlType(ControlType.Text)))
                                  ?? window.FindFirstDescendant(cf => cf.ByClassName(elementIdValue).And(cf.ByControlType(ControlType.Edit)))
                                  ?? window.FindFirstDescendant(cf => cf.ByClassName(elementIdValue).And(cf.ByControlType(ControlType.Custom)))
                                  ?? window.FindFirstDescendant(cf => cf.ByClassName(elementIdValue).And(cf.ByControlType(ControlType.RadioButton))),
            SearchType.ByText => window.FindFirstDescendant(cf => cf.ByText(elementIdValue).And(cf.ByControlType(ControlType.ListItem)))
                                  ?? window.FindFirstDescendant(cf => cf.ByText(elementIdValue).And(cf.ByControlType(ControlType.Button)))
                                  ?? window.FindFirstDescendant(cf => cf.ByText(elementIdValue).And(cf.ByControlType(ControlType.Text)))
                                  ?? window.FindFirstDescendant(cf => cf.ByText(elementIdValue).And(cf.ByControlType(ControlType.Edit)))
                                  ?? window.FindFirstDescendant(cf => cf.ByText(elementIdValue).And(cf.ByControlType(ControlType.Custom)))
                                  ?? window.FindFirstDescendant(cf => cf.ByText(elementIdValue).And(cf.ByControlType(ControlType.RadioButton))),
            _ => throw new ArgumentOutOfRangeException(nameof(elementIdType), elementIdType, null)
        };
    }

    public static bool WaitForElementEnabled(AutomationElement element)
    {
        int count = 0;
        bool elementEnabled = false;
        do
        {
            elementEnabled = element.Properties.IsEnabled.Value;
            if (elementEnabled == false)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            count++;
        }
        while (count < 6 && elementEnabled == false);
        return elementEnabled;
    }

    public static void ClickButton(Window window, SearchType elementIdType, string elementIdValue)
    {
        var button = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsButton();
        button?.Click();
    }

    public static void DoubleClickButton(Window window, SearchType elementIdType, string elementIdValue)
    {
        var button = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsButton();
        button?.DoubleClick();
    }

    public static void ClickRadioButton(Window window, SearchType elementIdType, string elementIdValue)
    {
        var button = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsRadioButton();
        button?.Click();
    }

    public static void MoveMouseToElementAndLeftClick(Window window, SearchType elementIdType, string elementIdValue)
    {
        var element = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsButton();
        var clickablePoint = element.GetClickablePoint();
        var xPoint = element.ActualWidth - 20;
        var midPoint = element.ActualHeight / 2;
        var yPoint = clickablePoint.Y - midPoint;
        yPoint = yPoint + 2;
        Mouse.MoveTo(new Point((int)xPoint, (int)yPoint));
        Mouse.LeftClick();
    }

    public static void RightClickButton(Window window, SearchType elementIdType, string elementIdValue)
    {
        var button = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsButton();
        button?.RightClick();
    }

    public static void SelectContextMenu(Window window, SearchType elementIdType, string elementIdValue, string contextMenuItem)
    {
        RightClickButton(window, elementIdType, elementIdValue);
        var contextMenu = window.FindFirstDescendant(cf => cf.ByControlType(ControlType.Menu));
        var menuItem = contextMenu.FindFirstDescendant(cf => cf.ByName(contextMenuItem));
        menuItem.AsMenuItem().Click();
    }

    public static void SelectItemFromComboDropDownMenu(Window window, SearchType elementIdType, string elementIdValue, string listMenuItem)
    {
        FindAndWaitForElement(window, elementIdType, elementIdValue);
        var comboBox = window.FindFirstDescendant(cf => cf.ByAutomationId(elementIdValue).And(cf.ByControlType(ControlType.ComboBox))).AsComboBox();
        Assume.That(comboBox, Is.Not.Null);
        comboBox.Select(listMenuItem);
    }

    public static void EnterText(Window windowName, SearchType elementIdType, string elementIdValue, string textToEnter)
    {

        var textBox = FindAndWaitForElement(windowName, elementIdType, elementIdValue)?.AsTextBox();
        if (textBox != null)
        {
            textBox.Text = string.Empty;
            textBox.Text = textToEnter;
        }
    }

    public static string GetText(Window window, SearchType elementIdType, string elementIdValue)
    {
        var textBox = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsTextBox();
        return textBox?.Text;
    }

    public static string GetTextUsingElementNameProperty(Window window, SearchType elementIdType, string elementIdValue)
    {
        var textBox = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsTextBox();
        return textBox?.Name;
    }

    public static bool CheckIfRadioButtonIsSelected(Window window, SearchType elementIdType, string elementIdValue)
    {
        var radioButton = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsRadioButton();
        return radioButton.IsChecked;
    }


    public static bool IsElementEnabled(Window window, SearchType elementIdType, string elementIdValue)
    {
        var button = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsButton();
        return button.IsEnabled;
    }

    public static void WaitForElementExist(AutomationElement elementId)
    {
        int count = 0;
        bool elementFound = false;
        do
        {
            var elementExists = Retry.WhileNull(() => elementId, TimeSpan.FromSeconds(10)).Result;
            if (elementExists != null)
            {
                elementFound = true;
            }
            //Console.WriteLine($"Waiting for this {elementId} to Exist: {elementExists}");
            //Console.WriteLine("Current timestamp : " + DateTime.Now);
            count++;
        } while (count < 6 && elementFound == false);
    }

    public static void SelectComboBoxItem(Window window, SearchType elementIdType, string elementIdValue, string itemText)
    {
        var comboBox = FindAndWaitForElement(window, elementIdType, elementIdValue)?.AsComboBox();
        if (comboBox != null)
        {
            comboBox.Select(itemText);
        }
    }

    public static void SetCheckboxState(Window window, SearchType searchType, string searchValue, bool isChecked)
    {
        var checkBox = FindAndWaitForElement(window, searchType, searchValue)?.AsCheckBox();
        if (checkBox != null)
        {
            checkBox.IsChecked = isChecked;
        }
    }

    public static string RandomNumberGenerator(int length = 11)
    {
        var random = new Random();
        string s = string.Empty;
        for (int i = 0; i < (length - 2); i++)
        {
            s = String.Concat(s, random.Next(10).ToString());
        }
        s = String.Concat("07", s);
        return s;
    }

    public static string RandomStringGenerator(int length = 6)
    {
        Random res = new Random();
        String str = "abcdefghijklmnopqrstuvwxyz";
        String ran = "";
        for (int i = 0; i < length; i++)
        {
            int x = res.Next(26);
            ran = ran + str[x];
        }
        return ran;
    }
}

using PROTON.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace ASSET.ATT.Application.GPS
{
    public static class AutomationAPI
    {
        const uint WM_SETTEXT = 0x000C;
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        const uint WM_CHAR = 0x0102;
        const uint WM_LBUTTONDOWN = 0x0201;
        const uint WM_LBUTTONUP = 0x0202;
        const uint BM_CLICK = 245;


        [DllImport("user32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        private const int SW_SHOWMAXIMIZED = 3;

        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        static extern int PostMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, UIntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        #region VirtualKeys
        public enum WindowsVirtualKey
        {
            [Description("Left mouse button")]
            VK_LBUTTON = 0x01,

            [Description("Right mouse button")]
            VK_RBUTTON = 0x02,

            [Description("Control-break processing")]
            VK_CANCEL = 0x03,

            [Description("Middle mouse button (three-button mouse)")]
            VK_MBUTTON = 0x04,

            [Description("X1 mouse button")]
            VK_XBUTTON1 = 0x05,

            [Description("X2 mouse button")]
            VK_XBUTTON2 = 0x06,

            [Description("BACKSPACE key")]
            VK_BACK = 0x08,

            [Description("TAB key")]
            VK_TAB = 0x09,

            [Description("CLEAR key")]
            VK_CLEAR = 0x0C,

            [Description("ENTER key")]
            VK_RETURN = 0x0D,

            [Description("SHIFT key")]
            VK_SHIFT = 0x10,

            [Description("CTRL key")]
            VK_CONTROL = 0x11,

            [Description("ALT key")]
            VK_MENU = 0x12,

            [Description("PAUSE key")]
            VK_PAUSE = 0x13,

            [Description("CAPS LOCK key")]
            VK_CAPITAL = 0x14,

            [Description("IME Kana mode")]
            VK_KANA = 0x15,

            [Description("IME Hanguel mode (maintained for compatibility; use VK_HANGUL)")]
            VK_HANGUEL = 0x15,

            [Description("IME Hangul mode")]
            VK_HANGUL = 0x15,

            [Description("IME Junja mode")]
            VK_JUNJA = 0x17,

            [Description("IME final mode")]
            VK_FINAL = 0x18,

            [Description("IME Hanja mode")]
            VK_HANJA = 0x19,

            [Description("IME Kanji mode")]
            VK_KANJI = 0x19,

            [Description("ESC key")]
            VK_ESCAPE = 0x1B,

            [Description("IME convert")]
            VK_CONVERT = 0x1C,

            [Description("IME nonconvert")]
            VK_NONCONVERT = 0x1D,

            [Description("IME accept")]
            VK_ACCEPT = 0x1E,

            [Description("IME mode change request")]
            VK_MODECHANGE = 0x1F,

            [Description("SPACEBAR")]
            VK_SPACE = 0x20,

            [Description("PAGE UP key")]
            VK_PRIOR = 0x21,

            [Description("PAGE DOWN key")]
            VK_NEXT = 0x22,

            [Description("END key")]
            VK_END = 0x23,

            [Description("HOME key")]
            VK_HOME = 0x24,

            [Description("LEFT ARROW key")]
            VK_LEFT = 0x25,

            [Description("UP ARROW key")]
            VK_UP = 0x26,

            [Description("RIGHT ARROW key")]
            VK_RIGHT = 0x27,

            [Description("DOWN ARROW key")]
            VK_DOWN = 0x28,

            [Description("SELECT key")]
            VK_SELECT = 0x29,

            [Description("PRINT key")]
            VK_PRINT = 0x2A,

            [Description("EXECUTE key")]
            VK_EXECUTE = 0x2B,

            [Description("PRINT SCREEN key")]
            VK_SNAPSHOT = 0x2C,

            [Description("INS key")]
            VK_INSERT = 0x2D,

            [Description("DEL key")]
            VK_DELETE = 0x2E,

            [Description("HELP key")]
            VK_HELP = 0x2F,

            [Description("0 key")]
            K_0 = 0x30,

            [Description("1 key")]
            K_1 = 0x31,

            [Description("2 key")]
            K_2 = 0x32,

            [Description("3 key")]
            K_3 = 0x33,

            [Description("4 key")]
            K_4 = 0x34,

            [Description("5 key")]
            K_5 = 0x35,

            [Description("6 key")]
            K_6 = 0x36,

            [Description("7 key")]
            K_7 = 0x37,

            [Description("8 key")]
            K_8 = 0x38,

            [Description("9 key")]
            K_9 = 0x39,

            [Description("A key")]
            K_A = 0x41,

            [Description("B key")]
            K_B = 0x42,

            [Description("C key")]
            K_C = 0x43,

            [Description("D key")]
            K_D = 0x44,

            [Description("E key")]
            K_E = 0x45,

            [Description("F key")]
            K_F = 0x46,

            [Description("G key")]
            K_G = 0x47,

            [Description("H key")]
            K_H = 0x48,

            [Description("I key")]
            K_I = 0x49,

            [Description("J key")]
            K_J = 0x4A,

            [Description("K key")]
            K_K = 0x4B,

            [Description("L key")]
            K_L = 0x4C,

            [Description("M key")]
            K_M = 0x4D,

            [Description("N key")]
            K_N = 0x4E,

            [Description("O key")]
            K_O = 0x4F,

            [Description("P key")]
            K_P = 0x50,

            [Description("Q key")]
            K_Q = 0x51,

            [Description("R key")]
            K_R = 0x52,

            [Description("S key")]
            K_S = 0x53,

            [Description("T key")]
            K_T = 0x54,

            [Description("U key")]
            K_U = 0x55,

            [Description("V key")]
            K_V = 0x56,

            [Description("W key")]
            K_W = 0x57,

            [Description("X key")]
            K_X = 0x58,

            [Description("Y key")]
            K_Y = 0x59,

            [Description("Z key")]
            K_Z = 0x5A,

            [Description("Left Windows key (Natural keyboard)")]
            VK_LWIN = 0x5B,

            [Description("Right Windows key (Natural keyboard)")]
            VK_RWIN = 0x5C,

            [Description("Applications key (Natural keyboard)")]
            VK_APPS = 0x5D,

            [Description("Computer Sleep key")]
            VK_SLEEP = 0x5F,

            [Description("Numeric keypad 0 key")]
            VK_NUMPAD0 = 0x60,

            [Description("Numeric keypad 1 key")]
            VK_NUMPAD1 = 0x61,

            [Description("Numeric keypad 2 key")]
            VK_NUMPAD2 = 0x62,

            [Description("Numeric keypad 3 key")]
            VK_NUMPAD3 = 0x63,

            [Description("Numeric keypad 4 key")]
            VK_NUMPAD4 = 0x64,

            [Description("Numeric keypad 5 key")]
            VK_NUMPAD5 = 0x65,

            [Description("Numeric keypad 6 key")]
            VK_NUMPAD6 = 0x66,

            [Description("Numeric keypad 7 key")]
            VK_NUMPAD7 = 0x67,

            [Description("Numeric keypad 8 key")]
            VK_NUMPAD8 = 0x68,

            [Description("Numeric keypad 9 key")]
            VK_NUMPAD9 = 0x69,

            [Description("Multiply key")]
            VK_MULTIPLY = 0x6A,

            [Description("Add key")]
            VK_ADD = 0x6B,

            [Description("Separator key")]
            VK_SEPARATOR = 0x6C,

            [Description("Subtract key")]
            VK_SUBTRACT = 0x6D,

            [Description("Decimal key")]
            VK_DECIMAL = 0x6E,

            [Description("Divide key")]
            VK_DIVIDE = 0x6F,

            [Description("F1 key")]
            VK_F1 = 0x70,

            [Description("F2 key")]
            VK_F2 = 0x71,

            [Description("F3 key")]
            VK_F3 = 0x72,

            [Description("F4 key")]
            VK_F4 = 0x73,

            [Description("F5 key")]
            VK_F5 = 0x74,

            [Description("F6 key")]
            VK_F6 = 0x75,

            [Description("F7 key")]
            VK_F7 = 0x76,

            [Description("F8 key")]
            VK_F8 = 0x77,

            [Description("F9 key")]
            VK_F9 = 0x78,

            [Description("F10 key")]
            VK_F10 = 0x79,

            [Description("F11 key")]
            VK_F11 = 0x7A,

            [Description("F12 key")]
            VK_F12 = 0x7B,

            [Description("F13 key")]
            VK_F13 = 0x7C,

            [Description("F14 key")]
            VK_F14 = 0x7D,

            [Description("F15 key")]
            VK_F15 = 0x7E,

            [Description("F16 key")]
            VK_F16 = 0x7F,

            [Description("F17 key")]
            VK_F17 = 0x80,

            [Description("F18 key")]
            VK_F18 = 0x81,

            [Description("F19 key")]
            VK_F19 = 0x82,

            [Description("F20 key")]
            VK_F20 = 0x83,

            [Description("F21 key")]
            VK_F21 = 0x84,

            [Description("F22 key")]
            VK_F22 = 0x85,

            [Description("F23 key")]
            VK_F23 = 0x86,

            [Description("F24 key")]
            VK_F24 = 0x87,

            [Description("NUM LOCK key")]
            VK_NUMLOCK = 0x90,

            [Description("SCROLL LOCK key")]
            VK_SCROLL = 0x91,

            [Description("Left SHIFT key")]
            VK_LSHIFT = 0xA0,

            [Description("Right SHIFT key")]
            VK_RSHIFT = 0xA1,

            [Description("Left CONTROL key")]
            VK_LCONTROL = 0xA2,

            [Description("Right CONTROL key")]
            VK_RCONTROL = 0xA3,

            [Description("Left MENU key")]
            VK_LMENU = 0xA4,

            [Description("Right MENU key")]
            VK_RMENU = 0xA5,

            [Description("Browser Back key")]
            VK_BROWSER_BACK = 0xA6,

            [Description("Browser Forward key")]
            VK_BROWSER_FORWARD = 0xA7,

            [Description("Browser Refresh key")]
            VK_BROWSER_REFRESH = 0xA8,

            [Description("Browser Stop key")]
            VK_BROWSER_STOP = 0xA9,

            [Description("Browser Search key")]
            VK_BROWSER_SEARCH = 0xAA,

            [Description("Browser Favorites key")]
            VK_BROWSER_FAVORITES = 0xAB,

            [Description("Browser Start and Home key")]
            VK_BROWSER_HOME = 0xAC,

            [Description("Volume Mute key")]
            VK_VOLUME_MUTE = 0xAD,

            [Description("Volume Down key")]
            VK_VOLUME_DOWN = 0xAE,

            [Description("Volume Up key")]
            VK_VOLUME_UP = 0xAF,

            [Description("Next Track key")]
            VK_MEDIA_NEXT_TRACK = 0xB0,

            [Description("Previous Track key")]
            VK_MEDIA_PREV_TRACK = 0xB1,

            [Description("Stop Media key")]
            VK_MEDIA_STOP = 0xB2,

            [Description("Play/Pause Media key")]
            VK_MEDIA_PLAY_PAUSE = 0xB3,

            [Description("Start Mail key")]
            VK_LAUNCH_MAIL = 0xB4,

            [Description("Select Media key")]
            VK_LAUNCH_MEDIA_SELECT = 0xB5,

            [Description("Start Application 1 key")]
            VK_LAUNCH_APP1 = 0xB6,

            [Description("Start Application 2 key")]
            VK_LAUNCH_APP2 = 0xB7,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key")]
            VK_OEM_1 = 0xBA,

            [Description("For any country/region, the '+' key")]
            VK_OEM_PLUS = 0xBB,

            [Description("For any country/region, the ',' key")]
            VK_OEM_COMMA = 0xBC,

            [Description("For any country/region, the '-' key")]
            VK_OEM_MINUS = 0xBD,

            [Description("For any country/region, the '.' key")]
            VK_OEM_PERIOD = 0xBE,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key")]
            VK_OEM_2 = 0xBF,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key")]
            VK_OEM_3 = 0xC0,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key")]
            VK_OEM_4 = 0xDB,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key")]
            VK_OEM_5 = 0xDC,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key")]
            VK_OEM_6 = 0xDD,

            [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key")]
            VK_OEM_7 = 0xDE,

            [Description("Used for miscellaneous characters; it can vary by keyboard.")]
            VK_OEM_8 = 0xDF,


            [Description("Either the angle bracket key or the backslash key on the RT 102-key keyboard")]
            VK_OEM_102 = 0xE2,

            [Description("IME PROCESS key")]
            VK_PROCESSKEY = 0xE5,


            [Description("Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP")]
            VK_PACKET = 0xE7,

            [Description("Attn key")]
            VK_ATTN = 0xF6,

            [Description("CrSel key")]
            VK_CRSEL = 0xF7,

            [Description("ExSel key")]
            VK_EXSEL = 0xF8,

            [Description("Erase EOF key")]
            VK_EREOF = 0xF9,

            [Description("Play key")]
            VK_PLAY = 0xFA,

            [Description("Zoom key")]
            VK_ZOOM = 0xFB,

            [Description("PA1 key")]
            VK_PA1 = 0xFD,

            [Description("Clear key")]
            VK_OEM_CLEAR = 0xFE,

        }
        #endregion


        public static AutomationElement GPSApplication;
        public static AutomationElement GPSApplicationPOPUP;

        public static string MainWindowName;

        /// <summary>
        /// Set the Main Application (GPS) control. 
        /// </summary>
        /// <param name="MainWindowTitle">Window Title of the application</param>
        public static void SetGPSAutomationElement(string MainWindowTitle)
        {
            GPSApplication = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, MainWindowTitle));
        }

        /// <summary>
        /// Set the Automation Element for POPUP window. 
        /// </summary>
        /// <param name="popUpWindowName">Pop up window Title of the application</param>
        public static void SetGPSAutomationElementForPOPUP(string popUpWindowName)
        {
            GPSApplicationPOPUP = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, popUpWindowName));
        }


        [Obsolete("This method is deprecated. Please use OpenMenuBarItemsUsingKeyboard() instead")]
        /// <summary>
        /// Clicking on the menu bar items (File-->Open..)
        /// </summary>
        /// <param name="menuList">List of the menu items to be clicked</param>
        public static void OpenMenuBarItems(List<string> menuList)
        {
            try
            {
                BlockInput(true);
                System.Threading.Thread.Sleep(500);
                for (int i = 0; i < menuList.Count - 1; i++)
                {

                    PropertyCondition pCControl = new PropertyCondition(AutomationElement.NameProperty, menuList[i]);
                    AutomationElement aEControl = GPSApplication.FindFirst(TreeScope.Subtree, pCControl);
                    ExpandCollapsePattern patternControl = aEControl.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                    patternControl.Expand();
                }
                PropertyCondition pCLastItem = new PropertyCondition(AutomationElement.NameProperty, menuList[menuList.Count - 1]);
                AutomationElement aELastItem = GPSApplication.FindFirst(TreeScope.Subtree, pCLastItem);
                InvokePattern patternLastItem = aELastItem.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                if (patternLastItem != null)
                { patternLastItem.Invoke(); }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BlockInput(false);
            }
        }


        /// <summary>
        /// Clicking on the menu bar items (File-->Open..)
        /// </summary>
        /// <param name="mainMenuName">Name of Main Menu(like File, Edit)</param>
        /// <param name="keyboardPositions">Zero Based index of the menu items to be clicked in order</param>
        public static void OpenMenuBarItemsUsingKeyboardAndClose(string mainMenuName, params int[] keyboardPositions)
        {
            try
            {
                BlockInput(true);
                PropertyCondition pCControl = new PropertyCondition(AutomationElement.NameProperty, mainMenuName);
                AutomationElement aEControl = GPSApplication.FindFirst(TreeScope.Subtree, pCControl);
                ExpandCollapsePattern patternControl = aEControl.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;

                PropertyCondition pCControlSub = new PropertyCondition(AutomationElement.NameProperty, "Inbox");
                AutomationElement aEControlSub;
                do
                {
                    patternControl.Expand();
                    aEControlSub = GPSApplication.FindFirst(TreeScope.Subtree, pCControlSub);

                } while (aEControlSub == null);

                pCControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu);

                for (int i = 0; i < keyboardPositions.Length; i++)
                {
                    pCControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu);
                    AutomationElementCollection aEControlColl = GPSApplication.FindAll(TreeScope.Subtree, pCControl);
                    IntPtr aEHandle = (IntPtr)aEControlColl[aEControlColl.Count - 1].Current.NativeWindowHandle;

                    for (int j = 0; j < keyboardPositions[i]; j++)
                    {
                        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x11500001);
                    }
                    if (i != keyboardPositions.Length - 1)
                    {
                        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RIGHT, (IntPtr)0x114D0001);    //0x0100 ==> wm_keydown 
                    }
                    else
                    {
                        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x101C0001);
                    }
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                BlockInput(false);
            }

        }
        public static void OpenMenuBarItemsUsingKeyboard(string MainTabName, string mainMenuName, params int[] keyboardPositions)
        {
            BlockInput(true);
            try
            {
                while (!CheckMainTabExistByExactName(MainTabName))
                {

                    Menu(mainMenuName, keyboardPositions);
                }

            }
            finally
            {
                BlockInput(false);
            }

        }

        public static void Menu(string mainMenuName, params int[] keyboardPositions)
        {
            try
            {
                PropertyCondition pCControl = new PropertyCondition(AutomationElement.NameProperty, mainMenuName);
                AutomationElement aEControl = GPSApplication.FindFirst(TreeScope.Subtree, pCControl);
                ExpandCollapsePattern patternControl = aEControl.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;

                PropertyCondition pCControlSub = new PropertyCondition(AutomationElement.NameProperty, "Inbox");
                AutomationElement aEControlSub;
                do
                {
                    patternControl.Expand();
                    aEControlSub = GPSApplication.FindFirst(TreeScope.Subtree, pCControlSub);

                } while (aEControlSub == null);

                pCControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu);

                for (int i = 0; i < keyboardPositions.Length; i++)
                {
                    pCControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu);
                    AutomationElementCollection aEControlColl = GPSApplication.FindAll(TreeScope.Subtree, pCControl);
                    IntPtr aEHandle = (IntPtr)aEControlColl[aEControlColl.Count - 1].Current.NativeWindowHandle;

                    for (int j = 0; j < keyboardPositions[i]; j++)
                    {
                        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x11500001);
                    }
                    if (i != keyboardPositions.Length - 1)
                    {
                        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RIGHT, (IntPtr)0x114D0001);    //0x0100 ==> wm_keydown 
                    }
                    else
                    {
                        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x101C0001);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// To Set a value in a textbox identified by index
        /// </summary>
        /// <param name="index">Index of Texbox Control starting with zero</param>
        /// <param name="text">Value to be Set</param>
        public static void SetTextinTextBoxByIndex(int index, string text)
        {
            try
            {
                PropertyCondition pCTextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AutomationElementCollection textBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCTextBoxControl);
                ValuePattern patternTextBox = textBoxCollection[index].GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                BlockInput(true);
                patternTextBox.SetValue(text);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BlockInput(false);
            }
        }

        /// <summary>
        /// To Set a value in a textbox identified by index
        /// </summary>
        /// <param name="index">Index of Texbox Control starting with zero</param>
        /// <param name="text">Value to be Set</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void SetTextinTextBoxByIndex(int index, string text, AutomationElement AE)
        {
            try
            {
                PropertyCondition pCTextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AutomationElementCollection textBoxCollection = AE.FindAll(TreeScope.Subtree, pCTextBoxControl);
                ValuePattern patternTextBox = textBoxCollection[index].GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                BlockInput(true);
                patternTextBox.SetValue(text);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BlockInput(false);
            }
        }


        /// <summary>
        /// To Set a value in a textbox identified by Unique Name
        /// </summary>
        /// <param name="index">Index of Texbox Control starting with zero</param>
        /// <param name="text">Value to be Set</param>
        public static void SetTextinTextBoxByName(string textBoxName, string text)
        {
            try
            {
                PropertyCondition pCTextBoxControl0 = new PropertyCondition(AutomationElement.NameProperty, textBoxName);
                PropertyCondition pCTextBoxControl1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AutomationElementCollection textBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, new AndCondition(pCTextBoxControl0, pCTextBoxControl1));
                ValuePattern patternTextBox = textBoxCollection[0].GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                patternTextBox.SetValue(text);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                BlockInput(false);
            }

        }

        /// <summary>
        /// Click on a button identified by Unique Name 
        /// </summary>
        /// <param name="buttonName">Unique Name of the button</param>
        public static void ButtonClickByName(string buttonName)
        {
            try
            {
                PropertyCondition pcButtonControl1 = new PropertyCondition(AutomationElement.NameProperty, buttonName);
                PropertyCondition pcButtonControl0 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
                AutomationElement buttonControl = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, new AndCondition(pcButtonControl0, pcButtonControl1));
                InvokePattern pattternButtonControl = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                pattternButtonControl.Invoke();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Click on a button identified by Unique Name 
        /// </summary>
        /// <param name="buttonName">Unique Name of the button</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void ButtonClickByName(string buttonName, AutomationElement AE)
        {
            try
            {
                PropertyCondition pcButtonControl = new PropertyCondition(AutomationElement.NameProperty, buttonName);
                AutomationElement buttonControl;
                int count = 0;
                do
                {
                    buttonControl = AE.FindFirst(TreeScope.Subtree, pcButtonControl);
                    Thread.Sleep(100);
                } while (buttonControl == null && count < 100);

                InvokePattern pattternButtonControl = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                pattternButtonControl.Invoke();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Click on a button identified by index
        /// </summary>
        /// <param name="buttonName">Zero based index of the button</param>
        public static void ButtonClickByIndex(int index)
        {
            try
            {
                PropertyCondition pcButtonControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
                AutomationElementCollection aEButtonControlCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pcButtonControl);
                AutomationElement buttonControl = aEButtonControlCollection[index];
                InvokePattern pattternButtonControl = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                pattternButtonControl.Invoke();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Click on a button identified by index
        /// </summary>
        /// <param name="index">Zero based index of the button</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void ButtonClickByIndex(int index, AutomationElement AE)
        {
            try
            {
                PropertyCondition pcButtonControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
                AutomationElementCollection aEButtonControlCollection = AE.FindAll(TreeScope.Subtree, pcButtonControl);
                AutomationElement buttonControl = aEButtonControlCollection[index];
                InvokePattern pattternButtonControl = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                pattternButtonControl.Invoke();
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Get value from a textbox identified by index
        /// </summary>
        /// <param name="index">Index of Texbox Control starting from zero</param>
        /// <returns>Return the string value from textbox</returns>
        public static string GetTextFromTextBoxByIndex(int index)
        {
            string val = String.Empty;
            try
            {
                PropertyCondition pCtextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AutomationElementCollection textBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Descendants, pCtextBoxControl);
                TextPattern wfmptrn = textBoxCollection[index].GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                System.Windows.Automation.Text.TextPatternRange txtRange = wfmptrn.DocumentRange;
                val = txtRange.GetText(100);

            }
            catch (Exception ex)
            {
            }
            return val;
        }

        /// <summary>
        /// Get value from a textbox identified by name
        /// </summary>
        /// <param name="textBoxName">Unique Name of Texbox Control </param>
        /// <returns>Return the string value from textbox</returns>
        public static string GetTextFromTextBoxByName(string textBoxName)
        {
            string val = String.Empty;
            try
            {
                PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, textBoxName);
                PropertyCondition pc1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AutomationElement textBoxEdit = GPSApplication.FindFirst(TreeScope.Subtree, new AndCondition(pC0, pc1));
                TextPattern wfmptrn = textBoxEdit.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                System.Windows.Automation.Text.TextPatternRange txtRange = wfmptrn.DocumentRange;

                val = txtRange.GetText(100);

            }
            catch (Exception ex)
            {
            }
            return val;
        }

        /// <summary>
        /// CLick on a label link (like WFM Project)
        /// </summary>
        /// <param name="index">index of the control element starting from zero WHEN GPS IS NOT DOCKED INSIDE ASSISTEDGE</param>
        /// <param name="dockStatus">Dock Status of GPS</param>
        public static void ClickOnLabelLink(int index, bool dockStatus)
        {
            try
            {
                if (dockStatus == true)
                {
                    index += 1;
                }
                AutomationElementCollection aECollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

                List<String> AutomationId = new List<string>();
                foreach (AutomationElement AE in aECollection)
                {
                    AutomationId.Add(AE.Current.AutomationId);
                }

                AutomationElement aE = aECollection[index];
                IntPtr aEHandle = (IntPtr)aE.Current.NativeWindowHandle;
                SendMessage(aEHandle, (uint)0x0100, (UIntPtr)0x0000000D, (IntPtr)0x001C0001);    //0x0100 ==> wm_keydown 
                PostMessage(aEHandle, (uint)0x0102, (UIntPtr)0x00000020, (IntPtr)0x00390001);    //0x0102 ==> wm_char
                //SendMessage(aEHandle, (uint)0x0102, (UIntPtr)0x00000020, (IntPtr)0x00390001);    //0x0102 ==> wm_char

            }
            catch (Exception ex)
            {
            }
        }


        public static void ClickOnSRHandleLink(int index, bool dockStatus)
        {
            try
            {
                if (dockStatus == true)
                {
                    index += 1;
                }
                AutomationElementCollection aECollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

                List<String> AutomationId = new List<string>();
                foreach (AutomationElement AE in aECollection)
                {
                    AutomationId.Add(AE.Current.AutomationId);
                }

                AutomationElement aE = aECollection[index];
                IntPtr aEHandle = (IntPtr)aE.Current.NativeWindowHandle;
                SendMessage(aEHandle, (uint)0x0100, (UIntPtr)0x0000000D, (IntPtr)0x001C0001);    //0x0100 ==> wm_keydown 
                PostMessage(aEHandle, (uint)0x0102, (UIntPtr)0x00000020, (IntPtr)0x00390001);    //0x0102 ==> wm_char

            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Get the List of tab names from a tab Control
        /// </summary>
        /// <param name="TabCollection">Tab Control Element</param>
        /// <returns>List of all the tab items in the Tab Control</returns>
        private static List<string> GetTabNames(AutomationElement TabCollection)
        {
            List<string> AllTabs = new List<string>();
            try
            {
                PropertyCondition pCTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                AutomationElementCollection TabItemCollections = TabCollection.FindAll(TreeScope.Subtree, pCTab);

                AllTabs.Clear();
                foreach (AutomationElement AE in TabItemCollections)
                {
                    AllTabs.Add(AE.Current.Name);
                }

            }
            catch (Exception ex)
            {
            }
            return AllTabs;
        }

        [Obsolete("SelectSubTab() is deprecated, please use SelectSubTabByExactName() instead.")]
        /// <summary>
        /// Select a Sub Tab (Like Documents,Notes)
        /// </summary>
        /// <param name="tabName">Name of the Tab</param>
        public static void SelectSubTab(string tabName)
        {
            try
            {
                PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
                AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
                List<string> AllTabs = new List<string>();
                int tabhandle = TabCollections[0].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[0]);

                int pos = 0;
                int count = 0;
                foreach (string tab in AllTabs)
                {
                    if (tab.Equals(tabName))
                    {
                        pos = count;
                    }
                    count++;
                }

                //Left Key
                for (int i = 0; i < count; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000025, (IntPtr)(0x001E0001)); }

                //Right Key
                for (int i = 0; i < pos; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000027, (IntPtr)(0x001E0001)); }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Select a Sub Tab (Like Documents,Notes)
        /// </summary>
        /// <param name="tabName">Exact Name of the Tab</param>
        public static void SelectSubTabByExactName(string tabName)
        {
            try
            {
                PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
                AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
                List<string> AllTabs = new List<string>();
                int tabhandle = TabCollections[0].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[0]);

                int pos = 0;
                int count = 0;
                foreach (string tab in AllTabs)
                {
                    if (tab.Equals(tabName))
                    {
                        pos = count;
                    }
                    count++;
                }

                //Left Key
                for (int i = 0; i < count; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000025, (IntPtr)(0x001E0001)); }

                //Right Key
                for (int i = 0; i < pos; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000027, (IntPtr)(0x001E0001)); }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Get the automation Element of a dialogue box / popup using its name ( Used for popups containing Yes/No )
        /// </summary>
        /// <param name="windowName">Name of the window</param>
        public static AutomationElement GetAutomationElementUsingWindowName(string windowName)
        {
            try
            {
                IntPtr windowHandle = Win32.FindWindow(null, windowName);
                int noOfRepeats = 0;
                while (windowHandle == IntPtr.Zero && noOfRepeats < 1000)
                {
                    windowHandle = Win32.FindWindow(null, windowName);
                    Thread.Sleep(100);
                    noOfRepeats++;
                }
                if (windowHandle == IntPtr.Zero)
                {
                    // throw new NotImplementedException();
                }
                AutomationElement popupElement = null;
                if (windowHandle != IntPtr.Zero)
                {
                    popupElement = AutomationElement.FromHandle(windowHandle);
                }
                return popupElement;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public static AutomationElement GetAutomationElementUsingWindowName(string windowName, int count)
        {
            try
            {
                IntPtr windowHandle = Win32.FindWindow(null, windowName);
                int noOfRepeats = 0;
                while (windowHandle == IntPtr.Zero && noOfRepeats < count)
                {
                    windowHandle = Win32.FindWindow(null, windowName);
                    Thread.Sleep(100);
                    noOfRepeats++;
                }
                if (windowHandle == IntPtr.Zero)
                {

                }
                AutomationElement popupElement = null;
                if (windowHandle != IntPtr.Zero)
                {
                    popupElement = AutomationElement.FromHandle(windowHandle);
                }
                return popupElement;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Select a Sub Tab (Like Documents,Notes)
        /// </summary>
        /// <param name="tabName">Similar Name of the Tab</param>
        public static void SelectSubTabBySimilarName(string tabName)
        {
            try
            {
                PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
                AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
                List<string> AllTabs = new List<string>();
                int tabhandle = TabCollections[0].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[0]);

                int pos = 0;
                int count = 0;
                foreach (string tab in AllTabs)
                {
                    if (tab.Contains(tabName))
                    {
                        pos = count;
                    }
                    count++;
                }

                //Left Key
                for (int i = 0; i < count; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000025, (IntPtr)(0x001E0001)); }

                //Right Key
                for (int i = 0; i < pos; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000027, (IntPtr)(0x001E0001)); }
            }
            catch (Exception ex)
            {
            }
        }

        [Obsolete("SelectMainTab() is deprecated, please use SelectMainTabByExactName() instead.")]
        /// <summary>
        /// Select a Main Tab (Like Open - Client Request )
        /// </summary>
        /// <param name="tabName">Name of the Tab</param>
        public static void SelectMainTab(string tabName)
        {
            try
            {
                PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
                AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
                int tabhandle;
                List<string> AllTabs = new List<string>();
                if (TabCollections.Count > 1)
                {
                    tabhandle = TabCollections[1].Current.NativeWindowHandle;
                    AllTabs = GetTabNames(TabCollections[1]);
                }
                else if (TabCollections.Count == 0)
                {
                    return;
                }
                else
                {
                    tabhandle = TabCollections[0].Current.NativeWindowHandle;
                    AllTabs = GetTabNames(TabCollections[0]);
                }

                int pos = 0;
                int count = 0;
                foreach (string tab in AllTabs)
                {
                    if (tab.Equals(tabName))
                    {
                        pos = count;
                    }
                    count++;
                }
                //Left Key
                for (int i = 0; i < count; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000025, (IntPtr)(0x001E0001)); }

                ////Right Key
                for (int i = 0; i < pos; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000027, (IntPtr)(0x001E0001)); }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Select a Main Tab (Like Open - Client Request )
        /// </summary>
        /// <param name="tabName">Exact Name of the Tab</param>
        public static void SelectMainTabByExactName(string tabName)
        {
            try
            {
                PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
                AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
                int tabhandle;
                List<string> AllTabs = new List<string>();
                if (TabCollections.Count > 1)
                {
                    tabhandle = TabCollections[1].Current.NativeWindowHandle;
                    AllTabs = GetTabNames(TabCollections[1]);
                }
                else if (TabCollections.Count == 0)
                {
                    return;
                }
                else
                {
                    tabhandle = TabCollections[0].Current.NativeWindowHandle;
                    AllTabs = GetTabNames(TabCollections[0]);
                }

                int pos = 0;
                int count = 0;
                foreach (string tab in AllTabs)
                {
                    if (tab.Equals(tabName))
                    {
                        pos = count;
                    }
                    count++;
                }
                //Left Key
                for (int i = 0; i < count; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000025, (IntPtr)(0x001E0001)); }

                ////Right Key
                for (int i = 0; i < pos; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000027, (IntPtr)(0x001E0001)); }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Select a Main Tab (Like Open - Client Request )
        /// </summary>
        /// <param name="tabName">Similar Name of the Tab</param>
        public static void SelectMainTabBySimilarName(string tabName)
        {
            try
            {
                PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
                AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
                int tabhandle;
                List<string> AllTabs = new List<string>();
                if (TabCollections.Count > 1)
                {
                    tabhandle = TabCollections[1].Current.NativeWindowHandle;
                    AllTabs = GetTabNames(TabCollections[1]);
                }
                else if (TabCollections.Count == 0)
                {
                    return;
                }
                else
                {
                    tabhandle = TabCollections[0].Current.NativeWindowHandle;
                    AllTabs = GetTabNames(TabCollections[0]);
                }

                int pos = 0;
                int count = 0;
                foreach (string tab in AllTabs)
                {
                    if (tab.Contains(tabName))
                    {
                        pos = count;
                    }
                    count++;
                }
                //Left Key
                for (int i = 0; i < count; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000025, (IntPtr)(0x001E0001)); }

                ////Right Key
                for (int i = 0; i < pos; i++)
                { SendMessage((IntPtr)tabhandle, (uint)0x0100, (UIntPtr)0x00000027, (IntPtr)(0x001E0001)); }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Check whether Sub tab (like Documents,Notes) is present or not.
        /// 
        /// </summary>
        /// <param name="subTabName">Exact Name of Sub Tab</param>
        /// <returns>true if present, else false.</returns>
        public static bool CheckSubTabExistByExactName(string subTabName)
        {
            bool isSubTabPresent = false;
            PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
            AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
            List<string> AllTabs = new List<string>();
            int tabhandle = TabCollections[0].Current.NativeWindowHandle;
            AllTabs = GetTabNames(TabCollections[0]);

            foreach (string tab in AllTabs)
            {
                if (tab.Equals(subTabName))
                {
                    isSubTabPresent = true;
                    break;
                }
            }

            return isSubTabPresent;
        }

        /// <summary>
        /// Check whether Main tab (like Inbox, Open - Client Request) is present or not.
        /// </summary>
        /// <param name="mainTabName">Exact Name of Main Tab</param>
        /// <returns>true if present, else false.</returns>
        public static bool CheckMainTabExistByExactName(string mainTabName)
        {
            bool isMainTabPresent = false;
            PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
            AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
            int tabhandle;
            List<string> AllTabs = new List<string>();
            if (TabCollections.Count > 1)
            {
                tabhandle = TabCollections[1].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[1]);
            }
            else if (TabCollections.Count == 0)
            {
                return false;
            }
            else
            {
                tabhandle = TabCollections[0].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[0]);
            }

            foreach (string tab in AllTabs)
            {
                if (tab.Equals(mainTabName))
                {
                    isMainTabPresent = true;
                    break;
                }
            }
            return isMainTabPresent;
        }

        /// <summary>
        /// Check whether Sub tab (like Documents,Notes) is present or not.
        /// Also checks for similar names.
        /// </summary>
        /// <param name="subTabName">Full Name or Part of the Name of Sub Tab</param>
        /// <returns>true if present, else false.</returns>
        public static bool CheckSubTabExistBySimilarName(string subTabName)
        {
            bool isSubTabPresent = false;
            PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
            AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
            List<string> AllTabs = new List<string>();
            int tabhandle = TabCollections[0].Current.NativeWindowHandle;
            AllTabs = GetTabNames(TabCollections[0]);

            foreach (string tab in AllTabs)
            {
                if (tab.Contains(subTabName))
                {
                    isSubTabPresent = true;
                    break;
                }
            }

            return isSubTabPresent;
        }

        /// <summary>
        /// Check whether Main tab (like Inbox, Open - Client Request) is present or not.
        /// Also checks for similar names.
        /// </summary>
        /// <param name="mainTabName">Full Name or Part of the Name of Main Tab</param>
        /// <returns>true if present, else false.</returns>
        public static bool CheckMainTabExistBySimilarName(string mainTabName)
        {
            bool isMainTabPresent = false;
            PropertyCondition pCDocumentTab = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab);
            AutomationElementCollection TabCollections = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCDocumentTab);
            int tabhandle;
            List<string> AllTabs = new List<string>();
            if (TabCollections.Count > 1)
            {
                tabhandle = TabCollections[1].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[1]);
            }
            else if (TabCollections.Count == 0)
            {
                return false;
            }
            else
            {
                tabhandle = TabCollections[0].Current.NativeWindowHandle;
                AllTabs = GetTabNames(TabCollections[0]);
            }

            foreach (string tab in AllTabs)
            {
                if (tab.Contains(mainTabName))
                {
                    isMainTabPresent = true;
                    break;
                }
            }
            return isMainTabPresent;


        }







        /// <summary>
        /// Select and Click on a Tree Item
        /// </summary>
        /// <param name="task">Name of the Tree Item</param>
        public static void SelectItemFromTree(string task)
        {

            try
            {
                PropertyCondition pCTree = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tree);
                AutomationElementCollection TreeCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pCTree);


                if (TreeCollection != null && TreeCollection.Count > 0)
                {
                    TreeNode treeNode = new TreeNode();
                    PropertyCondition subautomationIdCondition_WFMTree = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TreeItem);
                    foreach (AutomationElement tree in TreeCollection)
                    {
                        AutomationElement elementNode = TreeWalker.ContentViewWalker.GetFirstChild(tree);
                        foreach (AutomationElement firstnode in elementNode.FindAll(TreeScope.Element, subautomationIdCondition_WFMTree))
                        {
                            if (firstnode.Current.Name.Equals(task))
                            {
                                SelectionItemPattern dataItem11 = (SelectionItemPattern)firstnode.GetCurrentPattern(SelectionItemPatternIdentifiers.Pattern);
                                dataItem11.Select();
                                dataItem11.AddToSelection();

                            }
                            foreach (AutomationElement secondInnerNode in firstnode.FindAll(TreeScope.Children, subautomationIdCondition_WFMTree))
                            {

                                if (secondInnerNode.Current.Name.Equals(task))
                                {
                                    SelectionItemPattern dataItem11 = (SelectionItemPattern)secondInnerNode.GetCurrentPattern(SelectionItemPatternIdentifiers.Pattern);
                                    dataItem11.Select();
                                    dataItem11.AddToSelection();
                                }
                                ExpandCollapsePattern secondNodeExp = secondInnerNode.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                                ExpandCollapseState secondState = secondNodeExp.Current.ExpandCollapseState;
                                if (secondState.ToString().Equals("Collapsed"))
                                {
                                    //secondNodeExp.Expand();
                                }
                                foreach (AutomationElement thirdInnerNode in secondInnerNode.FindAll(TreeScope.Children, subautomationIdCondition_WFMTree))
                                {
                                    if (thirdInnerNode.Current.Name.Equals(task))
                                    {
                                        SelectionItemPattern dataItem11 = (SelectionItemPattern)thirdInnerNode.GetCurrentPattern(SelectionItemPatternIdentifiers.Pattern);
                                        dataItem11.Select();
                                        dataItem11.AddToSelection();
                                    }
                                }

                            }
                        }
                    }



                }
            }
            catch (Exception ex)
            {
            }


        }




        /// <summary>
        /// To Set a value in comboBox. For editable combobox only.(Like 'Subject' in Notes tab)
        /// </summary>
        /// <param name="comboBoxName">Name of the combobox control</param>
        /// <param name="value">Value to be set</param>
        public static void SetTextinComboBoxByName(string comboBoxName, string value)
        {
            try
            {
                AndCondition pC = new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit), new PropertyCondition(AutomationElement.NameProperty, comboBoxName));
                AutomationElement comboBoxCollection = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, pC);
                ValuePattern ptrnComboBox = (ValuePattern)comboBoxCollection.GetCurrentPattern(ValuePattern.Pattern);
                ptrnComboBox.SetValue(value);
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// To Set a value in comboBox. For editable combobox only.(Like 'Subject' in Notes tab)
        /// </summary>
        /// <param name="comboBoxName">Name of the combobox control</param>
        /// <param name="value">Value to be set</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void SetTextinComboBoxByName(string comboBoxName, string value, AutomationElement AE)
        {
            try
            {
                AndCondition pC = new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit), new PropertyCondition(AutomationElement.NameProperty, comboBoxName));
                AutomationElement comboBoxCollection = AE.FindFirst(TreeScope.Subtree, pC);
                ValuePattern ptrnComboBox = (ValuePattern)comboBoxCollection.GetCurrentPattern(ValuePattern.Pattern);
                ptrnComboBox.SetValue(value);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Select item in ComboBox. For any type of comboBox. Maze karo ;)
        /// </summary>
        /// <param name="itemName">Name of Item to be selected</param>
        /// <param name="comboBoxName">Name of the combobox</param>
        /// <param name="aE">AutomationElement of the window. For default window use <b>AutomationAPI.GPSApplication</b></param>
        public static void SelectIteminComboBoxByName(string itemName, string comboBoxName, AutomationElement aE)
        {
            try
            {
                PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
                PropertyCondition pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AndCondition pC = new AndCondition(pC0, pC1);
                AutomationElement aEComboBoxEditControl = aE.FindFirst(TreeScope.Subtree, pC);
                IntPtr comboBoxEditHandle = (IntPtr)aEComboBoxEditControl.Current.NativeWindowHandle;

                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x01500001);
                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x01500001);

                Thread.Sleep(1000);


                pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List);
                pC = new AndCondition(pC0, pC1);
                AutomationElement aEComboBoxListControl = aE.FindFirst(TreeScope.Subtree, pC);
                IntPtr comboBoxListHandle = (IntPtr)aEComboBoxListControl.Current.NativeWindowHandle;

                PropertyCondition pCForListItems = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
                AutomationElementCollection aEListCollection = aEComboBoxListControl.FindAll(TreeScope.Subtree, pCForListItems);

                List<string> ListItemNames = new List<string>();
                foreach (AutomationElement aEListItem in aEListCollection)
                {
                    ListItemNames.Add(aEListItem.Current.Name);
                }

                int pos = 0;

                foreach (string listItemName in ListItemNames)
                {
                    if (listItemName.Equals(itemName))
                    {
                        break;
                    }
                    pos++;
                }


                for (int i = 0; i < ListItemNames.Count; i++)
                {
                    SendMessage(comboBoxListHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x01500001);
                }

                for (int i = 0; i < pos; i++)
                {
                    SendMessage(comboBoxListHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x01500001);
                }

                SendMessage(comboBoxListHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
                SendMessage(comboBoxListHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Select item in ComboBox. For any type of comboBox. Maze karo ;)
        /// </summary>
        /// <param name="index">Zero based index of Item to be selected</param>
        /// <param name="comboBoxName">Name of the combobox</param>
        /// <param name="aE">AutomationElement of the window. For default window use AutomationAPI.GPSApplication</param>
        public static void SelectIteminComboBoxByIndex(int index, string comboBoxName, AutomationElement aE)
        {
            try
            {
                PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
                PropertyCondition pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AndCondition pC = new AndCondition(pC0, pC1);
                AutomationElement aEComboBoxEditControl = aE.FindFirst(TreeScope.Subtree, pC);
                IntPtr comboBoxEditHandle = (IntPtr)aEComboBoxEditControl.Current.NativeWindowHandle;

                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x01500001);
                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x01500001);

                Thread.Sleep(1000);


                pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List);
                pC = new AndCondition(pC0, pC1);
                AutomationElement aEComboBoxListControl = aE.FindFirst(TreeScope.Subtree, pC);
                IntPtr comboBoxListHandle = (IntPtr)aEComboBoxListControl.Current.NativeWindowHandle;

                PropertyCondition pCForListItems = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
                AutomationElementCollection aEListCollection = aEComboBoxListControl.FindAll(TreeScope.Subtree, pCForListItems);

                List<string> ListItemNames = new List<string>();
                foreach (AutomationElement aEListItem in aEListCollection)
                {
                    ListItemNames.Add(aEListItem.Current.Name);
                }

                for (int i = 0; i < ListItemNames.Count; i++)
                {
                    SendMessage(comboBoxListHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x01500001);
                }

                for (int i = 0; i < index; i++)
                {
                    SendMessage(comboBoxListHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x01500001);
                }

                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
                SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        ///Read entire DataGrid. [ Currently limited to read first 8 collumns only ]
        ///W.I.P.
        /// </summary>
        /// <returns>DataTable consisting of values from DataGrid</returns>
        public static DataTable ReadDataGrid()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                AutomationElement dataGrid = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataGrid));
                TablePattern tablePattern = dataGrid.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                int rows = tablePattern.Current.RowCount;
                int collumns = tablePattern.Current.ColumnCount;
                AutomationElement[] collumnHeaders = tablePattern.Current.GetColumnHeaders();
                List<string> collumnNamesList = new List<string>(); ;

                for (int i = 0; i < collumnHeaders.Length; i++)
                {
                    string collumnName = collumnHeaders[i].Current.Name;
                    if (!String.IsNullOrEmpty(collumnName) && !collumnName.Equals("Primary Key") && !collumnName.Equals("Timestamp"))
                    {
                        dt.Columns.Add(collumnName);
                        collumnNamesList.Add(collumnName);
                    }
                }

                if (collumnNamesList.Count > 8)
                {
                    collumns = 8;
                }


                DataRow dr = null;
                for (int i = 0; i < rows; i++)
                {
                    int index = 0;
                    for (int j = 1; j < collumns; j++)
                    {
                        string item = tablePattern.GetItem(i, j).Current.Name;
                        if (!String.IsNullOrEmpty(item))
                        {
                            if (dr == null)
                            { dr = dt.NewRow(); }
                            dr[collumnNamesList[index]] = item;
                            index++;
                        }
                    }
                    if (dr != null)
                        dt.Rows.Add(dr);
                    dr = null;
                }

            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        /// <summary>
        ///Read entire DataGrid. [ Currently limited to read first 8 collumns only ]
        ///W.I.P.
        /// </summary>
        /// <param name="aE">Automation Element of the Pop Up window</param>
        /// <returns>DataTable consisting of values from DataGrid</returns>
        public static DataTable ReadDataGrid(AutomationElement aE)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                AutomationElement dataGrid = aE.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataGrid));
                TablePattern tablePattern = dataGrid.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                int rows = tablePattern.Current.RowCount;
                int collumns = tablePattern.Current.ColumnCount;
                AutomationElement[] collumnHeaders = tablePattern.Current.GetColumnHeaders();
                List<string> collumnNamesList = new List<string>(); ;

                for (int i = 0; i < collumnHeaders.Length; i++)
                {
                    string collumnName = collumnHeaders[i].Current.Name;
                    if (!String.IsNullOrEmpty(collumnName) && !collumnName.Equals("Primary Key") && !collumnName.Equals("Timestamp"))
                    {
                        dt.Columns.Add(collumnName);
                        collumnNamesList.Add(collumnName);
                    }
                }

                if (collumnNamesList.Count > 8)
                {
                    collumns = 8;
                }


                DataRow dr = null;
                for (int i = 0; i < rows; i++)
                {
                    int index = 0;
                    for (int j = 1; j < collumns; j++)
                    {
                        string item = tablePattern.GetItem(i, j).Current.Name;
                        if (!String.IsNullOrEmpty(item))
                        {
                            if (dr == null)
                            { dr = dt.NewRow(); }
                            dr[collumnNamesList[index]] = item;
                            index++;
                        }
                    }
                    if (dr != null)
                        dt.Rows.Add(dr);
                    dr = null;
                }

            }
            catch (Exception ex)
            {
                int a = 10;
            }
            return dt;
        }


        /// <summary>
        /// Set the focus on Item in DataGrid control
        /// </summary>
        /// <param name="index">Zero based index of the row to be selected</param>
        public static void SetFocusOnIteminDataGrid(int index)
        {
            try
            {
                AutomationElement dataGrid = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataGrid));
                AutomationElementCollection rows = dataGrid.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
                SelectionItemPattern dataItem = (SelectionItemPattern)rows[index].GetCurrentPattern(SelectionItemPatternIdentifiers.Pattern);
                dataItem.Select();
                dataItem.AddToSelection();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Set the focus on Item in DataGrid control
        /// </summary>
        /// <param name="index">Zero based index of the row to be selected</param>
        /// <param name="aE">Automation Element of the Pop Up window</param>
        public static void SetFocusOnIteminDataGrid(int index, AutomationElement aE)
        {
            try
            {
                AutomationElement dataGrid = aE.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataGrid));
                while (dataGrid == null)
                {
                    dataGrid = aE.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataGrid));
                }
                AutomationElementCollection rows = dataGrid.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
                SelectionItemPattern dataItem = (SelectionItemPattern)rows[index].GetCurrentPattern(SelectionItemPatternIdentifiers.Pattern);
                dataItem.Select();
                dataItem.AddToSelection();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To check a checkbox
        /// </summary>
        /// <param name="checkBoxName">Name of the checkbox control</param>
        public static void CheckCheckBoxByName(string checkBoxName)
        {
            try
            {
                AutomationElement aECheckBox = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, checkBoxName));
                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("Off"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To check a checkbox
        /// </summary>
        /// <param name="checkBoxName">Name of the checkbox control</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void CheckCheckBoxByName(string checkBoxName, AutomationElement AE)
        {
            try
            {
                AutomationElement aECheckBox = AE.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, checkBoxName));
                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("Off"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To uncheck a checkbox
        /// </summary>
        /// <param name="checkBoxName">Name of the checkbox control</param>
        public static void UnCheckCheckBoxByName(string checkBoxName)
        {
            try
            {
                AutomationElement aECheckBox = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, checkBoxName));
                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("On"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// To uncheck a checkbox
        /// </summary>
        /// <param name="name">Name of the checkbox control</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void UnCheckCheckBoxByName(string checkBoxName, AutomationElement AE)
        {
            try
            {
                AutomationElement aECheckBox = AE.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, checkBoxName));
                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("On"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To check a checkbox
        /// </summary>
        /// <param name="index">Zero based index of the checkbox control</param>
        public static void CheckCheckBoxByIndex(int index)
        {
            try
            {
                AutomationElementCollection aECheckBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox));
                AutomationElement aECheckBox = aECheckBoxCollection[index];

                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("Off"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// To check a checkbox
        /// </summary>
        /// <param name="index">Zero based index of the checkbox control</param>
        /// <param name="AE"></param>
        public static void CheckCheckBoxByIndex(int index, AutomationElement AE)
        {
            try
            {
                AutomationElementCollection aECheckBoxCollection = AE.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox));
                AutomationElement aECheckBox = aECheckBoxCollection[index];

                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("Off"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To uncheck a checkbox
        /// </summary>
        /// <param name="index">Zero based index of the checkbox control</param>
        public static void UnCheckCheckBoxByIndex(int index)
        {
            try
            {
                AutomationElementCollection aECheckBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox));
                AutomationElement aECheckBox = aECheckBoxCollection[index];

                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("On"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To uncheck a checkbox
        /// </summary>
        /// <param name="index">Zero based index of the checkbox control</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void UnCheckCheckBoxByIndex(int index, AutomationElement AE)
        {
            try
            {
                AutomationElementCollection aECheckBoxCollection = AE.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox));
                AutomationElement aECheckBox = aECheckBoxCollection[index];

                TogglePattern patternCheckBox = aECheckBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState state = patternCheckBox.Current.ToggleState;
                if (state.ToString().Equals("On"))
                {
                    patternCheckBox.Toggle();
                }
            }
            catch (Exception ex)
            {
            }
        }


        [Obsolete("This method is deprecated. Use SetTextInMultiLineTextBoxByIndex() instead.")]
        /// <summary>
        /// To Set value in a multiline textbox ( like Notes)
        /// </summary>
        /// <param name="textBoxName">Name of texbox</param>
        /// <param name="value">Value to be set</param>
        public static void SetTextInMultiLineTextBox(string textBoxName, string value)
        {
            try
            {
                PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, textBoxName);
                PropertyCondition pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);
                AndCondition pC = new AndCondition(pC0, pC1);
                // AutomationElement aE = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, pC);
                AutomationElementCollection multilineTextBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pC);
                int notes = multilineTextBoxCollection[0].Current.NativeWindowHandle;
                SendMessage((IntPtr)notes, WM_SETTEXT, IntPtr.Zero, value);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To Set value in a multiline textbox ( like Notes)
        /// </summary>
        /// <param name="index">Zero based index of multiline textbox</param>
        /// <param name="value">Value to be set</param>
        public static void SetTextInMultiLineTextBoxByIndex(int index, string value)
        {
            try
            {
                PropertyCondition pC = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);
                AutomationElementCollection multilineTextBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Subtree, pC);
                int notes = multilineTextBoxCollection[index].Current.NativeWindowHandle;
                SendMessage((IntPtr)notes, WM_SETTEXT, IntPtr.Zero, "0" + value);
                SendMessage((IntPtr)notes, WM_KEYDOWN, (UIntPtr)0x0000002E, (IntPtr)0x01530001);
                SendMessage((IntPtr)notes, WM_KEYUP, (UIntPtr)0x0000002E, (IntPtr)0x000E0001);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// To Set value in a multiline textbox ( like Notes)
        /// </summary>
        /// <param name="index">Zero based index of multiline textbox</param>
        /// <param name="value">Value to be set</param>
        /// <param name="AE">Automation Element of the Pop Up window</param>
        public static void SetTextInMultiLineTextBoxByIndex(int index, string value, AutomationElement AE)
        {
            try
            {
                PropertyCondition pC = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);
                AutomationElementCollection multilineTextBoxCollection = AE.FindAll(TreeScope.Subtree, pC);
                int notes = multilineTextBoxCollection[index].Current.NativeWindowHandle;
                SendMessage((IntPtr)notes, WM_SETTEXT, IntPtr.Zero, "0" + value);
                SendMessage((IntPtr)notes, WM_KEYDOWN, (UIntPtr)0x0000002E, (IntPtr)0x01530001);
                SendMessage((IntPtr)notes, WM_KEYUP, (UIntPtr)0x0000002E, (IntPtr)0x000E0001);
            }
            catch (Exception ex)
            {
            }
        }

        public static void SelectDateinComboBox(int index, string date)
        {
            PropertyCondition pCTextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AutomationElementCollection textBoxCollection = GPSApplication.FindAll(TreeScope.Subtree, pCTextBoxControl);
            IntPtr handle = (IntPtr)textBoxCollection[index].Current.NativeWindowHandle;

            for (int i = 0; i < 10; i++)
            {
                SendMessage(handle, WM_KEYDOWN, (UIntPtr)0x0000002E, (IntPtr)0x01530001);
                SendMessage(handle, WM_KEYUP, (UIntPtr)0x0000002E, (IntPtr)0x000E0001);
            }

            SendMessage((IntPtr)handle, WM_SETTEXT, IntPtr.Zero, "0" + date);
            SendMessage(handle, WM_KEYDOWN, (UIntPtr)0x0000002E, (IntPtr)0x01530001);
            SendMessage(handle, WM_KEYUP, (UIntPtr)0x0000002E, (IntPtr)0x000E0001);
        }

        public static void SelectDateinComboBox(int index, string date, AutomationElement aE)
        {
            PropertyCondition pCTextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AutomationElementCollection textBoxCollection = aE.FindAll(TreeScope.Subtree, pCTextBoxControl);
            IntPtr handle = (IntPtr)textBoxCollection[index].Current.NativeWindowHandle;

            for (int i = 0; i < 10; i++)
            {
                SendMessage(handle, WM_KEYDOWN, (UIntPtr)0x0000002E, (IntPtr)0x01530001);
                SendMessage(handle, WM_KEYUP, (UIntPtr)0x0000002E, (IntPtr)0x000E0001);
            }

            SendMessage((IntPtr)handle, WM_SETTEXT, IntPtr.Zero, "0" + date);
            SendMessage(handle, WM_KEYDOWN, (UIntPtr)0x0000002E, (IntPtr)0x01530001);
            SendMessage(handle, WM_KEYUP, (UIntPtr)0x0000002E, (IntPtr)0x000E0001);
        }

        public static void PersonalSelectComboboxDeleted(string comboBoxName, AutomationElement aE)
        {
            PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
            PropertyCondition pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AndCondition pC = new AndCondition(pC0, pC1);
            AutomationElement aEComboBoxEditControl = aE.FindFirst(TreeScope.Subtree, pC);
            IntPtr comboBoxEditHandle = (IntPtr)aEComboBoxEditControl.Current.NativeWindowHandle;

            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_D, (IntPtr)0x00200001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.K_D, (IntPtr)0x00200001);

            // SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_I, (IntPtr)0x01500001);
            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);

            Thread.Sleep(1000);
        }
        public static void PersonalSelectComboboxInstalled(string comboBoxName, AutomationElement aE)
        {
            PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
            PropertyCondition pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AndCondition pC = new AndCondition(pC0, pC1);
            AutomationElement aEComboBoxEditControl = aE.FindFirst(TreeScope.Subtree, pC);
            IntPtr comboBoxEditHandle = (IntPtr)aEComboBoxEditControl.Current.NativeWindowHandle;

            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_I, (IntPtr)0x00200001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.K_I, (IntPtr)0x00200001);

            // SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_I, (IntPtr)0x01500001);
            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);

            Thread.Sleep(1000);
        }
        public static void PersonalSelectCombobox(string comboBoxName, WindowsVirtualKey Key, int repeats, AutomationElement aE)
        {
            try
            {
                PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
                PropertyCondition pC1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AndCondition pC = new AndCondition(pC0, pC1);
                AutomationElement aEComboBoxEditControl = aE.FindFirst(TreeScope.Subtree, pC);
                IntPtr comboBoxEditHandle = (IntPtr)aEComboBoxEditControl.Current.NativeWindowHandle;



                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)Key, (IntPtr)0x00200001);
                SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)Key, (IntPtr)0x00200001);
                for (int i = 0; i < repeats; i++)
                {
                    SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x00200001);

                }

                // SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_I, (IntPtr)0x01500001);
                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
                SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);

                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
            }
        }



        public static void PersonalSLAFunctionSelection(string comboBoxName, int shiftUp)
        {
            PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
            PropertyCondition pc1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AutomationElement comboBoxEdit = GPSApplication.FindFirst(TreeScope.Subtree, new AndCondition(pC0, pc1));
            IntPtr comboBoxEditHandle = (IntPtr)comboBoxEdit.Current.NativeWindowHandle;

            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_W, (IntPtr)0x00200001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.K_W, (IntPtr)0x00200001);

            for (int i = 0; i < shiftUp; i++)
            {
                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x00200001);
                //  SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x00200001);
            }

            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            Thread.Sleep(1000);
        }


        public static void PersonalConfigurationTypeFunctionSelection(string comboBoxName, int shiftUp)
        {
            PropertyCondition pC0 = new PropertyCondition(AutomationElement.NameProperty, comboBoxName);
            PropertyCondition pc1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AutomationElement comboBoxEdit = GPSApplication.FindFirst(TreeScope.Subtree, new AndCondition(pC0, pc1));
            IntPtr comboBoxEditHandle = (IntPtr)comboBoxEdit.Current.NativeWindowHandle;

            SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_R, (IntPtr)0x00200001);
            SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.K_R, (IntPtr)0x00200001);

            for (int i = 0; i < shiftUp; i++)
            {
                SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x00200001);
                //  SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_UP, (IntPtr)0x00200001);
            }
 
            
            //SendMessage(comboBoxEditHandle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            //SendMessage(comboBoxEditHandle, WM_CHAR, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x001C0001);
            Thread.Sleep(1000);
        }


        /// <summary>
        /// Not to be used. For Development Purpose Only
        /// </summary>
        public static void Set()
        {

            IntPtr handle = (IntPtr)GPSApplication.Current.NativeWindowHandle;
            SendMessage(handle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.K_0, (IntPtr)0x00110014);


            //IntPtr handle = (IntPtr)aE.Current.NativeWindowHandle;
            //SendMessage(handle, WM_KEYDOWN, (UIntPtr)0x00000041, (IntPtr)0x001E0001);
            //SendMessage(handle, WM_CHAR, (UIntPtr)0x00000061, (IntPtr)0x001E0001);
            //SendMessage(handle, WM_KEYUP, (UIntPtr)0x00000041, (IntPtr)0x001E0001);
            //SendMessage(handle, WM_SETTEXT, IntPtr.Zero,"asdasdasdasd");
        }

        public static void PersonalComboForDeletingSR(int index, string value)
        {
            PropertyCondition pCtextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AutomationElementCollection textBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Descendants, pCtextBoxControl);
            AutomationElement EditControl = textBoxCollection[index];
            IntPtr editControlHandle = (IntPtr)EditControl.Current.NativeWindowHandle;
            PerformGPSActivity.SetIteminComboBox(editControlHandle, value);
        }

        public static void CloseTab(string tab)
        {
            if (AutomationAPI.CheckMainTabExistBySimilarName(tab))
            {
                AutomationAPI.SelectMainTabBySimilarName(tab);
                OpenMenuBarItemsUsingKeyboardAndClose("File", 3);
            }
        }

        public static void SendMessagetoTextBox(int index, WindowsVirtualKey key)
        {
            PropertyCondition pCtextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
            AutomationElementCollection textBoxCollection = AutomationAPI.GPSApplication.FindAll(TreeScope.Descendants, pCtextBoxControl);
            AutomationElement EditControl = textBoxCollection[index];
            IntPtr handle = (IntPtr)EditControl.Current.NativeWindowHandle;
            PostMessage(handle, WM_KEYDOWN, (UIntPtr)key, (IntPtr)0x01530001);
            //  PostMessage(handle, WM_KEYUP, (UIntPtr)key, (IntPtr)0x000E0001);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="choice">1. Company 2. Save 3. Update Inbox</param>
        public static void ClickOnTaskBarItems(int choice)
        {
            PropertyCondition pC = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar);
            AutomationElementCollection col = GPSApplication.FindAll(TreeScope.Subtree, pC);

            IntPtr taskBarHandle = (IntPtr)col[0].Current.NativeWindowHandle;//(IntPtr)0x00121444;
            IntPtr codedCordinates = (IntPtr.Zero);
            switch (choice)
            {
                case 1:
                    codedCordinates = (IntPtr)0x0010004C;
                    break;
                case 2:
                    codedCordinates = (IntPtr)0x000B0063;
                    break;
                case 3:
                    codedCordinates = (IntPtr)0x000E0126;
                    break;
            }
            if (codedCordinates != IntPtr.Zero)
            {
                SendMessage(taskBarHandle, WM_LBUTTONDOWN, (UIntPtr)0x00000001, codedCordinates);
                SendMessage(taskBarHandle, WM_LBUTTONUP, (UIntPtr)0x00000000, codedCordinates);
            }

        }



        /// <summary>
        /// Button Click using Send MEssage to prevent unnecessary focusing of application
        /// </summary>
        /// <param name="buttonName"></param>
        public static void ButtonClickBySendMessage(string buttonName)
        {

            PropertyCondition pcButtonControl1 = new PropertyCondition(AutomationElement.NameProperty, buttonName);
            PropertyCondition pcButtonControl0 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
            AutomationElement buttonControl = AutomationAPI.GPSApplication.FindFirst(TreeScope.Subtree, new AndCondition(pcButtonControl0, pcButtonControl1));
            IntPtr controlHandle = (IntPtr)buttonControl.Current.NativeWindowHandle;


            SendMessage(controlHandle, BM_CLICK, (UIntPtr)0x0, (IntPtr)0x0);
        }





        /// <summary>
        /// Maximize the Window
        /// </summary>
        /// <param name="handle">windowhandle</param>
        public static void Maximize(Int32 handle)
        {
            ShowWindow(handle, SW_SHOWMAXIMIZED);
        }

        public static void PostDeleteKeytoTextBox(int index, AutomationElement aE)
        {
            try
            {
                PropertyCondition pCTextBoxControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                AutomationElementCollection textBoxCollection = aE.FindAll(TreeScope.Subtree, pCTextBoxControl);
                IntPtr handle = (IntPtr)textBoxCollection[index].Current.NativeWindowHandle;

                PostMessage(handle, WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DELETE, (IntPtr)0x01530001);
                PostMessage(handle, WM_KEYUP, (UIntPtr)WindowsVirtualKey.VK_DELETE, (IntPtr)0x01530001);

            }
            catch (Exception)
            {
            }

        }
        static PropertyCondition pCFileControl = new PropertyCondition(AutomationElement.NameProperty, "File");
        static AutomationElement aEFileControl = null;
        static ExpandCollapsePattern patternFileControl = null;
        //public static void File_Close()
        //{

        //    try
        //    {
        //        Thread.Sleep(1000);
        //        if (aEFileControl == null)
        //        {
        //            aEFileControl = GPSApplication.FindFirst(TreeScope.Subtree, pCFileControl);
        //            patternFileControl = aEFileControl.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
        //        }
        //        BlockInput(true);


        //        PropertyCondition pCControl = new PropertyCondition(AutomationElement.NameProperty, "Inbox");
        //        AutomationElement aEControl;
        //        do
        //        {
        //            patternFileControl.Expand();
        //            aEControl = GPSApplication.FindFirst(TreeScope.Subtree, pCControl);

        //        } while (aEControl == null);


        //        PropertyCondition pCControl1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu);
        //        AutomationElement aEControlColl = GPSApplication.FindFirst(TreeScope.Subtree, pCControl1);
        //        IntPtr aEHandle = (IntPtr)aEControlColl.Current.NativeWindowHandle;

        //        for (int j = 0; j < 3; j++)
        //        {
        //            SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_DOWN, (IntPtr)0x11500001);
        //        }
        //        SendMessage(aEHandle, (uint)WM_KEYDOWN, (UIntPtr)WindowsVirtualKey.VK_RETURN, (IntPtr)0x101C0001);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {
        //        BlockInput(false);
        //    }

        //}
        public static void File_Close()
        {
        //    AutomationAPI.OpenMenuBarItemsUsingKeyboard("Open - Service Request", "File", 1, 0, 2);
            Menu("File",3 );
        }
    }
}

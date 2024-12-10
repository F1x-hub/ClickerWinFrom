using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp25
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Constants for mouse events
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private const int HOTKEY_ID = 1;
        private readonly string settingsFile = "appsettings.json";

        private bool isClicking = false; // Clicking state
        private Thread clickerThread;
        private Keys currentHotKey;
        public Form1()
        {
            InitializeComponent();

            LoadHotKeyFromSettings();

            RegisterCurrentHotKey();

            this.TopMost = true;
        }

        private void lblCPS_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartClicker();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopClicker();
        }

        private void RegisterCurrentHotKey()
        {
            // Unregister previous hotkey
            UnregisterHotKey(this.Handle, HOTKEY_ID);

            // Register new hotkey
            if (!RegisterHotKey(this.Handle, HOTKEY_ID, 0, (int)currentHotKey))
            {
                MessageBox.Show($"Failed to register hotkey {currentHotKey}. Try running as administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnStart.Text = $"Start ({currentHotKey})";
            btnStop.Text = $"Stop ({currentHotKey})";
        }

        private void StartClicker()
        {
            if (!int.TryParse(txtSeconds.Text, out int seconds) || seconds < 0)
            {
                MessageBox.Show("Please enter a valid number for seconds.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMilliseconds.Text, out int milliseconds) || milliseconds < 0 || milliseconds >= 1000)
            {
                MessageBox.Show("Please enter a valid number for milliseconds (0-999).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int interval = (seconds * 1000) + milliseconds;
            if (interval <= 0)
            {
                MessageBox.Show("The interval must be greater than 0 milliseconds.", "Invalid Interval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isClicking = true;
            lblStatus.Text = "Status: Running";

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            clickerThread = new Thread(() => AutoClick(interval));
            clickerThread.IsBackground = true;
            clickerThread.Start();
        }

        private void StopClicker()
        {
            isClicking = false;
            lblStatus.Text = "Status: Stopped";

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            clickerThread?.Join();
        }

        private void AutoClick(int interval)
        {
            while (isClicking)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                Thread.Sleep(interval);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                if (isClicking)
                    StopClicker();
                else
                    StartClicker();
            }

            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
            StopClicker();
            base.OnFormClosing(e);
        }

        private void chkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkTopMost.Checked;
        }

        private void btnChangeHotKey_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press any key to set it as the new hotkey.", "Change Hotkey", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDownForHotKey;
        }

        private void Form1_KeyDownForHotKey(object sender, KeyEventArgs e)
        {
            currentHotKey = e.KeyCode;
            RegisterCurrentHotKey();

            SaveHotKeyToSettings();

            MessageBox.Show($"Hotkey changed to {currentHotKey}.", "Hotkey Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Unsubscribe from KeyDown event to prevent further changes
            this.KeyDown -= Form1_KeyDownForHotKey;
            this.KeyPreview = false;
        }

        private void SaveHotKeyToSettings()
        {
            var settings = new { HotKey = currentHotKey.ToString() };
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(settingsFile, json);
        }

        private void LoadHotKeyFromSettings()
        {
            if (File.Exists(settingsFile))
            {
                try
                {
                    var json = File.ReadAllText(settingsFile);
                    var settings = JsonSerializer.Deserialize<HotKeySettings>(json);

                    if (Enum.TryParse(settings.HotKey, out Keys savedHotKey))
                    {
                        currentHotKey = savedHotKey;
                    }
                    else
                    {
                        currentHotKey = Keys.F4; // Default if parsing fails
                    }
                }
                catch
                {
                    currentHotKey = Keys.F4; // Default in case of error
                }
            }
            else
            {
                currentHotKey = Keys.F4; // Default if file doesn't exist
            }
        }

        private class HotKeySettings
        {
            public string HotKey { get; set; }
        }

    }
}

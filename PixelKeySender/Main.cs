using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace PixelKeySender
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);

        private readonly Timer _timer;
        private IntPtr _targetHandle;
        private int _x, _y;

        public Main()
        {
            InitializeComponent();

            //Timer
            _timer = new Timer();
            _timer.Tick += TimerTick;

            //Processes
            BindProcessesList();
        }

        private void BindProcessesList()
        {
            ddlProcesses.Items.Clear();
            var processes = Process.GetProcesses().OrderBy(x => x.ProcessName).Select(x => x.ProcessName).ToList();
            ddlProcesses.Items.AddRange(processes.ToArray());

            var wowProcess = processes.FirstOrDefault(x => x.StartsWith("Wow") || x.StartsWith("WowB"));

            ddlProcesses.SelectedIndex = wowProcess != null ? processes.IndexOf(wowProcess) : 0;
        }

        private void Start()
        {
            if (ddlProcesses.SelectedItem == null || !int.TryParse(txtPixelX.Text, out _x) || !int.TryParse(txtPixelY.Text, out _y))
            {
                MessageBox.Show("I need all details filled!", "Error", MessageBoxButtons.OK);
                return;
            }

            ToggleControls(false);

            var targetProcess = Process.GetProcessesByName(ddlProcesses.Text).FirstOrDefault();

            _targetHandle = targetProcess.MainWindowHandle;
            _timer.Interval = int.Parse(txtInterval.Text);
            _timer.Start();
        }

        private void Stop()
        {
            ToggleControls(true);
            _timer.Stop();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var activeHandle = GetForegroundWindow();

            //Ignore other windows to avoid spam/lock
            if (activeHandle != _targetHandle) return;

            var pixelColor = GetColorAt(_x, _y);
            if (pixelColor == Color.Black) return;

            var sim = new InputSimulator();
            var num = default(VirtualKeyCode);

            // G = num
            switch (pixelColor.G)
            {
                case 1:
                    num = VirtualKeyCode.F1;
                    break;
                case 2:
                    num = VirtualKeyCode.F2;
                    break;
                case 3:
                    num = VirtualKeyCode.F3;
                    break;
                case 4:
                    num = VirtualKeyCode.F4;
                    break;
                case 5:
                    num = VirtualKeyCode.F5;
                    break;
                case 6:
                    num = VirtualKeyCode.F6;
                    break;
                case 7:
                    num = VirtualKeyCode.F7;
                    break;
                case 8:
                    num = VirtualKeyCode.F8;
                    break;
                case 9:
                    num = VirtualKeyCode.F9;
                    break;
                case 10:
                    num = VirtualKeyCode.F10;
                    break;
                case 11:
                    num = VirtualKeyCode.F11;
                    break;
                case 12:
                    num = VirtualKeyCode.F12;
                    break;
            }

            //R = mod
            if (pixelColor.R > 0)
            {
                var mod = default(VirtualKeyCode);
                switch (pixelColor.R)
                {
                    case 1:
                        mod = VirtualKeyCode.MENU;
                        break;
                    case 2:
                        mod = VirtualKeyCode.CONTROL;
                        break;
                    case 3:
                        mod = VirtualKeyCode.SHIFT;
                        break;
                }

                sim.Keyboard.ModifiedKeyStroke(mod, num);
            }
            else
            {
                sim.Keyboard.KeyPress(num);
            }
        }

        private void StartClick(object sender, EventArgs e)
        {
            Start();
        }

        private void StopClick(object sender, EventArgs e)
        {
            Stop();
        }

        private void ToggleControls(bool enabled)
        {
            txtInterval.Enabled = enabled;
            ddlProcesses.Enabled = enabled;
            btnStart.Enabled = enabled;
            txtPixelX.Enabled = enabled;
            txtPixelY.Enabled = enabled;
            btnRefresh.Enabled = enabled;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindProcessesList();
        }

        public Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
    }
}

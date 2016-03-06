using System;
using System.Data;
using System.Diagnostics;
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

        private readonly Timer _timer;
        private IntPtr _targetHandle;
        public Main()
        {
            InitializeComponent();

            //Timer
            _timer = new Timer();
            _timer.Tick += TimerTick;

            //Target
            var process = Process.GetProcessById(23508);
            _targetHandle = process.MainWindowHandle;

            //Processes
            BindProcessesList();
        }

        private void BindProcessesList()
        {
            ddlProcesses.DisplayMember = "Name";
            ddlProcesses.ValueMember = "MainHandle";
            ddlProcesses.Items.AddRange(Process.GetProcesses().OrderBy(x => x.ProcessName).Select(x => new ProcessListItem { Name = x.ProcessName, MainHandle = x.MainWindowHandle }).ToArray());
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var activeWin = GetForegroundWindow();

            if (activeWin != _targetHandle) return;

            var sim = new InputSimulator();
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            //sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_F);
        }

        private void StartClick(object sender, EventArgs e)
        {
            txtInterval.Enabled = false;
            ddlProcesses.Enabled = false;
            btnStart.Enabled = false;

            _targetHandle = ((ProcessListItem)ddlProcesses.SelectedItem).MainHandle;
            _timer.Interval = int.Parse(txtInterval.Text);
            _timer.Start();
        }

        private void StopClick(object sender, EventArgs e)
        {
            txtInterval.Enabled = true;
            ddlProcesses.Enabled = true;
            btnStart.Enabled = true;

            _timer.Stop();
        }
    }
}

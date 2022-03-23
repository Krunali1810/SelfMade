using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowsService1.BAL;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private string param ="";
        private string filepath = "FilePath";
        private int stdId = 0;
        private const string ErrorSource = "Student Status Service";
        private const string errorMessage = "StdID is missing";     
        private Timer _timer;
        private string APP_CONFIG_TIMER_INTERVAL = "";
        public Service1()
        {
            InitializeComponent();
        }

        #region privateMethod
        public void WriteMsg(string inPut)
        {
            filepath = ConfigurationManager.AppSettings[filepath] + DateTime.Today.ToString("dd-MM-yy") + ".txt";     
            if (!File.Exists(filepath))
            {
               File.Create(filepath).Dispose();
            }

            if (stdId == 0 )  
            {
                EventLog ev = new EventLog();
                ev.Source = ErrorSource;
                ev.WriteEntry(errorMessage, EventLogEntryType.Error);
                this.Stop();
            }

           if (inPut == "Start")
           {
              _timer = new Timer();
              string timerInterval = ConfigurationManager.AppSettings[APP_CONFIG_TIMER_INTERVAL];

                if (timerInterval == "")
                {
                    _timer.Interval =Convert.ToDouble(timerInterval);
                }
                else
                {
                    _timer.Interval = 2000;
                }

                _timer.Elapsed += new ElapsedEventHandler(_emailTimer_Elapsed);
                _timer.Enabled = true;

                using (StreamWriter sw=File.AppendText(filepath))
                {
                  sw.WriteLine("Saved successfully");
                  sw.Dispose();
                  sw.Close();
                }
            }
            else if (inPut== "Stop")
              {
                base.Stop();
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("Service going to stop");
                    sw.Dispose();
                    sw.Close();
                }
            }
        }

        private void _emailTimer_Elapsed(object sender,ElapsedEventArgs e)
        {
            try 
            {
                TestServiceEO testService = new TestServiceEO();
                //testService
            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        protected override void OnStart(string[] args)
        {
            #region Debug
              Debugger.Launch();
            #endregion
            param = "Start";
            WriteMsg(param);
        }
        protected override void OnStop()
        {
            param = "Stop";
            WriteMsg(param);
        }

        #region commentedCode
        //string ProgramPath = @"\ScreenSaverSample1\bin\Debug\ScreenSaverSample1.exe";
        //filepath = Environment.CurrentDirectory;
        //string projectDirectory = Directory.GetParent(filepath).Parent.FullName.ToString();

        //ProcessStartInfo info = new ProcessStartInfo("E:\\Krunali\\Testing\\MiniCalculator\\bin\\Debug\\netcoreapp3.1\\MiniCalculator.exe");
        //info.UseShellExecute = false;
        //info.RedirectStandardError = true;
        //info.RedirectStandardInput = true;
        //info.RedirectStandardOutput = true;
        //info.CreateNoWindow = true;
        //info.ErrorDialog = false;
        //info.WindowStyle = ProcessWindowStyle.Maximized;
        //Process process = Process.Start(info);

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;



namespace Ver
{

    public partial class Form1 : Form
    {

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        protected static extern int mciSendString(string lpstrCommand,
        StringBuilder lpstrReturnString,
        int uReturnLength,
        IntPtr hwndCallback);
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Veronica = new SpeechSynthesizer();
        string QEvent;
        string ProcWindow;
        string BrowseDirectory;
        double timer = 10;
        int count = 1;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"D:\Veronica\Commands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            Veronica.Speak("Veronica AT YOUR SERVICE");
        }
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum = rnd.Next(1, 100);
            string speech = e.Result.Text;
            switch (speech)
            {
                //GREETINGS
                case "hello":
                case "hello veronica":
                    if (ranNum < 6) { Veronica.Speak("Hello SIR HOW CAN I HELP YOU"); }
                    else if (ranNum > 5) { Veronica.Speak("Hi");
                    }
                    break;
                case "goodbye":
                case "goodbye veronica":
                case "close":
                case "close veronica":
                    Veronica.Speak("Until next time");
                    Close();
                    break;
                case "veronica":
                    if (ranNum < 5) { QEvent = ""; Veronica.Speak("Yes sir"); }
                    else if (ranNum > 4) { QEvent = ""; Veronica.Speak("Yes?"); }
                    break;

                //WEBSITES
                case "open google":
                  //  pbLoad.Visible = true;
                   // pbLoad.Image = Properties.Resources.google_blue_as_in_logo;
                    Veronica.Speak("On my way Sir");
                    System.Diagnostics.Process.Start("https://www.google.com");
                    //pbLoad.Visible = false;
                    break;

                case "open facebook":
                   // pbLoad.Image = Properties.Resources._098758_blue_white_pearl_icon_social_media_logos_facebook_logo_square;
                   // pbLoad.Visible = true;
                  //  pbLoad.Image = Properties.Resources.facebook_logo_vector_ai;
                    //pbVer.Image = Properties.Resources.q5xoOs47_2309132152411__1_;
                    Veronica.Speak("On my way Sir");
                 
                    System.Diagnostics.Process.Start("https://www.facebook.com");
                   // pbLoad.Visible = false;
                    break;

                //SHELL COMMANDS
                case "open firefox":

                    System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                    Veronica.Speak("Loading");
                    break;
                case "open itunes":
                case "switch to itunes":

                    System.Diagnostics.Process.Start(@"C:\Program Files (x86)\iTunes\iTunes.exe");
                   Veronica.Speak("Loading Itunes");

                    break;


                //CLOSE PROGRAMS
                case "close firefox":   
                    ProcWindow = "firefox";
                    StopWindow();
                    break;
               
                case "close itunes":
                    Veronica.Speak("Allright ...");
                    ProcWindow = "itunes";
                   
                    StopWindow();
                    break;
                case "close chrome":
                    SendKeys.Send("^W");
                    break;
                //CONDITION OF DAY
                case "what time is it":
                    DateTime now = DateTime.Now;
                    string time = now.GetDateTimeFormats('t')[0];
                    Veronica.Speak(time);
                    break;
                case "what day is it":
                    Veronica.Speak(DateTime.Today.ToString("dddd"));
                    break;
                case "whats the date":
                case "whats todays date":
                    Veronica.Speak(DateTime.Today.ToString("dd-MM-yyyy"));
                    break;

                //OTHER COMMANDS
                case "go fullscreen":
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                    Veronica.Speak("expanding");
                    break;
                case "exit fullscreen":
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    TopMost = false;
                    break;
                case "switch window":
                 //   SendKeys.Send("{^} {%} {DELETE}");
                    SendKeys.Send("%{TAB " +count+ "}");
                    count += 1;
                    break;
                case "reset":
                    count = 1;
                    timer = 11;
                    lblTimer.Visible = false;
                    ShutdownTimer.Enabled = false;
                    lstCommands.Visible = false;
                    Veronica.Speak("Online and Ready");
                    break;
                case "out of the way":
                    if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                    {
                        WindowState = FormWindowState.Minimized;
                        Veronica.Speak("My apologies");
                    }
                    break;
                case "come back":
                    if (WindowState == FormWindowState.Minimized)
                    {
                        pbVer.Image = Properties.Resources.cortana;                            
                        Veronica.Speak("Alright?");
                        WindowState = FormWindowState.Normal;
                    }
                    break;
                case "show commands":
                    pbVer.Image = Properties.Resources._19fkkb28xdegzjpg;
                    string[] commands = (File.ReadAllLines(@"D:\Veronica\Commands.txt"));
                    Veronica.Speak("Very well");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in commands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;
                case "hide commands":
                    pbVer.Image = Properties.Resources.cortana;
                    lstCommands.Visible = false;
                    break;

                //SHUTDOWN RESTART LOG OFF
                case "shutdown":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "shutdown";
                        Veronica.Speak("I will shutdown shortly");
                        lblTimer.Visible = true;
                        
                        ShutdownTimer.Enabled = true;
                    }
                    break;
                case "log off":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "logoff";
                        Veronica.Speak("Logging off");
                        lblTimer.Visible = true;
                        ShutdownTimer.Enabled = true;
                    }
                    break;
                case "restart":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "restart";
                        Veronica.Speak("I'll be back shortly");
                        lblTimer.Visible = true;
                        ShutdownTimer.Enabled = true;
                    }
                    break;
                case "abort":
                    if (ShutdownTimer.Enabled == true)
                    {
                        QEvent = "abort";
                    }
                    break;
                case "speed up":
                    if (ShutdownTimer.Enabled == true)
                    {
                        ShutdownTimer.Interval = ShutdownTimer.Interval / 10;
                    }
                    break;
                case "slow down":
                    if (ShutdownTimer.Enabled == true)
                    {
                        ShutdownTimer.Interval = ShutdownTimer.Interval * 10;
                    }
                    break;
                // LOAD DIRECTORY 
                case "load music directory":
                    QEvent = "music directory";
                    BrowseDirectory = @"C:\Users\Pratik\Music\";
                    LoadDirectory();
                    Veronica.Speak("Starting up Music");
                    lstCommands.Visible = true;

                    break;
                case "load video directory":
                    QEvent = "video directory";
                    BrowseDirectory = @"C:\Users\Pratik\Videos\";
                    LoadDirectory();
                    lstCommands.Visible = true;
                    Veronica.Speak("Loading Video");
                    break;

                case "load picture directory":
                    QEvent = "picture directory";
                    BrowseDirectory = @"C:\Users\Pratik\Pictures\";
                    LoadDirectory();
                    lstCommands.Visible = true;
                    Veronica.Speak("Loading");

                    break;

                case "browse for directory":
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BrowseDirectory = fbd.SelectedPath;
                    }
                    QEvent = "load directory";
                    LoadDirectory();
                    lstCommands.Visible = true;
                    Veronica.Speak("Right Away");
                    break;

                // ITUNES CONTROL
                case "play":
                case "pause":
                    SendKeys.Send(" ");
                    break;
                case "next songs":
                    SendKeys.Send("^{RIGHT}");
                    break;
                case "go back":
                    SendKeys.Send("^{LEFT}");
                    break;
                case "turn up":
                    SendKeys.Send("^{UP}");
                    break;
                case "turn down":
                    SendKeys.Send("^{DOWN}");
                    break;

                case "new tab":
                    SendKeys.Send("^t");
                    break;

                //Special others
                case "eject":
                    int ret = mciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
                    break;



                // Socail Commands
                case "introduce yourself":
                    Veronica.Speak("Hello Sir, My Name is Veronica , i am a digital life assistant , and i could also help in your daily routine,  just by the power of your voice");
                    break;

                case "crack a joke":
                     ranNum = rnd.Next(1, 100);
                    if (ranNum < 1 && ranNum > 49)
                    {
                        Veronica.Speak("Once a wife said : How would you describe me? , Husband: ABCDEFGHIJK ,Wife: What does that mean Husband Adorable  beautiful cute delightful elegant fashionable gorgeous and hot ,Wife: Awwww thank you, but what about IJK ,Husband: I am just kidding  ");
                        Veronica.Speak(" Sorry Sir it was a pathetic one");
                    }
                    else if (ranNum < 50 && ranNum < 90)
                    {
                        Veronica.Speak("Roses are red,Your blood is too. You look like a monkey And belong in a zoo. Do not worry, I will be there too. Not in the cage, But laughing at you.");
                        Veronica.Speak("");
                        Veronica.Speak("");
                        Veronica.Speak("");
                        Veronica.Speak("I am just kidding sir , my apologies!!!");
                    }
                    else if (ranNum > 91) { Veronica.Speak("Sorry sir , i cant recollect one "); }
                    break;
                case "i am tired":
                    Veronica.Speak("I would suggest you take a nap sir");
                    break;
                case "good night":
                    Veronica.Speak("Have a good sleep sir");
                    break;
                //case "very good":
                //case "awesome":
                //case "good work":
                //case "excellent":
                //case "your awesome":

                //    Veronica.Speak("Thank you,Sir");


                    break;


                case "bored":
                    
                    if (ranNum > 1 && ranNum < 20)
                    {
                        Veronica.Speak("Okay Sir, i got this ");
                    }
                    else if (ranNum > 21 && ranNum < 100)
                    {
                        Veronica.Speak("Let me think");
                        Thread.Sleep(100);
                      
                        Veronica.Speak("So.....");
                    }
                    if (ranNum > 1 && ranNum < 20)
                    {
                        Veronica.Speak("Opening Facebook");
                        System.Diagnostics.Process.Start("https://www.facebook.com");
                    }
                    else if (ranNum > 21 && ranNum < 40)
                    {
                        Veronica.Speak("Switching to Youtube");
                        System.Diagnostics.Process.Start("https://www.youtube.com");
                    }
                    else if (ranNum > 41 && ranNum < 60)
                    {
                        Veronica.Speak("redirecting  to  songs ");
                        System.Diagnostics.Process.Start("http://www.gaana.com/");

                    }
                    else if (ranNum > 61 && ranNum < 80)
                    {
                        Veronica.Speak("Opening twitter");
                        System.Diagnostics.Process.Start("https://www.twitter.com");

                    }
                    else if (ranNum > 81 && ranNum < 100)
                    {
                        Veronica.Speak("Would you like to play a Online game ?");
                        System.Diagnostics.Process.Start("http://www.miniclip.com/games/en/");
                    }
                    break;
                  
  
            }
        }
        private void ShutdownTimer_Tick(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                lblTimer.Visible = false;
                ComputerTermination();
                ShutdownTimer.Enabled = false;
            }
            else if (QEvent == "abort")
            {
                timer = 10;
                lblTimer.Visible = false;
                ShutdownTimer.Enabled = false;
            }
            else
            {
                timer = timer - .01;
                lblTimer.Text = timer.ToString();
            }
        }
        private void ComputerTermination()
        {
            switch (QEvent)
            {
                case "shutdown":
                   // System.Diagnostics.Process.Start("shutdown", "-s");
                    Veronica.Speak("Shutdown process intialised");
                     ProcessStartInfo shut = new ProcessStartInfo();
            shut.FileName = "shutdown.exe";
           shut.Arguments = "-s -f -t 0";
            shut.CreateNoWindow = true;
            Process p = Process.Start(shut);
                    break;
                case "logoff":
                   // System.Diagnostics.Process.Start("shutdown", "-l");
                    break;
                case "restart":
                    Veronica.Speak("Restart stated");
                  //  System.Diagnostics.Process.Start("shutdown", "-r");
                    ProcessStartInfo psi = new ProcessStartInfo();
                   psi.FileName = "shutdown.exe";
                      psi.Arguments = "-r -f -t 0";
                     psi.CreateNoWindow = true;
                      Process res = Process.Start(psi);
                    break;
            }
        }
        private void StopWindow()
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ProcWindow);
            foreach (System.Diagnostics.Process proc in procs)
            {
                proc.CloseMainWindow();
            }
        }

        private void LoadDirectory()
        {
            lstCommands.Items.Clear();
            switch (QEvent)
            {
                case "music directory":
                    string[] files = Directory.GetFiles(BrowseDirectory, "*.mp3", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        lstCommands.Items.Add(file.Replace(BrowseDirectory, ""));
                    }

                    files = Directory.GetFiles(BrowseDirectory, "*.m4a", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        lstCommands.Items.Add(file.Replace(BrowseDirectory, ""));
                    }
                    break;

                case "video directory":
                    files = Directory.GetFiles(BrowseDirectory, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        lstCommands.Items.Add(file.Replace(BrowseDirectory, ""));
                    }

                    break;

                case "picture directory":
                    files = Directory.GetFiles(BrowseDirectory, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        lstCommands.Items.Add(file.Replace(BrowseDirectory, ""));
                    }

                    break;

                case "load directory":
                    files = Directory.GetFiles(BrowseDirectory, "*.*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        lstCommands.Items.Add(file.Replace(BrowseDirectory , ""));
                    }
                    break;

            }

        }
        
    
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void lstCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object open = BrowseDirectory + lstCommands.SelectedItem;
            try
            {
                System.Diagnostics.Process.Start(open.ToString());

            }
            catch
            {
                open = BrowseDirectory + "\\" + lstCommands.SelectedItem;
                System.Diagnostics.Process.Start(open.ToString());

            }
        }
    }

       
    }


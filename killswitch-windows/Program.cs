using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace killswitch_windows
{
    class Program
    {
        const string assLogo =
    @"
 __   .__.__  .__                  .__  __         .__     
|  | _|__|  | |  |   ________  _  _|__|/  |_  ____ |  |__  
|  |/ /  |  | |  |  /  ___/\ \/ \/ /  \   __\/ ___\|  |  \ 
|    <|  |  |_|  |__\___ \  \     /|  ||  | \  \___|   Y  \
|__|_ \__|____/____/____  >  \/\_/ |__||__|  \___  >___|  /
     \/                 \/                       \/     \/ ";

        static private string vpnNIC;
        static private Int32 nicChoice;
        static private bool isKill;
   
        static void Main(string[] args)
        {

            Console.Write("==============================================================", Color.Blue);
            Console.WriteLine(""+assLogo, Color.Cyan);
            Console.Write("==============================================================", Color.Blue);

            Start();
        }

        static void Start()
        {


            // enable internet connection (it could have been disabled before calling this function)
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "ipconfig";
            info.Arguments = "/renew"; // or /release if you want to disconnect
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();


            // get list of interfaces
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();


            // ask the user which interface the vpn runs on
            Console.WriteLine("\nSelect which network interface your vpn is running on.");
            //foreach (NetworkInterface n in adapters)
            foreach(var x in adapters.Select((value, index) => new { value, index }))
            {
                Console.WriteLine("\t{0} - {1}", x.index, x.value.Name);
            }
            Console.Write(">");
            nicChoice = Convert.ToInt32(Console.ReadLine());


            // store the interface id to a member value so we can compate when we detect a network change 
            vpnNIC = adapters[nicChoice].Id;


            // start listening for a network change
            isKill = false;
            NetworkChange.NetworkAddressChanged += new
            NetworkAddressChangedEventHandler(AddressChangedCallback);
            Console.Write("\n[STARTED]", Color.Green);
            Console.Write(" killswitch is now listening for a change in your supplied interface.");

            // stop the program from terminating so we can keep the listener going
            Console.ReadLine();


        }

        static void AddressChangedCallback(object sender, EventArgs e)
        {
            if (!isKill)
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                Console.Beep(570, 100);
                Console.Beep(570, 100);
                Console.Beep(570, 100);
                Console.Beep(570, 100);
                Console.Write("\r\n[NETWORK CHANGE DETECTED]", Color.Red);
                Console.Write(" Checking if our vpn has been disabled.\n");
                if (adapters[nicChoice].OperationalStatus == OperationalStatus.Down)
                {
                    isKill = true;
                    KillNow();
                    Console.Write("[INTERNET DISABLED]", Color.Red);
                    Console.Write(" your vpn was dissconnected. (restart the kill switch and turn on your vpn before selecting the NIC)");
                }
                
            }

        }

        public static void KillNow()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "ipconfig";
            info.Arguments = "/release";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();
        }


    }
}

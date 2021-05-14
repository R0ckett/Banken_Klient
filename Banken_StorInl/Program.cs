using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.IO;


namespace Banken_StorInl
{
    class Program
    {
        static void Main(string[] args)
        {
            //skapa ip och port (= socket)
            string ip = "127.0.0.1";
            int port = 8001;
            List<Kund> Kunder = new List<Kund>();
            Kunder = BegärMeddelande(ip, port);

            int kundNum = 0;

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("\n   Vad vill du göra?");
                Console.WriteLine("   Skapa ny kund (1)");
                Console.WriteLine("   Skapa ett nytt konto för nuvarande kund (2)");
                Console.WriteLine("   Sätt in pengar på konto (3)");
                Console.WriteLine("   Ta ut pengar från konto (4) ");
                Console.WriteLine("   Ta bort konto (5) ");
                Console.WriteLine("   Ta bort kund (6)");
                Console.WriteLine("   Presentera Kunder (7)");
                Console.WriteLine("   Avsluta programmet (8)");
                
                Console.Write("\n   Ditt val: ");
                string menuChoice = Console.ReadLine();
                if (menuChoice != "1" && menuChoice != "2" && menuChoice != "3" && menuChoice != "4" && menuChoice != "5" && menuChoice != "6" && menuChoice != "7" && menuChoice != "8")
                {
                    Console.WriteLine("\n   Icke accepterbart svar, skriv: \"1\", \"2\", \"3\", \"4\", \"5\", \"6\" ,\"7\" eller \"8\" ");
                    Console.ReadKey();
                }
                else if (menuChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\nDitt Kundnummer: " + (kundNum + 1));
                    kundNum++;
                    Console.Write("Namn?: ");
                    string namn = Console.ReadLine();
                    Console.Write("Personnummer?: ");
                    long pNum = long.Parse(Console.ReadLine());
                    Kunder.LäggTill(new Kund(namn, pNum));
                }
                else if (menuChoice == "2")
                {
                    Console.Clear();
                    if (kundNum == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Du behöver skapa en kund innan du gör ett konto!");
                        Console.WriteLine("Tryck 'ENTER' för att återgå till menyn");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Skriv in kundnummer: ");
                        int Num = int.Parse(Console.ReadLine()) - 1;

                        Console.WriteLine("Vad för typ av konto?:");
                        Console.WriteLine("ISK-konto (1)");
                        Console.WriteLine("Sparkonto (2)");
                        Console.Write("Ditt val: ");
                        string menuChoice2 = Console.ReadLine();
                        if (menuChoice2 != "1" && menuChoice2 != "2")
                        {
                            Console.WriteLine("\n   Icke accepterbart svar, skriv: \"1\" eller \"2\"");
                            Console.ReadKey();
                        }
                        else if (menuChoice2 == "1")
                        {
                            Console.Write("Saldo?: ");
                            double saldo = double.Parse(Console.ReadLine());
                            Console.Write("Hur många aktier?: ");
                            int aktier = int.Parse(Console.ReadLine());
                            Kunder.FåVärde(Num).LäggTillKonto(new ISKkonto(saldo, aktier));
                        }
                        else if (menuChoice2 == "2")
                        {
                            Console.Write("Saldo?: ");
                            double saldo = double.Parse(Console.ReadLine());
                            Console.Write("Hur stor ränta?: ");
                            double ränta = double.Parse(Console.ReadLine());
                            Kunder.FåVärde(Num).LäggTillKonto(new Sparkonto(saldo, ränta));
                        }

                    }
                }
                else if (menuChoice == "3")
                {
                    Console.Clear();
                    int mängdKonton = 0;
                    for (int index = 0; index < Kunder.Count; index++)
                    {
                        mängdKonton += Kunder.FåVärde(index).Konton.Count;
                    }
                    if (mängdKonton == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Det finns inga konton");
                        Console.WriteLine("Tryck 'ENTER' för att återgå till menyn");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv in ditt kundnummer: ");
                        int Num = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine(Kunder.FåVärde(Num).PresenteraKonton());
                        Console.WriteLine("Välj Konto (se nummret på vänster sida): ");
                        int val = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Hur mycket pengar vill du sätta in?: ");
                        int pengar = int.Parse(Console.ReadLine());
                        Kunder.FåVärde(Num).Konton.FåVärde(val).Saldo = Kunder.FåVärde(Num).Konton.FåVärde(val).Saldo + pengar;
                        Console.ReadLine();
                    }
                }
                else if (menuChoice == "4")
                {
                    Console.Clear();
                    int mängdKonton = 0;
                    for (int index = 0; index < Kunder.Count; index++)
                    {
                        mängdKonton += Kunder.FåVärde(index).Konton.Count;
                    }
                    if (mängdKonton == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Det finns inga konton");
                        Console.WriteLine("Tryck 'ENTER' för att återgå till menyn");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv in ditt kundnummer: ");
                        int Num = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine(Kunder.FåVärde(Num).PresenteraKonton());
                        Console.WriteLine("Välj Konto (se nummret på vänster sida): ");
                        int val = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Hur mycket pengar vill du ta ut?: ");
                        int pengar = int.Parse(Console.ReadLine());
                        Kunder.FåVärde(Num).Konton.FåVärde(val).Saldo = Kunder.FåVärde(Num).Konton.FåVärde(val).Saldo - pengar;
                        Console.ReadLine();
                    }
                }
                else if (menuChoice == "5")
                {
                    Console.Clear();
                    int mängdKonton = 0;
                    for (int index = 0; index < Kunder.Count; index++)
                    {
                        mängdKonton += Kunder.FåVärde(index).Konton.Count;
                    }
                    if (mängdKonton == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Det finns inga konton");
                        Console.WriteLine("Tryck 'ENTER' för att återgå till menyn");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv in ditt kundnummer: ");
                        int Num = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine(Kunder.FåVärde(Num).PresenteraKonton());
                        Console.WriteLine("Välj Konto att ta bort (se nummret på vänster sida): ");
                        int val = int.Parse(Console.ReadLine()) - 1;

                        Kunder.FåVärde(Num).Konton.TaBortVid(val);
                        Console.ReadLine();

                    }
                }
                else if (menuChoice == "6")
                {
                    Console.Clear();
                    
                    if (kundNum == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Det finns inga kunder!");
                        Console.WriteLine("Tryck 'ENTER' för att återgå till menyn");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv in kundnummeret på kunden du vill ta bort: ");
                        int Num = int.Parse(Console.ReadLine()) - 1;
                        Kunder.TaBortVid(Num);
                        kundNum--;
                        Console.ReadLine();
                    }
                }
                else if (menuChoice == "7")
                {
                    Console.WriteLine();
                    for (int i = 0; i < Kunder.Count; i++)
                    {
                        Console.WriteLine("Namn: " + Kunder.FåVärde(i).Namn + " PersonNummer: " + Kunder.FåVärde(i).PersonNummer);
                        for (int j = 0; j < Kunder.FåVärde(i).Konton.Count; j++)
                        {
                            Console.WriteLine("(" + (j+1) + ")" + Kunder.FåVärde(i).Konton.FåVärde(j).Presentera());
                        }
                    }
                    Console.ReadLine();
                }
                else if (menuChoice == "8")
                {
                    SkickaKunder(Kunder, ip, port);
                    break;
                }
            }
        }
        public static TcpClient ConnectToServer(string ip, int port)
        {
            Console.WriteLine("Ansluter till " + ip + ":" + port);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ip, port);
            Console.WriteLine("Ansluten!");
            return tcpClient;
        }
        public static void SkickaKunder(List<Kund> lista, string ip, int port)
        {
            TcpClient tcpClient = ConnectToServer(ip, port);
            NetworkStream tcpStream = tcpClient.GetStream();
            string message = "";
            for (int i = 0; i < lista.Count; i++)
            {            
                message += lista.FåVärde(i).FormateraString();
                if (i != lista.Count -1 )
                {
                    message += "%";
                }
            }
            Byte[] bMessage = Encoding.ASCII.GetBytes(message);
            tcpStream.Write(bMessage, 0, bMessage.Length);
            tcpClient.Close();
            Console.WriteLine("Meddelande skickat!");
            Console.ReadLine();
        }
        public static List<Kund> BegärMeddelande(string ip, int port)
        {
            List<Kund> Kunder = new List<Kund>();

            Byte[] bMessage = Encoding.ASCII.GetBytes("RequestMessages");
            TcpClient tcpClient = ConnectToServer(ip, port);
            NetworkStream tcpStream = tcpClient.GetStream();
            tcpStream.Write(bMessage, 0, bMessage.Length);

            byte[] bRead = new byte[256];
            int bReadSize = tcpStream.Read(bRead, 0, bRead.Length);

            string messageString = "";
            for (int i = 0; i < bReadSize; i++)
            {
                messageString += Convert.ToChar(bRead[i]);
            }
            Console.WriteLine("hej");
            Console.WriteLine(messageString);
            string[] KundStrings = messageString.Split('%');
            for (int i = 0; i < KundStrings.Length; i++)
            {
                Kunder.LäggTill(new Kund(KundStrings[i]));
            }
            return Kunder;
        }

    }
}

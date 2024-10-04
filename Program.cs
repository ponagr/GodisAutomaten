using System.Runtime.Intrinsics.Arm;

namespace GodisAutomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lägg till så att godis med antal 0 har röd text



            Godis Japp = new Godis { Typ = "Japp", Antal = 5 };
            Godis Daim = new Godis { Typ = "Daim", Antal = 5 };
            Godis Kola = new Godis { Typ = "Kola", Antal = 5 };
            Godis Lakrits = new Godis { Typ = "Lakrits", Antal = 3 };
            Godis Marabou = new Godis { Typ = "Marabou", Antal = 8 };

            GodisAutomatHandler.godisAutomat[0] = Japp;
            GodisAutomatHandler.godisAutomat[1] = Daim;
            GodisAutomatHandler.godisAutomat[2] = Kola;
            GodisAutomatHandler.godisAutomat[3] = Lakrits;
            GodisAutomatHandler.godisAutomat[4] = Marabou;

            Menu.MainMenu();    //Anropa Main-Menu
            Menu.ExitMenu();    //Vid avslut av Main-Menu, Anropa Exit-Menu för att bekräfta

            //Om Exit-Menu bekräftar avsluta, skriv ut avskedsmeddelande och avsluta programmet
            Console.Clear();
            Console.WriteLine("Välkommen åter!");
            Console.WriteLine("Tryck på valfri tangent för att avsluta programmet...");
            Console.ReadKey();

        }
    }

    static class GodisAutomatHandler
    {
        public static Godis[] godisAutomat = new Godis[5];    //Array av Godis-klass

        public static void PrintCandy()
        {
            while (true)
            {
                string[] candyOptions = new string[godisAutomat.Length +1];

                for (int i = 0; i < godisAutomat.Length; i++)
                {
                    candyOptions[i] = $"Lucka: {i + 1}. {godisAutomat[i].ToString()}";
                }
                candyOptions[candyOptions.Length - 1] = "Gå tillbaka";

                int choice = Menu.ShowMenu(candyOptions, godisAutomat);
                if (choice == candyOptions.Length -1)
                {
                    break;
                }
                else
                {
                    BuyCandy(choice);
                    continue;
                }
            }
        }
        public static void BuyCandy(int i)
        {
            if (godisAutomat[i].Antal > 0)
            {
                godisAutomat[i].Antal--;
                Console.WriteLine($"Du köpte en {godisAutomat[i].Typ}. Mums!");
            }
            else
            {
                Console.WriteLine($"{godisAutomat[i].Typ} är för tillfället slut.");
            }
            Console.ReadKey();
        }

        public static void AdminLogin()
        {
            Admin.NewAdmin();
            bool verify = Admin.VerifyAdmin();
            if (verify)
            {
                AdminHandler();
            }
        }
        public static void AdminHandler()
        {
            bool runMenu = true;
            while (runMenu)
            {
                //Lägg till så många menyval du vill i menuChoice-Array
                int menuChoice = Menu.ShowMenu(new string[] { "1. Fyll på godis", "2. Byt godis", "3. Byt Användarnamn och Lösenord", "4. Gå tillbaka" });
                switch (menuChoice)
                {
                    case 0:
                        AddCandyMenu();
                        break;
                    case 1:
                        ChangeCandyMenu();
                        break;
                    case 2:
                        Admin.ChangeCredentials();
                        break;
                    case 3:
                        //Avsluta meny
                        runMenu = false;
                        break;
                }
            }

        }
        private static void AddCandyMenu()
        {
            while (true)
            {
                string[] candyOptions = new string[godisAutomat.Length +1];

                for (int i = 0; i < godisAutomat.Length; i++)
                {
                    candyOptions[i] = $"Lucka: {i + 1}. {godisAutomat[i].ToString()}";
                }
                candyOptions[candyOptions.Length - 1] = "Gå tillbaka";

                int choice = Menu.ShowMenu(candyOptions, godisAutomat);
                if (choice == candyOptions.Length -1)
                {
                    break;
                }
                else
                {
                    AddCandy(choice);
                    continue;
                }
            }
        }
        private static void AddCandy(int i)
        {
            Console.WriteLine($"Hur många {godisAutomat[i].Typ} vill du fylla på med?");
            int antal = int.Parse(Console.ReadLine());
            if (antal > 0)
            {
                godisAutomat[i].Antal += antal;
            }
        }
        private static void ChangeCandyMenu()
        {
            while (true)
            {
                string[] candyOptions = new string[godisAutomat.Length +1];

                for (int i = 0; i < godisAutomat.Length; i++)
                {
                    candyOptions[i] = $"Lucka: {i + 1}. {godisAutomat[i].ToString()}";
                }
                candyOptions[candyOptions.Length - 1] = "Gå tillbaka";

                Console.WriteLine("Vilken lucka vill du byta godis ur?");
                int choice = Menu.ShowMenu(candyOptions, godisAutomat);
                if (choice == candyOptions.Length -1)
                {
                    break;
                }
                else
                {
                    ChangeCandy(choice);
                    continue;
                }
            }
        }
        private static void ChangeCandy(int i)
        {
            Console.Write("Vad vill du lägga till för ny godistyp: ");
            string nyGodisTyp = Console.ReadLine();
            Console.Write("Hur många vill du lägga till: ");
            int antal = int.Parse(Console.ReadLine());

            Godis nyGodis = new Godis { Typ = nyGodisTyp, Antal = antal };
            godisAutomat[i] = nyGodis;
        }

    }

    class Admin
    {
        public string username;
        public string password;
        public static Admin[] admin = new Admin[1];
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public static void NewAdmin()
        {
            if (admin[0] == null)
            {
                Admin newAdmin = new Admin("admin", "admin");
                admin[0] = newAdmin;
            }
        }
        public static bool VerifyAdmin()
        {
            Console.Write("Skriv in användarnamn: ");
            string username = Console.ReadLine();
            Console.Write("Skriv in lösenord: ");
            string password = Console.ReadLine();
            if (admin[0].username == username && admin[0].password == password)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Fel användarnamn eller lösenord");
                Console.ReadKey();
                return false;
            }
        }
        public static void ChangeCredentials()
        {
                Console.Write("Skriv in nytt användarnamn: ");
                string username = Console.ReadLine();
                Console.Write("Skriv in nytt lösenord: ");
                string password = Console.ReadLine();
                Admin updateAdmin = new Admin(username, password);
                admin[0] = updateAdmin;
        }
    }

    public class Godis     //Godis-klass med godistyp och antal för varje godistyp
    {
        public string Typ { get; set; }
        public int Antal { get; set; }

        public override string ToString()
        {
            return $"{Typ, -15}  Antal: {Antal}";
        }
    }
}


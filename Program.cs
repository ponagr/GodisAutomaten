using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

namespace GodisAutomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadList();
            Menu.MainMenu();    //Anropa Main-Menu
            Menu.ExitMenu();    //Vid avslut av Main-Menu, Anropa Exit-Menu för att bekräfta

            SaveList();
            //Om Exit-Menu bekräftar avsluta, skriv ut avskedsmeddelande och avsluta programmet
            Console.Clear();
            Console.WriteLine("Välkommen åter!");
            Console.WriteLine("Tryck på valfri tangent för att avsluta programmet...");
            Console.ReadKey();

        }

        static void SaveList()
        {
            string fileName = "Godisautomat.json";
            string godisAutomatLista = JsonSerializer.Serialize(GodisAutomatHandler.godisAutomat);
            File.WriteAllText(fileName, godisAutomatLista);
        }
        static void LoadList()
        {
            string fileName = "Godisautomat.json";
            string jsonString = File.ReadAllText(fileName);
            GodisAutomatHandler.godisAutomat = JsonSerializer.Deserialize<Godis[]>(jsonString);
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
  
        public static void AddCandyMenu()
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
        public static void ChangeCandyMenu()
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

    public class Godis     //Godis-klass med godistyp och antal för varje godistyp
    {
        public string Typ { get; set; }
        public int Antal { get; set; }

        public override string ToString()
        {
            return $"{Typ, -15}  Antal: {Antal}";
        }
    }

}//namespace bracket


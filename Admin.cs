using System.Text.Json;
namespace GodisAutomaten
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public static Admin[] admin = new Admin[1];
        // public Admin(string username, string password)
        // {
        //     this.username = username;
        //     this.password = password;
        // }
        public static void NewAdmin()
        {
            if (admin[0] == null)
            {
                Admin newAdmin = new Admin { Username = "admin", Password = "admin" };
                admin[0] = newAdmin;
            }
        }
        public static bool VerifyAdmin()
        {
            Console.Write("Skriv in användarnamn: ");
            string username = Console.ReadLine();
            Console.Write("Skriv in lösenord: ");
            string password = Console.ReadLine();
            if (admin[0].Username == username && admin[0].Password == password)
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
            Admin updateAdmin = new Admin { Username = username, Password = password };
            admin[0] = updateAdmin;
            SaveAdmin();
        }
        public static void AdminLogin()
        {
            NewAdmin();
            LoadAdmin();
            bool verify = VerifyAdmin();
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
                        GodisAutomatHandler.AddCandyMenu();
                        break;
                    case 1:
                        GodisAutomatHandler.ChangeCandyMenu();
                        break;
                    case 2:
                        ChangeCredentials();
                        break;
                    case 3:
                        //Avsluta meny
                        runMenu = false;
                        break;
                }
            }
        }
        public static void SaveAdmin()
        {
            string fileName = "Admin.json";
            string adminLista = JsonSerializer.Serialize<Admin[]>(admin);
            File.WriteAllText(fileName, adminLista);
        }
        public static void LoadAdmin()
        {
            string fileName = "Admin.json";
            string jsonString = File.ReadAllText(fileName);
            admin = JsonSerializer.Deserialize<Admin[]>(jsonString);
        }
    }
}
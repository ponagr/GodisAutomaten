namespace GodisAutomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Metod för att ta bort Godis.Antal vid menyval?
            //If/else statement, om Godis.Antal > 0, gå till Metod, annars, skriv ut att Godis.Typ är slut för tillfället.

            Godis[] godisAutomat = new Godis[5];    //Array av Godis-klass

            Godis Japp = new Godis { Typ = "Japp", Antal = 5 };
            Godis Daim = new Godis { Typ = "Daim", Antal = 5 };
            Godis Kola = new Godis { Typ = "Kola", Antal = 5 };
            Godis Lakrits = new Godis { Typ = "Lakrits", Antal = 3 };
            Godis Marabou = new Godis { Typ = "Marabou", Antal = 8 };

            godisAutomat[0] = Japp;
            godisAutomat[1] = Daim;
            godisAutomat[2] = Kola;
            godisAutomat[3] = Lakrits;
            godisAutomat[4] = Marabou;

            bool runMenu = true;

            while (runMenu) //Menyval
            {
                Console.Clear();    //Varje gång loop börjar om(efter varje menyval), rensa skärmen.
                for (int i = 0; i < godisAutomat.Length; i++)   //Skriv ut varje Godis ur array på ny rad
                {
                    Console.WriteLine($"LUCKA NR: {i + 1}.   {godisAutomat[i].Typ} ANTAL: {godisAutomat[i].Antal}");
                }
                Console.Write("(För att avsluta, tryck [q]), Annars välj luckans nr: ");
                string menyVal = Console.ReadLine();
                Console.WriteLine("");

                switch (menyVal)
                {
                    case "1":
                        if (godisAutomat[0].Antal > 0)  //Kolla om luckan är tom eller inte. Om luckan inte är tom, gör detta
                        {
                            Console.WriteLine("Du får en Japp. Mums!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            godisAutomat[0].Antal--;    //Ta bort 1 från Antal vid val
                            Console.ReadKey();  //För att man ska hinna läsa output innan case avslutas.
                            break;
                        }
                        else    //Om luckan är tom, gör detta
                        {
                            Console.WriteLine("Tillfälligt slut, prova en annan lucka!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            Console.ReadKey();
                            break;
                        }    
                    case "2":
                        if (godisAutomat[1].Antal > 0)
                        {
                            Console.WriteLine("Du får en Daim. Mums!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            godisAutomat[1].Antal--;
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Tillfälligt slut, prova en annan lucka!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            Console.ReadKey();
                            break;
                        }                       
                    case "3":
                        if (godisAutomat[2].Antal > 0)
                        {
                            Console.WriteLine("Du får en Kola. Mums!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            godisAutomat[2].Antal--;
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Tillfälligt slut, prova en annan lucka!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            Console.ReadKey();
                            break;
                        }                       
                    case "4":
                        if (godisAutomat[3].Antal > 0)
                        {
                            Console.WriteLine("Du får en Lakrits. Mums!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            godisAutomat[3].Antal--;
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Tillfälligt slut, prova en annan lucka!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        if (godisAutomat[4].Antal > 0)
                        {
                            Console.WriteLine("Du får en Marabou. Mums!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            godisAutomat[4].Antal--;
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Tillfälligt slut, prova en annan lucka!");
                            Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                            Console.ReadKey();
                            break;
                        }    
                    case "q":   //Vid val att avsluta, sätt runMenu till false för att avsluta while-loop och avsluta program
                        Console.WriteLine("Välkommen åter!");
                        Console.ReadKey();
                        runMenu = false;
                        break;
                    default:    //Vid input som inte finns som ett alternativ i menyn
                        Console.WriteLine("Fel input!");
                        Console.WriteLine("Tryck valfri tangen för att fortsätta köpa godis!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    class Godis     //Godis-klass med godistyp och antal för varje godistyp
    {
        public string Typ { get; set; }
        public int Antal { get; set; }
    }
}

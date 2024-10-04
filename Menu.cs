namespace GodisAutomaten
{
    public static class Menu
    {
        //Metod som kan användas av alla andra menyer för att minska Redundans.
        //Används för att kunna göra val i menyn via Piltangenter, Enter och Backspace
        public static int ShowMenu(string[] options)
        {
            int menuChoice = 0;
            bool runMenu = true;

            while (runMenu)
            {
                Console.Clear();
                Console.CursorVisible = false;

                for (int i = 0; i < options.Length; i++)
                {                   
                    if (i == menuChoice)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                        Console.WriteLine(options[i] + " <--");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                    }
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
                {
                    menuChoice++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
                {
                    menuChoice--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
                {
                    return menuChoice;
                }
                else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
                {
                    return options.Length - 1;
                }
            }
            return -1;
        }
        public static int ShowMenu(string[] options, Godis[] godisAutomat)
        {
            int menuChoice = 0;
            bool runMenu = true;

            while (runMenu)
            {
                Console.Clear();
                Console.CursorVisible = false;

                for (int i = 0; i < options.Length; i++)
                {   
                    if (i < godisAutomat.Length && godisAutomat[i].Antal == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;     //Om godiset är slut, gör texten röd för extra tydlighet.
                    }
                    else if (i == menuChoice)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                    }


                    if (i == menuChoice)
                    {
                        //Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                        Console.WriteLine(options[i] + " <--");
                        //Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                    }
                    Console.ResetColor();
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
                {
                    menuChoice++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
                {
                    menuChoice--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
                {
                    return menuChoice;
                }
                else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
                {
                    return options.Length - 1;
                }
            }
            return -1;
        }
        // public static int ShowMenu(Godis[] options)
        // {
        //     int menuChoice = 0;
        //     bool runMenu = true;

        //     while (runMenu)
        //     {
        //         Console.Clear();
        //         Console.CursorVisible = false;

        //         for (int i = 0; i < options.Length; i++)
        //         {
        //             if (i == menuChoice)
        //             {
        //                 Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
        //                 Console.WriteLine($"LUCKA NR: {i + 1}.   {options[i].Typ} ANTAL: {options[i].Antal} <--");
        //                 Console.ResetColor();
        //             }
        //             else
        //             {
        //                 Console.WriteLine($"LUCKA NR: {i + 1}.   {options[i].Typ} ANTAL: {options[i].Antal}");  //Skriv ut resterande menyval utan pil och highlight
        //             }
        //         }

        //         var keyPressed = Console.ReadKey();

        //         if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
        //         {
        //             menuChoice++;
        //         }
        //         else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
        //         {
        //             menuChoice--;
        //         }
        //         else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
        //         {
        //             return menuChoice;
        //         }
        //         else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
        //         {
        //             return options.Length - 1;
        //         }
        //     }
        //     return -1;
        // }

        //Meny-metoder som anropar olika metoder baserat på menyval, anropar först ShowMenu() för själva gränssnittet.
        public static void MainMenu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                //Lägg till så många menyval du vill i menuChoice-Array
                int menuChoice = ShowMenu(new string[] { "1. Köp godis", "2. Logga in som Admin", "3. Avsluta" });
                switch (menuChoice)
                {
                    case 0:
                        GodisAutomatHandler.PrintCandy();
                        //Lägg till metodanrop
                        break;
                    case 1:
                        GodisAutomatHandler.AdminLogin();
                        //Lägg till metodanrop
                        break;
                    case 2:
                        //Avsluta meny
                        runMenu = false;
                        break;
                }
            }
        }
        // public static void CandyMenu()
        // {
        //     bool runMenu = true;
        //     while (runMenu)
        //     {
        //         //Lägg till så många menyval du vill i menuChoice-Array
        //         int menuChoice = ShowMenu(GodisAutomatHandler.godisAutomat);
        //         switch (menuChoice)
        //         {
        //             case 0:
        //                 //Lägg till metodanrop
        //                 break;
        //             case 1:
        //                 //Lägg till metodanrop
        //                 break;
        //             case 2:
        //                 //Avsluta meny
        //                 runMenu = false;
        //                 break;
        //         }
        //     }
        // }

        //Bekräfta Avsluta
        public static void ExitMenu()
        {
            bool runMenu = true; 
            while (runMenu)
            {                
                Console.WriteLine("Är du säker på att du vill avsluta programmet?\n");
                int menuChoice = ShowMenu(new string[] { "Ja, Avsluta", "Nej, Gå tillbaka" });
                switch (menuChoice)
                {
                    case 0:
                        runMenu = false;    //Bekräfta och Avsluta program 
                        break;

                    case 1:
                        MainMenu();     //Avbryt och återgå till Main-Menu
                        break;
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Tree
{
    private const int LENGTH = 25;
    private string[] tab;
    private readonly Random random = new Random();

    public Tree()
    {
        tab = new string[LENGTH];
        tab[0] = new string(' ', 27);
        tab[1] = new string(' ', 18) + "|";
        tab[2] = new string(' ', 17) + "/ \\";

        int spaceOutside = 16, spaceInside = 3;
        for (int i = 0; i < 21; i += 3, spaceOutside -= 2, spaceInside += 4)
        {
            tab[i + 3] = new string(' ', spaceOutside) + "/" + new string(' ', spaceInside) + "\\";
            tab[i + 4] = new string(' ', spaceOutside - 1) + "/" + new string(' ', spaceInside + 2) + "\\";
            tab[i + 5] = new string(' ', spaceOutside - 2) + "/_" + new string(' ', spaceInside + 2) + "_\\";
        }

        tab[23] = new string(' ', 2) + "/" + new string(':', 31) + "\\";
        tab[24] = new string(' ', 14) + "\\" + new string('_', 6) + "/";
    }

    public void DisplayTree()
    {
        Console.WriteLine();
        for (int i = 0; i < LENGTH; i++)
        {
            Console.Write(new string(' ', 10));
            for (int j = 0; j < tab[i].Length; j++)
            {
                char c = tab[i][j];
                if (c == '/' || c == '\\' || c == '_')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (c == '|' || c == ':' || c == '_')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (c == 'o')
                {
                    Console.ForegroundColor = (ConsoleColor)random.Next(9, 15); // Random bright colors
                }
                else if (c == '!')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (c == 'J')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (c == '~' || c == '.' || c == '"')
                {
                    Console.ForegroundColor = (ConsoleColor)random.Next(1, 6);
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(c);
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    public void AddChains()
    {
        Console.WriteLine("What height (1-7) would you like put chains?: ");
        int level;
        do
        {
            int.TryParse(Console.ReadLine(), out level);
        } while (level < 1 || level > 7);

        switch (level)
        {
            case 1:
                SetChars(4, 20, 5, 17, '~');
                SetChars(4, 19, 5, 16, '.');
                SetChar(5, 18, '"');
                break;
            case 2:
                SetChars(7, 18, 8, 21, '~');
                SetChars(6, 16, 7, 19, 8, 22, '.');
                SetChars(6, 15, 7, 17, 8, 20, '"');
                break;
            case 3:
                SetChars(11, 14, 11, 15, 10, 19, 10, 20, 9, 22, '~');
                SetChars(11, 12, 11, 13, 10, 18, '.');
                SetChars(11, 16, 11, 17, 10, 21, 9, 23, '"');
                break;
            case 4:
                SetChars(13, 17, 13, 18, 14, 23, 14, 24, '~');
                SetChars(12, 13, 12, 14, 13, 19, 13, 20, 14, 25, 14, 26, '.');
                SetChars(12, 12, 13, 15, 13, 16, 14, 21, 14, 22, '"');
                break;
            case 5:
                SetChars(17, 10, 17, 11, 16, 16, 16, 17, 16, 18, 15, 24, 15, 25, '~');
                SetChars(17, 8, 17, 9, 16, 14, 16, 15, 15, 22, 15, 23, '.');
                SetChars(17, 12, 17, 13, 16, 19, 16, 20, 16, 21, 15, 26, 15, 27, '"');
                break;
            case 6:
                SetChars(18, 10, 18, 11, 18, 12, 19, 18, 19, 19, 20, 26, 20, 27, '~');
                SetChars(18, 13, 18, 14, 19, 20, 19, 21, 19, 22, 20, 28, 20, 29, 20, 30, '.');
                SetChars(18, 8, 18, 9, 19, 15, 19, 16, 19, 17, 20, 23, 20, 24, 20, 25, '"');
                break;
            case 7:
                SetChars(23, 7, 23, 8, 23, 9, 22, 16, 22, 17, 22, 18, 21, 25, 21, 26, 21, 27, '~');
                SetChars(23, 4, 23, 5, 23, 6, 22, 13, 22, 14, 22, 15, 21, 22, 21, 23, 21, 24, '.');
                SetChars(23, 10, 23, 11, 23, 12, 22, 19, 22, 20, 22, 21, 21, 28, 21, 29, 21, 30, '"');
                break;
        }
    }

    private void SetChar(int row, int col, char c)
    {
        var line = tab[row].ToCharArray();
        line[col] = c;
        tab[row] = new string(line);
    }

    private void SetChars(params object[] args)
    {
        for (int i = 0; i < args.Length - 1; i += 2)
        {
            SetChar((int)args[i], (int)args[i + 1], (char)args[args.Length - 1]);
        }
    }


    public void AddGlassBalls()
    {
        // Add new ornaments
        var positions = new List<(int row, int col)>
        {
            (21, 11), (15, 11), (9, 16), (4, 18),
            (20, 18), (6, 21), (11, 23), (19, 27)
        };

        foreach (var (row, col) in positions)
        {
            var line = tab[row].ToCharArray();
            line[col] = 'o';
            tab[row] = new string(line);
        }
    }

    // Other methods remain similar but with string manipulation instead of char arrays
    public void AddStar() => tab[0] = tab[0].Substring(0, 16) + "_.|._" + tab[0].Substring(21);

    public void AddSweets()
    {
        (int row, int col)[] positions = {
            (22, 7), (19, 9), (10, 14), (7, 15),
            (12, 22), (14, 16), (17, 23), (22, 28)
        };

        foreach (var (row, col) in positions)
        {
            var line = tab[row].ToCharArray();
            line[col] = 'J';
            tab[row] = new string(line);
        }
    }

    public void AddLamps()
    {
        (int row, int col)[] positions = {
            (5, 14), (8, 12), (11, 10), (14, 8), (17, 6), (20, 4),
            (5, 22), (8, 24), (11, 26), (14, 28), (17, 30), (20, 32)
        };

        foreach (var (row, col) in positions)
        {
            var line = tab[row].ToCharArray();
            line[col] = '!';
            tab[row] = new string(line);
        }
    }


    public string ExportTree()
    {
        Console.WriteLine("Export to text file...\nName of Christmas card: ");
        string card = Console.ReadLine() + ".txt";
        File.WriteAllLines(card, tab.Select(line => new string(' ', 10) + line));
        return card;
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("\n\n[1] -> Decorate the tree with star");
        Console.WriteLine("[2] -> Decorate the tree with chains");
        Console.WriteLine("[3] -> Give gifts to loved ones under the tree");
        Console.WriteLine("[4] -> Hang colorful glass balls on the tree");
        Console.WriteLine("[5] -> Hang candies on the tree");
        Console.WriteLine("[6] -> Turn on the lights");
        Console.WriteLine("[9] -> Export to text file");
        Console.WriteLine("[0] -> Exit");
        Console.Write("Your choice: ");
    }

    public static void ClearScreen()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }
}

class Floor
{
    private const int LENGTH = 6;
    private string[] tab;
    private int gifts;

    public Floor()
    {
        tab = new string[LENGTH];
        for (int i = 0; i < LENGTH; i++)
            tab[i] = " ";
        gifts = 0;
    }

    public void DisplayFloor()
    {
        foreach (string row in tab)
            Console.WriteLine(row);
    }

    public void AddGift()
    {
        if (gifts == 3)
        {
            Console.WriteLine("You can put only three gifts under the tree... [ENTER]");
            Console.ReadLine();
            return;
        }

        tab[0] += new string(' ', 6) + "_" + new string(' ', 3) + "_" + new string(' ', 9);
        tab[1] += new string(' ', 5) + "((\\o/))" + new string(' ', 8);
        tab[2] += "." + new string('-', 5) + "//" + "^" + "\\\\" + new string('-', 5) + "." + new string(' ', 3);
        tab[3] += "|For:" + "/ | | \\" + new string(' ', 4) + "|" + new string(' ', 3);
        tab[4] += "|" + new string(' ', 6) + "| |" + new string(' ', 6) + "|" + new string(' ', 3);
        tab[5] += "'" + new string('-', 6) + new string('=', 3) + new string('-', 6) + "'" + new string(' ', 3);

        Console.Write("This present will be for: ");
        string name = Console.ReadLine() ?? "";
        while (name.Length > 6)
        {
            Console.Write("Inscription on gift may have a maximum six letters, try again: ");
            name = Console.ReadLine() ?? "";
        }
        name = name.PadRight(6);

        var line = tab[4].ToCharArray();
        name.CopyTo(0, line, 2 + gifts * 20, 6);
        tab[4] = new string(line);
        gifts++;
    }

    public void ExportFloor(string card)
    {
        File.AppendAllLines(card, tab);
    }
}
// Add this class before Program class
public class SharedState
{
    public volatile bool IsRunning = true;
    public ushort CurrentChoice = 0;
    public object Lock = new object();
}


class Program
{
    // Replace existing Main() method in Program class
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        try
        {
            Tree tree = new Tree();
            Floor floor = new Floor();
            var sharedState = new SharedState();
            var cts = new CancellationTokenSource();

            // Create display thread
            var displayTask = Task.Run(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    lock (sharedState.Lock)
                    {
                        Console.CursorVisible = false;
                        Tree.ClearScreen();
                        tree.DisplayTree();
                        floor.DisplayFloor();
                        Tree.DisplayMenu();
                    }
                    Thread.Sleep(1000); // Refresh rate
                }
            }, cts.Token);

            // Input handling thread (main thread)
            while (sharedState.IsRunning)
            {
                Console.CursorVisible = true;
                if (!ushort.TryParse(Console.ReadLine(), out ushort choice))
                {
                    choice = 99;
                    continue;
                }

                lock (sharedState.Lock)
                {
                    switch (choice)
                    {
                        case 0:
                            sharedState.IsRunning = false;
                            cts.Cancel();
                            return;
                        case 1: tree.AddStar(); break;
                        case 2: tree.AddChains(); break;
                        case 3: floor.AddGift(); break;
                        case 4: tree.AddGlassBalls(); break;
                        case 5: tree.AddSweets(); break;
                        case 6: tree.AddLamps(); break;
                        case 9: floor.ExportFloor(tree.ExportTree()); break;
                    }
                    sharedState.CurrentChoice = choice;
                }
            }

            // Cleanup
            cts.Cancel();
            displayTask.Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
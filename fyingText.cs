using System;
using System.Threading;

class FlyingText
{
    static void Main()
    {
        int[] mass = Scaner(); //scaning basic parametres
        string wordNew = WordMaker(mass); //returning word, which flying
        WindowMaking(mass); //making console of given size
        Fly(wordNew, mass);
        Console.ReadKey();
    }
    //format of scan information is int, int, int
    static int[] Scaner() //Input data will contain Width and Height os the image screen and the Length of text string
    {
        string[] lineOfCode = Console.ReadLine().Split(new char[] {' '}); ; //Scaning Width, Heigth and Length of the string
        int[] linesForWork = new int[3];
        for (int i = 0; i < 3; i++)
            linesForWork[i] = int.Parse(lineOfCode[i]);
        return linesForWork;
    }

    static string WordMaker(int[] args) // return flying world
    {
        Console.Write("Enter the word the length of {0} : ", args[2]);
        string myInput = Console.ReadLine(); //scaning input information
        if (myInput.Length < args[2])
        {
            for (int i = 0; i < (args[2] - myInput.Length); i++)
                myInput += "a"; //add missing elemets to full size
        }
        myInput = myInput.Substring(0, args[2]);
        return myInput;
    }

    static void WindowMaking(int[] args)
    {
        Console.WindowHeight = args[1]; //width console Y
        Console.WindowWidth = args[0]; //height console X       
        Console.Clear();
    }

    static void Fly(string str, int[] args)
    {
        char[,] mass = new char[args[1], args[0]]; // creating place for haldind massiva

        int x = 0, y =0; //start conditions
        int addX = 1, addY = 1;
        int iter = 0;
        while (iter < 100)
        {
            mass = MassCleaner(args);          
            mass = MooveX(args, mass, x, y, str);
            Draw(args, mass);
            Thread.Sleep(1000);
            Console.Clear();

            if (x < (args[0] - str.Length) && addX > 0)
                addX = 1;
            else if (x == (args[0] - str.Length) && addX > 0)
                addX = -1;
            else if (x > 0 && addX < 0)
                addX = -1;
            else if (x == 0 && addX < 0)
                addX = 1;

            if (y < args[1] - 1 && addY > 0)
                addY = 1;
            else if (y == args[1] - 1 && addY > 0)
                addY = -1;
            else if (y > 0 && addY < 0)
                addY = -1;
            else if (y == 0 && addY < 0)
                addY = 1;

            x += addX;
            y += addY;
        }
        iter += 1;
    }

    static char[,] MooveX(int[] args, char[,] mass, int x, int y, string str)
    {
        int i = 0; // iter fo string length
        for (int j = 0; j < args[0]; j++)
        {
            if (j < x || (j > x + args[2] - 1))
                mass[y, j] = '1';
            else
                mass[y, j] = str[i++]; // walk througth the word
        }
        return mass;
    }

    static char[,] MassCleaner(int[] args)
    {
        char[,] mass = new char[args[1], args[0]]; // args[0] X, args[1] Y
        for (int yi = 0; yi < args[1]; yi++)
        {
            for (int xi = 0; xi < args[0]; xi++)
                mass[yi, xi] = '1';
        }
        return mass;
    }

    static void Draw(int[] args, char[,] mass)
    {
        for (int a = 0; a < args[1]; a++)
        {
            for (int b = 0; b < args[0]; b++)
                Console.Write(mass[a, b]);
            if (a < args[0] - 1)
                Console.Write('\n');
        }
    }
}

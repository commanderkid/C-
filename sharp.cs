// size - field a*b
// #.#.#.
// .#.#.
// #.#.#




using System;

public class NewProg
{
    public static void Main(string[] args)
    {
        WriteBoard(8);
        WriteBoard(1);
        WriteBoard(2);
        WriteBoard(3);
        WriteBoard(10);

        Console.ReadKey(true);
    } 
    
    private static void WriteBoard(int size)
    {
        char ch;

        for (int i=0; i<size; i++)
        {
            ch = (i%2==0) ? ('#') : ('.');

            for (int j=0; j<size; j++)
            {
                if (ch == '#' && j%2 == 0)
                {
                    Console.Write(ch.ToString());
                }
                
                else if (ch == '#' && j%2 != 0)
                {
                    Console.Write(char.ToString('.'));
                }

                else if (ch == '.' && j%2 == 0)
                {
                    Console.Write(Convert.ToString(ch));
                }

                else if (ch == '.' && j%2 != 0)
                {
                    Console.Write(Convert.ToString('#'));
                }
            }
            Console.Write("\n");
        }
        //Console.Write("\n");
    }
}

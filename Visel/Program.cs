using System;

namespace Viselica
{

    struct Game
    {
        public string word;
        public char[] stars;
        public int lives;

    }
    class Program
    {
        private static Game game;
        private static void Main(string[] args)
        {
            const int maxLives = 10;

            Console.Write("Введите слово:");
            string str = Console.ReadLine().ToLower();
            game.word = str;
            game.stars = new string('#', str.Length).ToCharArray();

            char symvol = ' ';
            Thread th = new Thread(() =>
            {
                while (true)
                {
                    NewWord(symvol);
                    Console.WriteLine("Введите слово " + string.Join("", game.stars));
                    Console.WriteLine("Количество попыток {0},Осталось {1}", game.lives, maxLives - game.lives);
                    if (game.word.Equals(string.Join("", game.stars)))
                    {
                        Console.WriteLine("Ты выиграл!");
                        return;

                    }
                    if (game.lives == maxLives)
                    {
                        Console.WriteLine("Ты проиграл!");
                        return;
                    }
                    Thread.Sleep(500);
                    Console.Clear();
                }
            });
            th.Start();
            Thread th2 = new Thread(() =>
            {
                while (true)
                {
                    symvol = (Char.ToLower(Console.ReadKey().KeyChar));
                    game.lives++;
                    Thread.Sleep(500);
                }
            });
            th2.IsBackground = true;
            th2.Start();
            Console.ReadKey(true);
        }

        static void NewWord(char s)
        {

            for (int i = 0; i < game.word.Length; i++)
            {
                if (game.word[i] == s)
                {
                    game.stars[i] = s;
                }
            }
        }
    }
}
using System;

namespace test3
{
    class Program
    {
        public static string[] ChooseWord()
        {
            // reading the file
            string[] dane = System.IO.File.ReadAllLines(@"C:\Users\jaszc\source\repos\test3\countries_and_capitals.txt");
            // choosing random line from file
            Random losowa = new Random();
            string linia = dane[losowa.Next(dane.Length)];
            //Console.WriteLine(linia);
            // spliting line 
            string[] separator = { " | " };
            string[] countCap = linia.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
            return countCap;

        }

        public static string WordToBlank(string[] pair) 
        {
            string blank = "";
            for (int i =0; i< pair[1].Length; i++)
            {
                blank += "_ ";
            }
            return blank;
        }
        public static bool IfBlankFilled(string blank)
        {
            for (int i=0; i < blank.Length; i++)
            {
                if (blank[i] == '_')
                {
                    return false;
                }
            }
            return true;

        }

        public static bool IsLetterInWord(string letter, string word)
        {
            word = word.ToLower();
            int i = word.IndexOf(letter);
            if (i == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsWordCorrect(string guess,string word)
        {
            guess = guess.ToLower();
            word = word.ToLower();
            if (guess.Equals(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[] HowManyLettersInWord(string letter,string word)
        {
            letter = letter.ToLower();
            word = word.ToLower();
            int[] pozycja= {99,99,99,99,99};
            int index = 0;
            for (int k=0; k < word.Length; k++)
            {                
                if (word[k]==letter[0])
                {
                        
                    pozycja[index] = k;
                    index++;
                }
            }
            return pozycja;
            
        }
        public static string FillGuess(string letter, string empty, int[] where)
        {
            

            
            foreach (int index in where)
            {
                int poz = index * 2;
                if (index != 99)
                {                   
                    empty=empty.Remove(poz,1).Insert(poz,letter);
                }
                    
            }
            return empty;
        }

        public static void UpdateConsole(int life,string puste, string[] notInWord)
        {
            Console.Clear();
            Console.WriteLine(" Life : {0}", life);
            Console.WriteLine("Letters not in word: {0}", string.Join(" ",notInWord));
            switch (life)
            {
                case 5:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;
                case 4:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  O       |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;
                case 3:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  O       |");
                    Console.WriteLine(" /|\\      |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;
                case 2:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  O       |");
                    Console.WriteLine(" /|\\      |");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;
                case 1:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  O       |");
                    Console.WriteLine(" /|\\      |");
                    Console.WriteLine("  |       |");
                    Console.WriteLine(" /        |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;
                case 0:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  O       |");
                    Console.WriteLine(" /|\\      |");
                    Console.WriteLine("  |       |");
                    Console.WriteLine(" / \\      |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;
                default:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    Console.WriteLine("          |");
                    break;

            }
            Console.WriteLine(puste);
        }
        public static bool IsAlife(int life)
        {
            if (life <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        static void Main(string[] args)
        {
            again:
            int life = 5;
            string[] para = ChooseWord();
            string guess = "";
            string choice = "";
            string[] letterNotInWord = new string[5];
            Console.WriteLine(para[0]);
            Console.WriteLine(para[1]);
            string puste = WordToBlank(para);
            Console.WriteLine(puste);
            //Console.WriteLine("Podaj litere: ");
            //string l = Console.ReadLine();

            //Console.WriteLine(string.Join(" ",arraywithletter));
            /*if (IsLetterInWord(l,para[1]) == true)
            {
                Console.WriteLine(FillGuess(l, puste, arraywithletter));
            }

            */
            //Console.ReadLine();
            Console.WriteLine("Welcome to hangman game!");
            while (IsWordCorrect(guess, para[1]) == false)
            {
                UpdateConsole(life, puste, letterNotInWord);
                if (life == 1)
                {
                    Console.WriteLine("Hint!\nThe capital of {0}.", para[0]);
                }
                
                Console.WriteLine("Would you like to guess a letter or word?\nType l for letter or w for word.");
                choice = Console.ReadLine();
                if (choice == "l")
                {
                    Console.WriteLine("Please type a letter: ");
                    string l = Console.ReadLine();
                    if (IsLetterInWord(l, para[1]))
                    {
                        int[] arraywithletter = HowManyLettersInWord(l, para[1]);
                        puste = FillGuess(l, puste, arraywithletter);
                        UpdateConsole(life, puste, letterNotInWord);
                        if (IfBlankFilled(puste))
                        {
                            guess = para[1];
                            UpdateConsole(life, puste, letterNotInWord);
                            Console.WriteLine("You are winner!");
                        }
                    }
                    else
                    {
                        letterNotInWord[5 - life] = l;
                        life--;

                        UpdateConsole(life, puste, letterNotInWord);
                        if (IsAlife(life) == false)
                        {
                            Console.WriteLine("Game Over");
                            guess = para[1];
                            Console.WriteLine("The guess word is {0}", guess);
                        }

                    }
                }
                else if (choice == "w")
                {
                    Console.WriteLine("Please type a word: ");
                    guess = Console.ReadLine();
                    if (IsWordCorrect(guess, para[1]))
                    {
                        UpdateConsole(life, para[1], letterNotInWord);
                        Console.WriteLine("You are winner!");
                    }
                    else
                    {
                        life=life-2;
                        UpdateConsole(life, puste, letterNotInWord);
                        Console.WriteLine("Wrong word!");
                        if (IsAlife(life) == false)
                        {
                            Console.WriteLine("Game Over");
                            guess = para[1];
                            Console.WriteLine("The guess word is: {0}", guess);
                        }

                    }
                }
            }
            repeat:

            Console.WriteLine("Play again? y/n");
            string x=Console.ReadLine();
            switch (x.ToUpper())
            {
                case "Y":
                    goto again;                   
                case "N":
                    break;
                default:
                    break;

            }
            


        }
    }
}

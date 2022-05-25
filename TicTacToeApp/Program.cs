using System;


namespace Arrays__Practice
{
    internal class Program
    {
        static string[,] matrix =
                {
                    {"1","2","3"},
                    {"4","5","6"},
                    {"7","8","9"}
                };




        static void Main(string[] args)
        {
            //DrawArray();

            Console.WriteLine();
            GamePlay();



        }

        public static void DrawArray()
        {
            Console.Clear();

            string[,] matrix2 =
        {
            {" "," "," ","|"," "," "," ","|"," "," "," "," ", },
            {" ",matrix[0,0]," ","|"," ",matrix[0,1]," ","|"," ",matrix[0,2]," "," ", },
            {" "," "," ","|"," "," "," ","|"," "," "," "," ", },
            {"-","-","-","|","-","-","-","|","-","-","-","-", },
            {" "," "," ","|"," "," "," ","|"," "," "," "," ", },
            {" ",matrix[1,0]," ","|"," ",matrix[1,1]," ","|"," ",matrix[1,2]," "," ", },
            {" "," "," ","|"," "," "," ","|"," "," "," "," ", },
            {"-","-","-","|","-","-","-","|","-","-","-","-", },
            {" "," "," ","|"," "," "," ","|"," "," "," "," ", },
            {" ",matrix[2,0]," ","|"," ",matrix[2,1]," ","|"," ",matrix[2,2]," "," ", },
            {" "," "," ","|"," "," "," ","|"," "," "," "," ", }
        };
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {

                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    //Console.Write("  ");

                    Console.Write(matrix2[i, j]);

                }

                Console.WriteLine();

            }

            Console.WriteLine();
        }

        public static void PlaceLetter(string gamePiece, string boardLocation)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j].Equals(boardLocation))
                        matrix[i, j] = gamePiece;

                }
            }
            DrawArray();

        }

        public static void GamePlay()
        {
            bool ifPlayerX = true;
            ResetGame();
            while (true)
            {
                if (ifPlayerX)
                {
                    string gamePiece = "X";
                    Console.WriteLine("Player 1, please type a number on the board to place your X");
                    string x_Player = Console.ReadLine();
                    if (!IfGoodEntry(x_Player))
                    {
                        Console.WriteLine("Please enter a number 1-9 that is still available on the board");
                        //GamePlay();
                    }
                    else
                    {
                        PlaceLetter(gamePiece, x_Player);
                        if (Checker(matrix))
                        {
                            Console.WriteLine("Player 1 is the winner");
                            ToPlayAgain();

                        }
                        else
                        {
                            ifPlayerX = false;
                        }
                    }

                }
                else
                {
                    string gamePiece = "O";
                    Console.WriteLine("Player 2, please type a number on the board to place your O");
                    string x_Player = Console.ReadLine();

                    if (!IfGoodEntry(x_Player))
                    {
                        Console.WriteLine("Please enter a number 1-9 that is still available on the board");
                        //GamePlay();
                    }
                    else
                    {
                        PlaceLetter(gamePiece, x_Player);

                        if (Checker(matrix))
                        {
                            Console.WriteLine("Player 2 is the winner");
                            ToPlayAgain();

                        }
                        else
                        {
                            ifPlayerX = true;
                        }
                    }

                }
            }



        }
        public static bool Checker(string[,] board)
        {
            // here we perform horizontal and vertical checks
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }
            // here diagonal checks 
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;
            return false;
        }

        public static void ResetGame()
        {
            int counter = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = Convert.ToString(counter);
                    counter++;
                }
            }
            DrawArray();
        }

        public static bool IfGoodEntry(string entry)
        {
            switch (entry)
            {
                case "1":
                    return true;

                case "2":
                    return true;
                case "3":
                    return true;
                case "4":
                    return true;
                case "5":
                    return true;
                case "6":
                    return true;
                case "7":
                    return true;
                case "8":
                    return true;
                case "9":
                    return true;
                default: return false;

            }

        }

        public static void ToPlayAgain()
        {
            Console.WriteLine("Do you want to play again, type 'y' to play " +
                            "or 'n' to stop.");
            string playAgain = Console.ReadLine();

            if (playAgain.Equals("y"))
            {
                ResetGame();
            }
            else
                System.Environment.Exit(0);



        }
    }
}

//Assignment3 Weronika Wawrzyniak 17643904 15.12.2017 University of Lincoln - Going to Boston die game
/*Change history:
 * 1.12 - writting class Die, Player and Game
 * 5.12 - setting match play
 * 7.12 - setting score play
 * 10.12 - adding 2 players
 * 15.12 - adding collections and exception handling
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace assignment3
{
    /*In class Player there are methods 'playGame','playGame2'and 'playGame3', in which uses methods 'throws' and 'throws2' to display each roll and set the max. 
    Returns, which are sums of maxes from rolls,are assigned to variable 'lastScore' which are respoinsible for players scores.
    Then it displays each Players' score.*/
    public class Player
    {
        public string name;
        public int lastScore = 0;
        public int lastScore2 = 0;
        public int wins_nr = 0;

        public Player()
        {
            Console.WriteLine("Give me your name");
            name = Console.ReadLine();
        }

        public void playGame()
        {
            Die die = new Die();
            Console.WriteLine(name + ":");
            lastScore = die.throws();
            Console.WriteLine(name + " your score is: " + lastScore);
        }
        public void playGame2()
        {
            Die die = new Die();
            Console.WriteLine(name + ":");
            lastScore2 = die.throws2();
            Console.WriteLine(name + " your score is: " + lastScore2);
        }
        public void playGame3()
        {
            Die die = new Die();
            Console.WriteLine(name + ":");
            lastScore2 = die.throwsPlayer2();
            Console.WriteLine(name + " your score is: " + lastScore2);
        }

    }

    /*In class Game there are MatchGame, ScoreGame, MatchGame2Players, ScoreGame2Players, CompareScores and Compare.
    In MatchGame and MatchGame2Players methods while loop, which conditions meets MatchGame conditions (whoever wins 5 rounds first wins), uses playGame methods from class Player to display players scores after each round.
    Then it uses Compare method from the same class which by using if statements compares the numers of wins. The round number increases untill one of the players reach 5 wins.
    In ScoreGame and ScoreGame2Players methods while loop, which conditions meet ScoreGame conditions (playing 5 rounds, whoever has the biggest score at the end wins), uses playGame methods from class Player to display scores after each round.
    Then it adds (and displays) each players' score to created in this method variables 'scoresum' and 'scoresum2' to count the total score after 5 rounds. 
    The round number incerases and when it reaches 5, the while loop ends and the CompareScores method from the same class compares 'scoresum' and 'scresum2' using if statements. The winner is displayed.*/
    public class Game
    {
        private int scoresum = 0;
        private int scoresum2 = 0;
        private int round_nr = 1;
        public void MatchGame()
        {

            Player first = new Player();
            Player second = new Player();
            round_nr = 1;


            while ((first.wins_nr < 5) && (second.wins_nr < 5))
            {
                Console.ReadLine();
                Console.WriteLine("\n ~~~~~~~~~ Round {0}! ~~~~~~~~~ \n", round_nr);
                first.playGame();
                Console.WriteLine("");
                Console.ReadKey();
                second.playGame2();
                Compare(first, second);
                round_nr++;
            }
            if (first.wins_nr > second.wins_nr) Console.WriteLine("------------------ " + first.name + " won the game! Congratz! ------------------ ");
            else if (first.wins_nr < second.wins_nr) Console.WriteLine("------------------ " + second.name + " won the game! Congratz! ------------------");

        }
        public void matchGame2Players()
        {
            Player first = new Player();
            Player second = new Player();
            round_nr = 1;


            while ((first.wins_nr < 5) && (second.wins_nr < 5))
            {
                Console.ReadLine();
                Console.WriteLine("\n ~~~~~~~~~ Round {0}! ~~~~~~~~~ \n", round_nr);
                first.playGame();
                Console.WriteLine("");
                Console.ReadKey();
                second.playGame3();
                Compare(first, second);
                round_nr++;
            }
            if (first.wins_nr > second.wins_nr) Console.WriteLine("------------------ " + first.name + " won the game! Congratz! ------------------ ");
            else if (first.wins_nr < second.wins_nr) Console.WriteLine("------------------ " + second.name + " won the game! Congratz! ------------------");
        }

        public void Compare(Player player1, Player player2)
        {
            if (player1.lastScore < player2.lastScore2)
            {
                player2.wins_nr++;
                Console.WriteLine("{0} won this round! Yuppie! {1} now has {2} wins.", player2.name, player2.name, player2.wins_nr);

            }
            else if (player1.lastScore > player2.lastScore2)
            {
                player1.wins_nr++;
                Console.WriteLine("{0} won this round! Yuppie! {1} now has {2} wins.", player1.name, player1.name, player1.wins_nr);


            }
            else Console.WriteLine("Its a till");
        }

        public void ScoreGame()
        {

            Player first = new Player();
            Player second = new Player();
            Die result = new Die();

            round_nr = 1;

            while (round_nr < 6)
            {
                Console.ReadLine();
                Console.WriteLine("\n ~~~~~~~~~ Round {0} ~~~~~~~~~ \n", round_nr);
                Console.ReadKey();
                first.playGame();
                scoresum += first.lastScore;
                Console.WriteLine("Your total score is: " + scoresum + "\n");
                Console.ReadKey();
                second.playGame2();
                scoresum2 += second.lastScore2;
                Console.WriteLine("Your total score is: " + scoresum2);
                round_nr++;
            }
            CompareScores(first, second);
        }

        public void CompareScores(Player player1, Player player2)

        {
            if (scoresum > scoresum2) Console.WriteLine("------------------ " + player1.name + " won the game!------------------ ");
            else if (scoresum == scoresum2) Console.WriteLine("------------------  It is a till! ------------------ ");
            else Console.WriteLine("------------------ " + player2.name + " won the game! ------------------ ");
        }
        public void scoreGame2Players()
        {
            Player first = new Player();
            Player second = new Player();
            Die result = new Die();
            round_nr = 1;

            while (round_nr < 6)
            {
                Console.ReadLine();
                Console.WriteLine("\n ~~~~~~~~~ Round {0} ~~~~~~~~~ \n", round_nr);
                Console.ReadKey();
                first.playGame();
                scoresum += first.lastScore;
                Console.WriteLine("Your total score is: " + scoresum + "\n");
                Console.ReadKey();
                second.playGame3();
                scoresum2 += second.lastScore2;
                Console.WriteLine("Your total score is: " + scoresum2);
                round_nr++;
            }
            CompareScores(first, second);
        }
    }


    /*In class Die the are methods 'throws','throws2' and 'throwsPlayer2' which are responsible for taking random numbers (1,7) for dice throws.
      To store randomNumbers I used List collection. To add elements to intList I used for loop.
      The program displays dices from each 'set of throws'(3 throws, 2throws, 1throw) and sets the maximum valuefor them.  */
    public class Die
    {
        public int throws()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> intList = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                intList.Add(rnd.Next(1, 7));
            }

            int max1 = Math.Max(intList[0], intList[1]);
            int max2 = Math.Max(max1, intList[2]);
            Console.WriteLine("Your dices are: {0}, {1}, {2} and max is {3}", intList[0], intList[1], intList[2], max2);
            Console.ReadKey();
            int max3 = Math.Max(intList[3], intList[4]);
            Console.WriteLine("Your dices are: {0}, {1} and max is {2}", intList[3], intList[4], max3);
            Console.ReadKey();
            Console.WriteLine("Your dice is: {0} and is a max", intList[5]);
            return max2 + max3 + intList[5];

        }
        public int throws2()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> intList = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                intList.Add(rnd.Next(1, 7));
            }

            int max1 = Math.Max(intList[0], intList[1]);
            int max2 = Math.Max(max1, intList[2]);
            Console.WriteLine("Your dices are: {0}, {1}, {2} and max is {3}", intList[0], intList[1], intList[2], max2);
            int max3 = Math.Max(intList[3], intList[4]);
            Console.WriteLine("Your dices are: {0}, {1} and max is {2}", intList[3], intList[4], max3);
            Console.WriteLine("Your dice is: {0} and is a max", intList[5]);
            return max2 + max3 + intList[5];

        }

        public int throwsPlayer2()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> intList = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                intList.Add(rnd.Next(1, 7));
            }

            int max1 = Math.Max(intList[0], intList[1]);
            int max2 = Math.Max(max1, intList[2]);
            Console.WriteLine("Your dices are: {0}, {1}, {2} and max is {3}", intList[0], intList[1], intList[2], max2);
            Console.ReadKey();
            int max3 = Math.Max(intList[3], intList[4]);
            Console.WriteLine("Your dices are: {0}, {1} and max is {2}", intList[3], intList[4], max3);
            Console.ReadKey();
            Console.WriteLine("Your dice is: {0} and is a max", intList[5]);
            return max2 + max3 + intList[5];

        }


    }   /*In Program class in the Main method I used do while loop.
        In do section I used if statement to let player choose the number of players and between match game and score game. 
        If player inputs somethig irrelevant there is an exception handling to take care of that. 
        After choosing the type of game and numer of players program uses MatchGame or ScoreGame or MatchGame2Players or ScoreGame2Players methods from Game class.
        When somebody wins the game, console asks player if he wants to restart or quit.
        The answer is the while condition. Restart means that do while loop continues, quit means it breaks and the program closes.*/
    class Program
    {
        static void Main(string[] args)
        {
            Game gra = new Game();
            string answerRestart = "";
            string answerPlay;
            int answerPlayers;
            do
            {
                try
                {
                    Console.WriteLine("1 Player or 2 Players?");
                    answerPlayers = int.Parse(Console.ReadLine().ToLower());
                    if (answerPlayers == 1)
                    {
                        Console.WriteLine("Match play or Score play?");
                        answerPlay = Console.ReadLine().ToLower();

                        if (answerPlay == "match play")
                        {
                            gra.MatchGame();
                        }
                        else if (answerPlay == "score play")
                        {
                            gra.ScoreGame();
                        }
                        else
                        {
                            throw new Exception(string.Format("You have to choose between Match play and Score play"));
                        }

                    }
                    else if (answerPlayers == 2)
                    {
                        Console.WriteLine("Match play or Score play?");
                        answerPlay = Console.ReadLine().ToLower();
                        if (answerPlay == "match play")
                        {
                            gra.matchGame2Players();
                        }
                        else if (answerPlay == "score play")
                        {
                            gra.scoreGame2Players();
                        }
                        else
                        {
                            throw new Exception(string.Format("You have to choose between Match play and Score play"));
                        }
                    }
                }
                catch (FormatException e) { Console.WriteLine("You were supposted to enter intiger 1 or 2! error.message: {0}", e.Message); }
                catch (ArgumentNullException e) { Console.WriteLine("You have to write something! error.message: {0}", e.Message); }
                catch (Exception e) { Console.WriteLine("You have to choose between Match play and Score play {0}", e.Message); }
                try
                {
                    Console.WriteLine("Would you like to start again or quit?");
                    answerRestart = Console.ReadLine().ToLower();
                    if ((answerRestart != "start again") && (answerRestart != "quit"))
                    {
                        throw new ArgumentException(string.Format("You have to choose between start again and quit"));
                    }
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine("You have to choose between start again and quit {0}", e.Message);
                    Console.WriteLine("Do you want to quit? Enter yes or no");
                    string answerQuit = Console.ReadLine().ToLower();
                    if (answerQuit == "yes") answerRestart = "quit";
                    else answerRestart = "start again";
                }


                finally { Console.WriteLine("Done with exception handling"); }
            } while (answerRestart == "start again");
            Console.WriteLine("Thank you for playing, Mark! xoxo");
            Console.ReadLine();


        }
    }
}





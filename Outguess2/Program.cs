using System;

namespace Outguess2
{
    class Program
    {
        static void Main(string[] args)
        {//Repeat Variables
            string repeat = "Y";
            int startingCash = 0;
            int endingCash = 0;
            int intialCash = 0;
            int winPercentage = 0;
            int amountLeft = 0;

            //Tell User about program
            Prompt("In this program you will try to guess a random number between 1 & 100.\nYou can select how many attempts you get but no more than 10.\nReward is multiplied by the amount of guesses you wager!");
            Console.WriteLine();
            startingCash = PromptInt("Hi there big gambler how much cash you bringing to the table?");
            intialCash = startingCash;
            amountLeft = startingCash;
            do
            { //Start of repeat loop

                //Variables
                int userGuess = 0;
                Random random = new Random();
                int numberOfGuesses = 0;
                int guessesRemaining = 0;
                int wagerAmount = 0;
                int amountPayout = 0;
                int guesses = 0;
                int randomNumber = random.Next(1, 101);

                numberOfGuesses = PromptInt("Please enter how many guesses you want. Max number of guesses you can use is 10.");
                guessesRemaining = numberOfGuesses;

                  //number of guesses validation
                    while (numberOfGuesses > 10)
                    {
                        Console.WriteLine("Please select a lower amount of guesses.");
                        numberOfGuesses = PromptInt("Please enter how many guesses you want. Max of 10.");
                        guessesRemaining = numberOfGuesses;
                    }//end number of guesses validation

                wagerAmount = PromptInt("Now how much would you like to wager?");
                amountLeft = startingCash - wagerAmount;

                
                    while (wagerAmount > startingCash)
                    {
                        Console.WriteLine("Please enter a wager lower than your amount of cash.");
                        wagerAmount = PromptInt("How much would you like to wager?");
                    }//end validation

                //wager validation
                


                //Get user input and compare statements
                while (guesses < numberOfGuesses && userGuess != randomNumber)
                {
                    guessesRemaining--;
                    userGuess = PromptInt("Please enter your guess:");

                    if (userGuess == randomNumber)
                    {
                        Console.WriteLine("Congratulations you got the right answer!");
                        amountPayout = PayoutMenu(wagerAmount, numberOfGuesses);
                        Console.WriteLine($"Your winnings are {amountPayout:C}");
                        amountLeft = amountLeft + amountPayout;
                    }
                    else if (userGuess < randomNumber)
                    {
                        Console.WriteLine($"Sorry that guess was too low! You have {guessesRemaining} guesses remaining!");
                    }
                    else if (userGuess > randomNumber)
                    {
                        Console.WriteLine($"Sorry that guess was too high! You have {guessesRemaining} guesses remaining!");
                    }//end comparison if statements

                    guesses++;
                }//end while

                Console.WriteLine();
                Console.WriteLine($"The number was {randomNumber}");

                startingCash -= wagerAmount;
                startingCash += amountPayout;
                endingCash = amountLeft;

                Console.WriteLine();
                Console.WriteLine($"You now have {endingCash:C} cash left.");
                Console.WriteLine();
                Console.WriteLine("Would you like to repeat this program [Y/N]?");
                repeat = Console.ReadLine().Trim().ToUpper();

            } while (repeat == "Y" && startingCash > 0); //end do loop


            if (repeat != "Y")
            {
                Console.WriteLine("Oh no it looks like you chose not to play again.");
            }//end repeat if statement
            else if (startingCash == 0)
            {
                Console.WriteLine("Oops it looks like you're out of money");
            }//end cash if statement


            if (endingCash > intialCash)
            {
                winPercentage = CalWinPerc(endingCash, startingCash);
                Console.WriteLine($"Your win percentage is %{winPercentage}");
            }//end win percentage if statement




        }//end main



        //This is the payout menu. It controls the payout for each guess
        static int PayoutMenu(int wagerAmount, int numberOfGuesses)
        {

            //variable
            int amountPayout = 0;

            //Calcuilates the payback for each number of guesses
            if (numberOfGuesses == 1)
            {
                amountPayout = wagerAmount * 10;
            }
            else if (numberOfGuesses == 2)
            {
                amountPayout = wagerAmount * 9;
            }
            else if (numberOfGuesses == 3)
            {
                amountPayout = wagerAmount * 8;
            }
            else if (numberOfGuesses == 4)
            {
                amountPayout = wagerAmount * 7;
            }
            else if (numberOfGuesses == 5)
            {
                amountPayout = wagerAmount * 6;
            }
            else if (numberOfGuesses == 6)
            {
                amountPayout = wagerAmount * 5;
            }
            else if (numberOfGuesses == 7)
            {
                amountPayout = wagerAmount * 4;
            }
            else if (numberOfGuesses == 8)
            {
                amountPayout = wagerAmount * 3;
            }
            else if (numberOfGuesses == 9)
            {
                amountPayout = wagerAmount * 2;
            }
            else if (numberOfGuesses == 10)
            {
                amountPayout = wagerAmount * 1;
            }//end if

            return amountPayout;

        }//end function

        static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim().ToUpper();
        }//end number prompt
        static double PromptDouble(string message)
        {
            double parsedValue = 0.0;

            while (double.TryParse(Prompt(message), out parsedValue) == false)
            {
                Console.WriteLine("Invalid Entry");
            }//end validation while

            return parsedValue;
        }//end number prompt function

        static int PromptInt(string message)
        {
            int parsedValue = 0;

            while (int.TryParse(Prompt(message), out parsedValue) == false)
            {
                Console.WriteLine("Invalid Entry");
            }//end validation while

            return parsedValue;
        }//end number prompt function

        //Start CalWinPerc (calculate winning percentage) function
        static int CalWinPerc(int intialCash, int endingCash)
        {

            //variable 
            int winningPercent = 0;

            return winningPercent = ((endingCash - intialCash) / intialCash) * 100;


        }//end main
    }//end class
}//end namespace

using System;

namespace Outguess
{
    class Program
    {
        static void Main(string[] args)
        {//Repeat Variables
            string repeat = "Y";
            double startingCash = 0;
            double endingCash = 0;
            double intialCash = 0;              
            double amountLeft = 0;
            int gamesPlayed = 0;
            int gamesWon = 0;
            double winPercentage = 0;

            //Tell User about program
            Prompt("In this program you will try to guess a random number between 1 & 100.\nYou can select how many attempts you get but no more than 10.\nReward is multiplied by the amount of guesses you wager!");
            Console.WriteLine();
            startingCash = PromptDouble("Hi there big gambler how much cash you bringing to the table?");

            //starting cash validation
            while(startingCash <= 0)
            {
                Console.WriteLine($"Sorry you can't bring negative amount or zero dollars to the table.");
                startingCash = PromptDouble("How much cash do you wanna bring to the table?");
            }//end starting cash validation

                intialCash = startingCash;
                amountLeft = startingCash;

            do { //Start of repeat loop

                //Variables
                int userGuess = 0;
                Random random = new Random();
                int numberOfGuesses = 0;
                int guessesRemaining = 0;               
                double wagerAmount = 0;
                double amountPayout = 0;                
                int guesses = 0;
                int randomNumber = random.Next(1, 101);
                       
                              

                     numberOfGuesses = PromptInt("Please enter how many guesses you want. Max number of guesses you can use is 10.");
                     guessesRemaining = numberOfGuesses;

                    //number of guesses validation
                    while (numberOfGuesses > 10 || numberOfGuesses <= 0)
                    {
                        Console.WriteLine("Please select a lower amount of guesses.");
                        numberOfGuesses = PromptInt("Please enter how many guesses you want. You must chose atleast 1 and no more than 10.");
                        guessesRemaining = numberOfGuesses;
                    }//end number of guesses validation


                     wagerAmount = PromptInt("Now how much would you like to wager?");
                      
                  
                    //wager validation
                    while (wagerAmount > startingCash || wagerAmount <= 0)
                    {
                        Console.WriteLine($"Please enter a wager lower than your amount of cash. And a value greater than 0. You have {startingCash:C} left! ");
                        wagerAmount = PromptInt("How much would you like to wager?");
                    }//end validation

                     amountLeft = startingCash - wagerAmount;

                
                    //Get user input and compare statements
                    while (guesses < numberOfGuesses && userGuess != randomNumber)
                    {   guessesRemaining--;
                        userGuess = PromptInt("Please enter your guess:");
                                              
                        if (userGuess == randomNumber)
                        {
                            Console.WriteLine("Congratulations you got the right answer!");
                            amountPayout = PayoutMenu(wagerAmount,numberOfGuesses);
                            Console.WriteLine($"Your winnings are {amountPayout:C}");
                            amountLeft = amountLeft + amountPayout;
                            gamesWon++;
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
                   
                   gamesPlayed++;


                       if (startingCash <= 0 || amountLeft <= 0)
                       {
                            Console.WriteLine("Oops it looks like you're out of money!");
                            Console.WriteLine();
                       }//end cash if statement


            } while (repeat == "Y" && startingCash > 0); //end do loop

           
            if (repeat != "Y")
            {
                Console.WriteLine("Oh no it looks like you chose not to play again.");
                Console.WriteLine();             
                Console.WriteLine($"You played {gamesPlayed} game(s)");
                Console.WriteLine($"You won {gamesWon} game(s)!");
                Console.WriteLine($"You started with {intialCash:C}");
                Console.WriteLine($"You ended with {endingCash:C}");
            }//end repeat if statement
               
            
                
            winPercentage = (gamesWon / (double)gamesPlayed) * 100;           
            Console.WriteLine();
            Console.WriteLine($"You won %{winPercentage:F2} of your games!");
           
                                     
           

         
        }//end main



        //This is the payout menu. It controls the payout for each guess
        static double PayoutMenu( double wagerAmount, double numberOfGuesses) {

            //variable
            double amountPayout = 0;

            //Calcuilates the payback for each number of guesses
            if (numberOfGuesses == 1) {
               amountPayout= wagerAmount * 10;
            } else if (numberOfGuesses == 2) {
               amountPayout = wagerAmount * 9;
            } else if (numberOfGuesses == 3) {
               amountPayout = wagerAmount * 8;
            } else if (numberOfGuesses == 4) {
               amountPayout = wagerAmount * 7;
            } else if (numberOfGuesses == 5) {
               amountPayout = wagerAmount * 6;
            } else if (numberOfGuesses == 6) {
               amountPayout = wagerAmount * 5;
            } else if (numberOfGuesses == 7) {
               amountPayout = wagerAmount * 4;
            } else if (numberOfGuesses == 8) {
               amountPayout = wagerAmount * 3;
            } else if (numberOfGuesses == 9) {
               amountPayout = wagerAmount * 2;
            } else if (numberOfGuesses == 10) {
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
        static double CalWinPerc (double intialCash, double endingCash)
        {

            //variable 
            double winningPercent = 0;
            winningPercent = ((endingCash - intialCash) / intialCash) * 100;
            return winningPercent;

        }//end CalWinPerc function

    }//end class
}//end namespace





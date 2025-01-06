//Math Game - Console App for The C# Academy
//Author: afilipkowski
using System.Diagnostics;

//setting up necessary variables
Random random = new Random();
Stopwatch stopwatch = new Stopwatch();

List<string> gameHistory = new List<string>();
int roundsAmount;
int correctAnswers;
bool hardMode = false;
bool keepPlaying = true;
int maxNumber;
int number1;
int number2;

//main game loop
do
{
    correctAnswers = 0; //resetting the score each time the game starts
    DisplayMenu();
    int gameMode = int.Parse(Console.ReadLine());
    switch (gameMode)
    {
        case 1:
            Console.WriteLine("You selected Addition.");
            GameSetup();
            Addition();
            break;
        case 2:
            Console.WriteLine("You selected Subtraction.");
            GameSetup();
            Subtraction();
            break;
        case 3:
            Console.WriteLine("You selected Multiplication.");
            GameSetup();
            Multiplication();
            break;
        case 4:
            Console.WriteLine("You selected Division."); ;
            GameSetup();
            Division();
            break;
        case 5:
            Console.WriteLine("You selected Game History.");
            foreach (string game in gameHistory)
            {
                Console.WriteLine(game);
            }
            break;
        case 6:
            Console.WriteLine("You selected Exit.");
            keepPlaying = false;
            break;
        default:
            Console.WriteLine("Invalid game mode");
            break;
    }
} while (keepPlaying);

Console.WriteLine("Press any key to close the window");
Console.ReadLine();
void DisplayMenu()
{
    string welcomeMessage = "Welcome to the Math Game!";
    Console.WriteLine("--------" + welcomeMessage + "--------");
    Console.WriteLine("Choose game mode:");
    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Game History\n6. Exit");
    Console.WriteLine("-----------------------------------------");
}
void GameSetup() //this function is used to determine the number of rounds and enable hard mode
{
    Console.WriteLine("Enter the number of rounds you want to play:");
    bool validAnswer = false;
    do
    {
        validAnswer = int.TryParse(Console.ReadLine(), out roundsAmount);
        if (validAnswer == false)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    } while (validAnswer == false);

    Console.WriteLine("Do you want to play in hard mode? (y/n)");
    string hardModeAnswer = Console.ReadLine();
    if (hardModeAnswer.ToLower() == "y")
    {
        hardMode = true;
    }
    else if (hardModeAnswer.ToLower() == "n")
    {
        hardMode = false;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter y or n.");
    }
    maxNumber = hardMode ? 101 : 11;
}
void Addition()
{
    stopwatch.Start();
    for (int i = 0; i < roundsAmount; i++)
    {
        number1 = random.Next(1, maxNumber); //maxNumber value is assigned in GameSetup function, depending on the game mode
        number2 = random.Next(1, maxNumber);
        Console.WriteLine($"{number1}+{number2}");

        int answer;
        bool validAnswer = false;
        do
        {
            validAnswer = int.TryParse(Console.ReadLine(), out answer);
            if (validAnswer == false)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (validAnswer == false);

        if (answer == number1 + number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
    stopwatch.Stop();
    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine($"You answered {correctAnswers} questions correctly out of {roundsAmount}!");
    Console.WriteLine($"It took you {ts.Seconds},{ts.Milliseconds/10} seconds to complete the game.");
    gameHistory.Add($"{DateTime.Now} - Addition - {(hardMode ? "Hard mode" : "Normal mode")} -  Score:{correctAnswers}/{roundsAmount}");
}
void Subtraction()
{
    stopwatch.Start();
    for (int i = 0; i < roundsAmount; i++)
    {
        number1 = random.Next(1, maxNumber);
        number2 = random.Next(1, maxNumber);
        Console.WriteLine($"{number1}-{number2}");

        int answer;
        bool validAnswer = false;
        do
        {
            validAnswer = int.TryParse(Console.ReadLine(), out answer);
            if (validAnswer == false)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (validAnswer == false);

        if (answer == number1 - number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
    stopwatch.Stop();
    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine($"You answered {correctAnswers} questions correctly out of {roundsAmount}!");
    Console.WriteLine($"It took you {ts.Seconds},{ts.Milliseconds / 10} seconds to complete the game.");
    gameHistory.Add($"{DateTime.Now} - Subtraction - {(hardMode ? "Hard mode" : "Normal mode")} - Score:{correctAnswers}/{roundsAmount}");

}
void Multiplication()
{
    if (hardMode)
    {
        maxNumber -= 80; //to keep hard mode from being too hard
    }
    stopwatch.Start();
    for (int i = 0; i < roundsAmount; i++)
    {
        number1 = random.Next(1, maxNumber);
        number2 = random.Next(1, maxNumber);
        Console.WriteLine($"{number1}*{number2}");

        int answer;
        bool validAnswer = false;
        do
        {
            validAnswer = int.TryParse(Console.ReadLine(), out answer);
            if (validAnswer == false)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (validAnswer == false);

        if (answer == number1 * number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
    stopwatch.Stop();
    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine($"You answered {correctAnswers} questions correctly out of {roundsAmount}!");
    Console.WriteLine($"It took you {ts.Seconds},{ts.Milliseconds / 10} seconds to complete the game.");
    gameHistory.Add($"{DateTime.Now} - Multiplication - {(hardMode ? "Hard mode" : "Normal mode")} - Score:{correctAnswers}/{roundsAmount}");
}
void Division()
{
    //maxNumber is set manually in this case to make the possible equation pool larger
    if (hardMode)
    {
        maxNumber = 1000; 
    }
    else
    {
        maxNumber = 100;
    }
    stopwatch.Start();
    for (int i = 0; i < roundsAmount; i++)
    {
        do
        {
            number1 = random.Next(1, maxNumber);
            number2 = random.Next(1, maxNumber);
        }
        while (number1 % number2 != 0);

        Console.WriteLine($"{number1}/{number2}");

        int answer;
        bool validAnswer = false;
        do
        {
            validAnswer = int.TryParse(Console.ReadLine(), out answer);
            if (validAnswer == false)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (validAnswer == false);

        if (answer == number1 / number2)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
    stopwatch.Stop();
    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine($"You answered {correctAnswers} questions correctly out of {roundsAmount}!");
    Console.WriteLine($"It took you {ts.Seconds},{ts.Milliseconds / 10} seconds to complete the game.");
    gameHistory.Add($"{DateTime.Now} - Division - {(hardMode? "Hard mode" : "Normal mode")} - Score:{correctAnswers}/{roundsAmount}");
}
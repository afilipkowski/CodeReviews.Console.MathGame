//Math Game - Console App for The C# Academy
//Author: afilipkowski

DisplayMenu();
int gameMode = int.Parse(Console.ReadLine());
Random random = new Random();
int roundsAmount;
bool hardMode = false;
int maxNumber;

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
        break;
    default:
        Console.WriteLine("Invalid game mode");
        break;
}
Console.ReadLine();


void DisplayMenu()
{
    string welcomeMessage = "Welcome to the Math Game!";
    Console.WriteLine("--------" + welcomeMessage + "--------");
    Console.WriteLine("Choose game mode:");
    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division");
}

void GameSetup()
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
    for (int i = 0; i < roundsAmount; i++)
    {
        int number1 = random.Next(1, maxNumber);
        int number2 = random.Next(1, maxNumber);
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
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }

}
void Subtraction()
{
    for (int i = 0; i < roundsAmount; i++)
    {
        int number1 = random.Next(1, maxNumber);
        int number2 = random.Next(1, maxNumber);
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
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
}
void Multiplication()
{
    if (hardMode)
    {
        maxNumber -= 80; //to keep hard mode from being too hard
    }
    for (int i = 0; i < roundsAmount; i++)
    {
        int number1 = random.Next(1, maxNumber);
        int number2 = random.Next(1, maxNumber);
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
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }
    }
}
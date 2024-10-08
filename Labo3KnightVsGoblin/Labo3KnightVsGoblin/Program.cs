Console.WriteLine(@"
           /\                Knight VS Goblin                 /\
 _         )( _____________________    ______________________ )(         _
(_)///////(**)_____________________>  <______________________(**)\\\\\\\(_)
           )(                                                 )(
           \/                                                 \/");
Console.WriteLine();
Console.WriteLine("===========================================================================");
Console.WriteLine();

Random randomNumberGenerator = new Random();

Console.Write("Enter the health points for your knight: ");
if (int.TryParse(Console.ReadLine(), out int knightHealth))
{
    if (knightHealth < 0 || knightHealth > 100)
    {
        // Number out of range, use default value
        knightHealth = 100;
    }
}
else
{
    // Invalid number, use default value
    knightHealth = 100;
}

int goblinHealth = randomNumberGenerator.Next(1, 101);

// Deel 4: 4 attempts
//for(int attempt = 1; attempt <= 4; attempt++)
//{

// Deel 5: loop while knight AND goblin are alive, stop when one of them is dead
int round = 1;
do
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine($"--->>> Round {round}... fight! <<<---");
    Console.WriteLine();
    Console.ResetColor();

    int knightAttack = randomNumberGenerator.Next(10, 26);
    int goblinAttack = randomNumberGenerator.Next(5, 16);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Knight health: {knightHealth}");
    Console.WriteLine($"Goblin health: {goblinHealth}");
    Console.WriteLine();
    Console.ResetColor();

    Console.WriteLine("Choose your next move carefully:");
    Console.WriteLine("1. Attack");
    Console.WriteLine("2. Heal");
    //TODO: Add more actions
    Console.Write("Enter your choice: ");

    switch (Console.ReadLine())
    {
        case "1":
            goblinHealth -= knightAttack;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You attacked the goblin for {knightAttack} damage!");
            Console.ResetColor();
            break;
        case "2":
            knightHealth += 10;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You healed yourself for 10 health points!");
            Console.ResetColor();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Invalid move! Please choose a valid move.");
            Console.ResetColor();
            break;
    }

    if(goblinHealth > 0)
    {
        knightHealth -= goblinAttack;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You were attacked by the goblin for {goblinAttack} damage!");
        Console.ResetColor();
    }
    Console.WriteLine();
    round++;
} while (knightHealth > 0 && goblinHealth > 0); //repeat while both knight and goblin are alive

if (goblinHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Victory! You have killed the goblin!");
    Console.ResetColor();
}
else
{
    Console.WriteLine($"Goblin health: {goblinHealth}"); 
}

if (knightHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Defeat! You were killed by the goblin!");
    Console.ResetColor();
}
else
{
    Console.WriteLine($"Knight health: {knightHealth}");
}

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

using System;
using System.Diagnostics.Metrics;

#region arrays and variables
string[] listName = null;
int[] listAge = null;
double totalAge = 0;
double averageAge;
string name;
int age;
bool menuLoop = true;
int menuChoice = 0;
int familyMembers = 0;
#endregion

while (menuLoop)
{
    PrintMenu();

    switch (menuChoice)
    {
        case 1:
            AddFamilyMembers();
            break;

        case 2:
            PrintFamilyMembers();
            break;

        case 3:
            PrintTotalAge();
            break;

        case 4:
            PrintAverageAge();
            break;

        case 5:
            DieDieDie();
            break;

    }
}

void PrintMenu()
{
    try
    {
        Console.WriteLine("1) Ange antal familjemedlemmar och namn samt ålder på dessa");
        Console.WriteLine("2) Skriva ut familjemedlemmarna");
        Console.WriteLine("3) Skriva ut deras totala ålder");
        Console.WriteLine("4) Skriva ut deras medelålder");
        Console.WriteLine("5) Avsluta programmet");
        Console.Write("Val: ");
        menuChoice = int.Parse(Console.ReadLine());

        if (menuChoice < 1 || menuChoice > 5)
        {
            Console.WriteLine("1-5 finns att välja på");
        }
    }

    catch (FormatException)
    {
        Console.WriteLine("Bara siffror");
    }
}
void AddFamilyMembers()
{
    Console.Clear();
    Console.WriteLine("Hur många medlemmar finns i familjen?");
    try
    {
        familyMembers = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Använd siffror");
    }
    Console.Clear();
    listName = new string[familyMembers];
    listAge = new int[familyMembers];
    Console.Clear();

    for (int i = 0; i < familyMembers; i++)
    {
        Console.Write($"Ange namn på familjemedlem {i + 1}: ");
        name = Console.ReadLine();
        Console.Clear();

        Console.Write($"{name}s ålder är: ");
        if (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Clear();
            Console.WriteLine("Siffror min vän, siffror. På det igen!");
            i--;
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        listName[i] = name;
        listAge[i] = age;
        //So I don't have to do a whole new loop for age in case 3 and 4
        totalAge += age;
        Console.Clear();
    }
    Console.Clear();
}
void PrintFamilyMembers()
{
    Console.Clear();
    if (familyMembers == 0)
    {
        Console.WriteLine("Du måste lägga till familjemedlemmarna först");
    }
    else
    {
        Console.WriteLine($"De {familyMembers} medlemmarna i familjen är:");
        for (int i = 0; i < familyMembers; i++)
        {
            Console.WriteLine($"{listName[i]} som är {listAge[i]} år");
        }
    }
    Console.ReadLine();
    Console.Clear();
}
void PrintTotalAge()
{
    Console.Clear();
    if (familyMembers == 0)
    {
        Console.Clear();
        Console.WriteLine("Du måste lägga till familjemedlemmarna först");
    }
    else
    {
        Console.WriteLine($"Familjens totala ålder är {totalAge} år");

    }
    Console.ReadLine();
    Console.Clear();
}
void PrintAverageAge()
{
    Console.Clear();
    if (familyMembers == 0)
    {
        Console.Clear();
        Console.WriteLine("Du måste lägga till familjemedlemmarna först");
        Console.ReadLine();
    }
    else
    {
        averageAge = Math.Round(totalAge / familyMembers, 2);
        Console.WriteLine($"Familjens medelålder är: {averageAge:F2}");
        Console.ReadLine();
    }
    Console.Clear();
}
void DieDieDie()
{
    Console.Clear();
    Console.WriteLine("Tack för mig");
    Console.ReadLine();
    menuLoop = false;
}
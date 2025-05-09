using System;

class Program
{
    static void Main(string[] args)
    {
        // Llamar a las funciones en orden
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    // Función para mostrar el mensaje de bienvenida
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Función para pedir y devolver el nombre del usuario
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Función para pedir y devolver el número favorito del usuario
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Función para elevar al cuadrado un número
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Función para mostrar el resultado final
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
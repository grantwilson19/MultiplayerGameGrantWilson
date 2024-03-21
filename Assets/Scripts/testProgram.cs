using System;
using System.Collections.Generic;

public class BooleanSelector
{
    // List to store boolean functions
    private List<Func<bool>> booleanFunctions = new List<Func<bool>>();

    // Simulating boolean variables
    private bool HasKey = false;
    private bool HasPlate = false;
    private bool HasMeat = false;

    // Constructor to initialize the list with boolean functions
    public BooleanSelector()
    {
        // Add your boolean variables or conditions here
        booleanFunctions.Add(() => HasKey);
        booleanFunctions.Add(() => HasPlate);
        booleanFunctions.Add(() => HasMeat);
    }

    // Method to get a random boolean function from the list and print its value
    public void PrintRandomBooleanFunction()
    {
        // Get a random boolean function
        Func<bool> randomBooleanFunction = GetRandomBooleanFunction();

        // Print the selected boolean function
        Console.WriteLine($"Selected boolean function: {randomBooleanFunction.Method.Name}");

        // Print the value of the selected boolean function
        Console.WriteLine($"Value: {randomBooleanFunction.Invoke()}");
    }

    // Method to get a random boolean function from the list
    private Func<bool> GetRandomBooleanFunction()
    {
        // Get a random index within the list
        int randomIndex = UnityEngine.Random.Range(0, booleanFunctions.Count);

        // Return the randomly selected boolean function
        return booleanFunctions[randomIndex];
    }

    // Example usage
    public void Example()
    {
        // Print the selected boolean function and its value
        PrintRandomBooleanFunction();
    }

    public static void Main()
    {
        // Create an instance of BooleanSelector
        BooleanSelector booleanSelector = new BooleanSelector();

        // Print the selected boolean function and its value
        booleanSelector.Example();
    }
}

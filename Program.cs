using Assignment_ConsoleApp;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        // PrimeMode example
        Console.WriteLine("PrimeMode Example:");
        IMode primeMode = new PrimeMode();
        primeMode.Initialize(new Dictionary<string, object> { { "START", 1 }, { "END", 11 } });
        Console.WriteLine("Number of primes: " + primeMode.Execute());

        // EncryptionMode example
        Console.WriteLine("\nEncryptionMode Example:");
        IMode encryptionMode = new EncryptionMode();
        encryptionMode.Initialize(new Dictionary<string, object>
        {
            { "MAPPINGFILE", "mapping.txt" },
            { "WORDSTOENCRYPT", "words.txt" },
            { "ENCRYPTEDFILE", "encrypted.txt" }
        });
        encryptionMode.Execute();
        Console.WriteLine("Words encrypted and written to file.");

        // Run test methods
        RunTests();
    }

    static void RunTests()
    {
        Console.WriteLine("\nRunning Tests...");

        // Test for PrimeMode
        TestPrimeMode();

        // Test for EncryptionMode
        TestEncryptionMode();

        Console.WriteLine("All Tests Completed.");
    }

    static void TestPrimeMode()
    {
        IMode primeMode = new PrimeMode();

        // Test case 1
        primeMode.Initialize(new Dictionary<string, object> { { "START", 1 }, { "END", 5 } });
        Debug.Assert(primeMode.Execute() == 2, "Test Case 1 Failed");

        // Test case 2
        primeMode.Initialize(new Dictionary<string, object> { { "START", 7 }, { "END", 11 } });
        Debug.Assert(primeMode.Execute() == 0, "Test Case 2 Failed");

        // Test case 3
        primeMode.Initialize(new Dictionary<string, object> { { "START", 1 }, { "END", 11 } });
        Debug.Assert(primeMode.Execute() == 4, "Test Case 3 Failed");

        Console.WriteLine("PrimeMode Tests Passed.");
    }

    static void TestEncryptionMode()
    {
        // Create test files
        string mappingFilePath = "test_mapping.txt";
        string wordsFilePath = "test_words.txt";
        string encryptedFilePath = "test_encrypted.txt";

        File.WriteAllText(mappingFilePath, "a|k\nb|s\nc|h");
        File.WriteAllText(wordsFilePath, "abc\nbca\ncab");

        IMode encryptionMode = new EncryptionMode();
        encryptionMode.Initialize(new Dictionary<string, object>
        {
            { "MAPPINGFILE", mappingFilePath },
            { "WORDSTOENCRYPT", wordsFilePath },
            { "ENCRYPTEDFILE", encryptedFilePath }
        });

        encryptionMode.Execute();

        // Validate output
        string[] encryptedWords = File.ReadAllLines(encryptedFilePath);
        Debug.Assert(encryptedWords.Length == 3, "Encryption Test Failed: Word Count Mismatch");
        Debug.Assert(encryptedWords[0] == "ksh", "Encryption Test Failed: Word 1 Mismatch");
        Debug.Assert(encryptedWords[1] == "shk", "Encryption Test Failed: Word 2 Mismatch");
        Debug.Assert(encryptedWords[2] == "hks", "Encryption Test Failed: Word 3 Mismatch");

        // Cleanup test files
        File.Delete(mappingFilePath);
        File.Delete(wordsFilePath);
        File.Delete(encryptedFilePath);

        Console.WriteLine("EncryptionMode Tests Passed.");
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_ConsoleApp
{
    public class EncryptionMode:IMode
    {

        private Dictionary<char, char> encryptionMap = new Dictionary<char, char>();
        private List<string> wordsToEncrypt = new List<string>();
        private string? encryptedFilePath;

        // Initialize method to load data from files
        public void Initialize(Dictionary<string, object> parameters)
        {
            // Assumption: The file paths are provided as string values in the dictionary.
            string? mappingFilePath = parameters.ContainsKey("MAPPINGFILE") ? parameters["MAPPINGFILE"].ToString() : string.Empty;
            string? wordsFilePath = parameters.ContainsKey("WORDSTOENCRYPT") ? parameters["WORDSTOENCRYPT"].ToString() : string.Empty;
            encryptedFilePath = parameters.ContainsKey("ENCRYPTEDFILE") ? parameters["ENCRYPTEDFILE"].ToString() : string.Empty;

            // Load the encryption map
            if (File.Exists(mappingFilePath))
            {
                foreach (var line in File.ReadAllLines(mappingFilePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        encryptionMap[parts[0][0]] = parts[1][0];
                    }
                }
            }

            // Load the words to encrypt
            if (File.Exists(wordsFilePath))
            {
                wordsToEncrypt = File.ReadAllLines(wordsFilePath).ToList();
            }
        }

        // Execute method to encrypt words and write them to the output file
        public int Execute()
        {
            if (string.IsNullOrEmpty(encryptedFilePath))
            {
                throw new InvalidOperationException("Encrypted file path is not set.");
            }

            using (StreamWriter writer = new StreamWriter(encryptedFilePath))
            {
                foreach (var word in wordsToEncrypt)
                {
                    string encryptedWord = EncryptWord(word);
                    writer.WriteLine(encryptedWord);
                }
            }

            return wordsToEncrypt.Count;
        }

        // Helper method to encrypt a word
        private string EncryptWord(string word)
        {
            char[] encryptedChars = word.Select(c => encryptionMap.ContainsKey(c) ? encryptionMap[c] : c).ToArray();
            return new string(encryptedChars);
        }
    }
}

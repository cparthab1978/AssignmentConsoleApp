Programming Question One 
Create a progrqam (can be console or wpf/winforms) that has the following features:

1) An interface called IMode that consists of at least a function int Execute() and a function void Initialize(Dictionary<string,int>)
2) A class called PrimeMode with the following features:
   - Implements the IMode interface
   - Has private int data members start, end
   - For initialize:
       Private data member start is set to the value with key "START"
	   Private data member ebd is set to the value with key "END"
   - For Execute:
       Will return an integer that is the number of prime numbers between the start and end private values, not including the start or end numbers.
       Please include code comments with any assumptions and other logic you use in your solution.
			Sample Inputs/Outputs:
			start: 1   end: 5     Return 2 
			start: 7   end: 11    Return 0
			start: 1   end: 11    Return 4
3) A class called EncryptionMode with the following features:
   - Implements the IMode interface   
   - For initialize:
       The value of key "MAPPINGFILE" will be a path to a file on disk
	     It should read the contents of the file and fill in your EncryptionList
	     The format of the encryption map should be one line per letter, with the original letter first, then | as a delimter, then the second letter as the replacement.
		 Example:
			a|k
			b|s
			c|h
	   The value of key "WORDSTOENCRYPT" will be a path to a file on disk
	     It will contain a list of words, one word per line
		 Example:
			dog
			cat
	   The value of the key "ENCRYPTEDFILE" will be a path to a file on disk
	- For Execute:
	   For each word that was in the WORDSTOENCRYPT file, write them to ENCRYPTEDFILE replacing the letters in the encryption map
	   For example: 
	      If the word was caba, and the encryption map was
		     a|k
			 b|s
			 c|h
	      then caba would be written to encryptedfile as hksk

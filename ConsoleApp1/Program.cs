using System.Text;

public class OldPhoneKeyPad
{
    // Details of every key as per the letters on the old phone keypad
    private static readonly string[] Keypad =
    [
        "",     // 0 
        "",     // 1 
        "ABC",   // 2
        "DEF",   // 3
        "GHI",   // 4
        "JKL",   // 5
        "MNO",   // 6
        "PQRS",  // 7
        "TUV",   // 8
        "WXYZ",  // 9
    ];

    public static string OldPhoneKeyPadMethod(string input)
    {
        StringBuilder output = new StringBuilder();
        int count = 1;
        char previousCharacter = '\0';

        // Looping each character in the input string
        for (int i = 0; i < input.Length; i++)
        {
            char currentCharacter = input[i];

            if (currentCharacter == '#') continue;

            // for space between character sequence
            if (currentCharacter == ' ')
            {
                // If the previous character is valid, add the output
                if (previousCharacter != '\0' && previousCharacter != ' ')
                {
                    AddCharacter(previousCharacter, count, output);
                }
                previousCharacter = '\0'; 
                count = 1;            // resetting count here
                continue;
            }

            // If current character is  same as the previous characteer, increase the the count
            if (currentCharacter == previousCharacter)
            {
                count++;
            }
            else
            {
                // continue with previous sequence before switching to  new one
                if (previousCharacter != '\0' && previousCharacter != ' ')
                {
                    AddCharacter(previousCharacter, count, output);
                }
                previousCharacter = currentCharacter;
                count = 1; // resetting count here for  new character
            }
        }

        // Read the last press before returning the output
        if (previousCharacter != '\0' && previousCharacter != ' ')
        {
            AddCharacter(previousCharacter, count, output);
        }

        return output.ToString();
    }

    
    private static void AddCharacter(char key, int Count, StringBuilder output)
    {
        int keyIndex = key - '0';  // Convert the key to its index in array
        if (keyIndex < 2 || keyIndex > 9) return; // Invalid key press (reject 0 and 1)

        string Group = Keypad[keyIndex];
        int characterIndex = (Count - 1) % Group.Length;  
        output.Append(Group[characterIndex]);
    }

    public static void Main(string[] args)
    {
        // OldPhonePad method with example inputs as mentioned in casestudy
        Console.WriteLine(OldPhoneKeyPadMethod("33#"));             //Output: E
        Console.WriteLine(OldPhoneKeyPadMethod("227*#"));           //Output: B
        Console.WriteLine(OldPhoneKeyPadMethod("4433555 555666#")); //Output: HELLO
        Console.WriteLine(OldPhoneKeyPadMethod("3 33 33744455255525559266444")); //Output: DEEPIKALALWANI "Testing my name"
        Console.WriteLine(OldPhoneKeyPadMethod("8 88777444666*664#")); //Output: TURIONG
    }
}

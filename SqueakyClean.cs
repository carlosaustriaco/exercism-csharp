using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        string output;
        bool foundHifen;

        output = identifier.Replace(' ', '_');
        output = output.Replace("\0", "CTRL");

        foundHifen = false;

        for (int i = 0; i < output.Length; i++)
        {
            if (foundHifen)
            {
                output = output.Remove(i - 1, 1);
                StringBuilder strBuilder = new StringBuilder(output);
                strBuilder[i - 1] = char.ToUpper(output[i - 1]);
                output = strBuilder.ToString();
                
                break;
            }

            if (output[i] == '-')
            {
                foundHifen = true;
            }
        }

        StringBuilder strBuilder2 = new StringBuilder(output);

        int j = 0;
        string regex = "[α-ω]";
        while (j < strBuilder2.Length)
        {
            if ((!char.IsLetter(strBuilder2[j]) && (strBuilder2[j] != '_')) || Regex.IsMatch(strBuilder2[j].ToString(), regex, RegexOptions.None))
            {
                strBuilder2.Remove(j, 1);
            }
            else
            {
                j++;
            }
        }

        output = strBuilder2.ToString();
        
        return output;
    }
}

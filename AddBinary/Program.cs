public class Solution
{
    public static void Main()
    {
        string a = decToBinaryString(17);
        string b = decToBinaryString(17);
        AddBinary(a, b);
    }

    static string AddBinary(string a, string b)
    {
        int maxLen = a.Length > b.Length ? a.Length : b.Length;
        int aDigit, bDigit, carry = 0, start = maxLen;
        int aIndex = a.Length - 1, bIndex = b.Length - 1;
        string answer = String.Empty;

        if (maxLen > 0)
        {
            //Allocate for carry
            char[] result = new char[maxLen + 1];

            while (start > 0)
            {
                aDigit = aIndex >= 0 ? a[aIndex--] - '0' : 0;
                bDigit = bIndex >= 0 ? b[bIndex--] - '0' : 0;

                //Modeled after Full Adder circuit logic
                int sum = aDigit ^ bDigit;
                result[start--] = (char)('0' + (sum ^ carry));
                carry = (aDigit & bDigit) | (carry & sum);
            }

            result[start] = (char)(carry + '0');

            //Removes 0's to the left of answer
            while (start < maxLen && result[start] == '0') start++;

            answer = new string(result, start, maxLen + 1 - start);
        }
        Console.WriteLine(answer);
        return answer;
    }

    static string decToBinaryString(int n)
    {
        // array to store binary number
        int[] binaryNum = new int[32];
        string? binary;
        List<String> binaries = new List<String>();

        // counter for binary array
        int i = 0;
        while (n > 0)
        {
            // storing remainder in
            // binary array
            binaryNum[i] = n % 2;
            n = n / 2;
            i++;
        }

        // printing binary array
        // in reverse order
        for (int j = i - 1; j >= 0; j--)
        {
            binary = binaryNum[j].ToString();
            binaries.Add(binary + "");
        }
        return String.Join("", binaries);
    }
}
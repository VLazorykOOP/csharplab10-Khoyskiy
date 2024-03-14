using System;
using System.Collections.Generic;

public class ReverseCheck
{
    public bool IsReverse(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            throw new ReverseCheckException("Lengths of the strings are not equal.");


        Stack<char> stack = new Stack<char>();

        foreach (char c in s1)
        {
            stack.Push(c);
        }

        foreach (char c in s2)
        {
            if (stack.Count == 0 || c != stack.Pop())
            {
                return false;
            }
        }

        return true;
    }

    public void Run()
    {
        try
        {
            string s1 = "hello";
            string s2 = "olleh";

            bool result = IsReverse(s1, s2);

            Console.WriteLine($"Is '{s2}' the reverse of '{s1}'? {result}");

            string s1_1 = "hello";
            string s2_1 = "oghsl";

            bool result1 = IsReverse(s1_1, s2_1);

            Console.WriteLine($"Is '{s2_1}' the reverse of '{s1_1}'? {result1}");
        }
        catch (ReverseCheckException ex)
        {
            Console.WriteLine($"ReverseCheckException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
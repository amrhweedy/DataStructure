namespace BalancedParenthesesUsingStack;

internal class Program
{
    static void Main(string[] args)
    {

        string expression = "({})";
        bool result = AreBalanced(expression);
        Console.WriteLine(result);

        Console.ReadKey();
    }


    static bool AreBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            else if (c == ')' || c == '}' || c == ']')
            {

                if (stack.Count == 0)
                    return false;


                char top = stack.Pop(); // we push in the stack the ( or { or [ and pop them
                if (!ArePair(top, c))
                    return false;

            }
        }

        return stack.Count() == 0; // if the stack is empty we return true
    }

    static bool ArePair(char opening, char closing)
    {
        return (opening == '(' && closing == ')') ||
               (opening == '[' && closing == ']') ||
               (opening == '{' && closing == '}');
    }
}


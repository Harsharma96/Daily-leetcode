public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();

        foreach (string token in tokens)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                int b = stack.Pop();
                int a = stack.Pop();

                int result = 0;

                if (token == "+")
                    result = a + b;
                else if (token == "-")
                    result = a - b;
                else if (token == "*")
                    result = a * b;
                else if (token == "/")
                    result = a / b;

                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }
}
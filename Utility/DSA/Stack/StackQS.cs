using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DSA.Stack
{
    public class StackQS
    {
        public static int IsBalancedParenthesis(string A)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < A.Length; i++)
            {
                char character = A[i];
                if (character == '[' || character == '{' || character == '(')
                    stack.Push(character);
                else if (character == ']' || character == '}' || character == ')')
                {
                    if (stack.Count == 0)
                        return 0;
                    switch (character)
                    {
                        case ']':
                            if (stack.Pop() != '[')
                                return 0;
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                                return 0;
                            break;
                        case ')':
                            if (stack.Pop() != '(')
                                return 0;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (stack.Count == 0)
                return 1;
            return 0;
        }
    }
}

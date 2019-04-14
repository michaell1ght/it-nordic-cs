using System;
using System.Collections.Generic;

public class BracketValidSequenceChecker
{
    char openRoundBracer = '(';
    char openSquareBracer = '[';
    char closeRoundBracer = ')';
    char closeSquareBracer = ']';

    private char[] BracketArray;

    public BracketValidSequenceChecker(string inputBracketString)
    {
        if (String.IsNullOrEmpty(inputBracketString))
        {
            throw new ArgumentNullException();
        }
        else
        {
            BracketArray = inputBracketString.ToCharArray();
        }
    }

    public bool BracketIsValidSequenceCheck()
    {
        Stack<char> bracketStack = new Stack<char>();
        foreach (char currentBracket in BracketArray)
        {
            // Если открывающая скобка - записываем символ скобки в стек
            if (currentBracket == openRoundBracer || currentBracket == openSquareBracer)
            {
                bracketStack.Push(currentBracket);
            }

            // Если закрывающа скобка
            if (currentBracket == closeSquareBracer || currentBracket == closeRoundBracer)
            {
                // если стек не пуст
                if (bracketStack.Count > 0)
                {
                    char lastSymbol = bracketStack.Peek(); // символ из вершины стека

                    // закрывающая скобка должна быть такого же типа как последняя открывающая
                    // иначе в стеке останется символ
                    if (currentBracket == closeSquareBracer && lastSymbol == openSquareBracer || 
                        currentBracket == closeRoundBracer && lastSymbol == openRoundBracer)
                    {
                        bracketStack.Pop();
                    }
                }
                else
                {
                    // Встретили закрывающую скобку, но не было открывающей
                    return false;
                }
            }
        }

        // Если стек не пустой, значит порядок скобок был нарушен
        return bracketStack.Count == 0;
    }
}
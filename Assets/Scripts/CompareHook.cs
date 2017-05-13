using UnityEngine;
using System.Collections;

public class CompareHook : Hook
{
    public char input { get; private set; }
    public char[] compares { get; private set; }
    public string objective { get; private set; }

    public CompareHook(char inp, char[] coms, string obj)
    {
        input = inp;
        compares = coms;
        objective = obj;
        type = HookType.Compare;
    }
    public CompareHook(char inp, char[] coms)
    {
        input = inp;
        compares = coms;
        type = HookType.Compare;
    }

    public override string ToString()
    {
        string str = "Compare " + input + " to: ";
        for (int i = 0; i < compares.Length; i++)
        {
            str += compares[i] + " ";
        }
        return base.ToString();
    }
}

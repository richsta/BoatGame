using UnityEngine;
using System.Collections;

public class FirstContent : Content
{
    private char[] letters = { 'A', 'B', 'C'}; //{ "Christopher Columbus discovers America", "Declaration of Independence", "Civil War" }; //,1492 ,1776 ,1861 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    private string[] objectives = { "Which event occured in 1492?", "Which event occured in 1776?", "Which event occured in 1861?" }; //{ "Christopher Columbus discovers America", "Declaration of Independence", "Civil War" }; //,1492 ,1776 ,1861 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

    public FirstContent()
    {
        name = "History";
        description = "Blow the iceberg! To rightly identify events' chronology";
    }

    public override char getItem()
    {
        return letters[Random.Range(0, letters.Length)];
    }

    public override string getTerm()
    {
        return objectives[Random.Range(0, objectives.Length)];
    }

    protected override void customHook(Hook hook)
    {
        switch (hook.type)
        {
            case HookType.Compare:
                compareHook((CompareHook)hook);
                break;
            default:
                base.customHook(hook);
                break;
        }
    }

    private void compareHook(CompareHook hook)
    {
        bool vowel = false;
        if (hook.objective == "Which event occured in 1492?" && hook.input == 'A')
        {
            vowel = true;
        }
        if (hook.objective == "Which event occured in 1776?" && hook.input == 'B')
        {
            vowel = true;
        }
        if (hook.objective == "Which event occured in 1861?" && hook.input == 'C')
        {
            vowel = true;
        }
        if (vowel)
        {
            lastActionValid = true;
        }
        else
        {
            lastActionValid = false;
        }
    }
}


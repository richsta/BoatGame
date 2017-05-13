using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitanicalMechanics : Mechanics
{
    public void sendHook(char c, char[] cs, string objective)
    {
        passHook(new CompareHook(c, cs, objective));
    }
}
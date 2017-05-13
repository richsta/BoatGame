using UnityEngine;
using System.Collections;

/// <summary>
/// This is the one framework file you should be editing.
/// Everything else from the framework should not need editing.
/// </summary>
public static class GameInfo
{
    // Change to the title of your game.
    public const string gameTitle = "Titanical";

    // Change this to be an object of your Mechanics type.
    public static Mechanics currentMechanics = new TitanicalMechanics();

    // Change each of these to be one of your content objects. If you only have one, leave the second alone for now.
    public static Content contentOne = new FirstContent();
    public static Content contentTwo = new SpellingContent();
}

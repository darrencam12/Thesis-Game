using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    /// <summary>
    /// The word to show in the UI.
    /// </summary>
    public string word;

    /// <summary>
    /// A customized random order.
    /// </summary>
    [Header("leave empty if you want randmized")]
    public string desiredRandom;

    public string GetRandomString()
    {
        // if desiredRandom is not empty, the code will return it as a string.
        if (!string.IsNullOrEmpty(desiredRandom))
        {
            return desiredRandom;
        }

        // set the basic result to the original word.
        string result = word;

        // randomize the letter order as long as result is still equal to the original word.
        while (result == word)
        {
            result = "";
            List<char> characters = new List<char>(word.ToCharArray());
            while (characters.Count > 0)
            {
                int indexChar = Random.Range(0, characters.Count - 1);
                result += characters[indexChar];

                characters.RemoveAt(indexChar);
            }
        }

        return result;
    }

    public char[] GetRandomChars()
    {
        return GetRandomString().ToCharArray();
    }
}
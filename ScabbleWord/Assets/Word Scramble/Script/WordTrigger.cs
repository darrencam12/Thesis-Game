using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when you add this script, it will automatically add a WordScramble script as well.
[RequireComponent(typeof(WordScramble), typeof(BoxCollider))]
public class WordTrigger : MonoBehaviour
{
    WordScramble scramble;

    private void Awake()
    {
        scramble = GetComponent<WordScramble>();
        scramble.onWordComplete += OnFinishWord;
    }

    private void Update()
    {
        // this is to activate the scarmble
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Activate();
        }
    }

    private void OnFinishWord()
    {
        Debug.Log("Bridge is now visible.");
        scramble.onWordComplete -= OnFinishWord;
    }

    public void Activate()
    {
        scramble.ShowScramble();
    }
}

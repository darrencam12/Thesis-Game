 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// when you add this script, it will automatically add a WordScramble script as well.
[RequireComponent(typeof(WordScramble), typeof(BoxCollider))]
 public class WordTrigger : Trigger
{
    [SerializeField] private Image scrmImg;

    WordScramble scramble;

    private void Awake()
    {
        scramble = GetComponent<WordScramble>();
        scramble.onWordComplete += OnFinishWord;
    }

    private void OnFinishWord()
    {
        Debug.Log("Bridge is now visible.");
        scramble.onWordComplete -= OnFinishWord;
        OnCorrect();
        scrmImg.enabled = false;
    }

    public override void Activate()
    {
        scramble.ShowScramble();
    }
    public override void Deactivate()
    {
        base.Deactivate();
        scramble.HideScramble();
    }

    protected override void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            scrmImg.enabled = true;
            Activate(); 
        }
    }
    protected override void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            scrmImg.enabled = false;
            scramble.HideScramble();
        }
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// when you add this script, it will automatically add a WordScramble script as well.
[RequireComponent(typeof(WordScramble), typeof(BoxCollider))]
 public class WordTrigger : MonoBehaviour
{

    [SerializeField] private Image scrmImg;

    public GameObject Bridge;
    WordScramble scramble;

    private void Awake()
    {
        scramble = GetComponent<WordScramble>();
        scramble.onWordComplete += OnFinishWord;
    }
    void Start()
    {
         Bridge.SetActive(false);
    }
    private void Update()
    {
        // this is to activate the scarmble
        /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Activate();
        }*/
    }

    private void OnFinishWord()
    {
        Debug.Log("Bridge is now visible.");
        scramble.onWordComplete -= OnFinishWord;
        Bridge.SetActive(true);
        Deactivate();
        gameObject.SetActive(false);


        
    }

    public void Activate()
    {
        scramble.ShowScramble();
    }
    public void Deactivate()
    {
        scramble.HideScramble();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            scrmImg.enabled = true;
            Activate(); 
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            scrmImg.enabled = false;
        }
    }
}

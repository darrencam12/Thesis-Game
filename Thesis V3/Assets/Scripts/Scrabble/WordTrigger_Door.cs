using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(WordScramble), typeof(BoxCollider))]
public class WordTrigger_Door : MonoBehaviour
{
  [SerializeField] private Image scrmImg;

    public GameObject Door;
    WordScramble scramble;

    private void Awake()
    {
        scramble = GetComponent<WordScramble>();
        scramble.onWordComplete += OnFinishWord;
    }
    void Start()
    {
         
         Door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnFinishWord()
    {
        Debug.Log("Door is now invisible.");
        scramble.onWordComplete -= OnFinishWord;
        Door.SetActive(false);
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
            Deactivate();
        }
    }
}

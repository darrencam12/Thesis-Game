using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScrambleSingleton : MonoBehaviour
{
    public Word[] words;

    [Header("UI REFERENCE")]
    public CharObject prefab;
    public Transform container;
    public float space;

    public float lerpspeed = 5;


    List<CharObject> charObjects = new List<CharObject>();
    CharObject firstSelected;
    public int currentWord;

    // this makes sure there is only one WordScramble instance on the scene.
    public static WordScrambleSingleton main;

    void Awake()
    {
        // there should only be one of this on the scene.
        if (main == null)
        {
            main = this;
        }
        else
        {
            Debug.LogWarning("There are more than one WordScramble class on this scene. Remove one of them.");
        }
    }

    private void OnDestroy()
    {
        main = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowScramble(currentWord);
    }

    // Update is called once per frame
    void Update()
    {
        RepostionObject();
    }

    void RepostionObject()
    {
        if (charObjects.Count == 0)
        {
            return;
        }
        float center = (charObjects.Count -1) / 2;
        for (int i = 0; i < charObjects.Count; i++)
        {
            charObjects[i].rectTransform.anchoredPosition = Vector2.Lerp(charObjects[i].rectTransform.anchoredPosition, new Vector2((i - center)* space, 0), lerpspeed * Time.deltaTime);
            charObjects[i].index = i;
        }
        
    }
    
    // show a random word to the screen
    public void ShowScramble()
    {
        ShowScramble(Random.Range(0, words.Length - 1));
    }
    /*
        show word for collecton with desired index
        param index = index of the elemnt
     */
    public void ShowScramble(int index)
    {
        charObjects.Clear();
        foreach(Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // WORDS FINISHED
        if (index > words.Length - 1)
        {
            Debug.LogError("index out of range, please enter range between 0-"+ (words.Length -1).ToString());
            return;
        }
        char[] chars = words[index].GetRandomString().ToCharArray();
        foreach(char c in chars)
        {
            CharObject clone = Instantiate(prefab.gameObject).GetComponent<CharObject>();
            clone .transform.SetParent(container);

            charObjects.Add(clone.Init(c));
        }
        currentWord = index;
    }

    public void Swap (int indexA, int indexB)
    {
        CharObject tmpA = charObjects[indexA];

        charObjects[indexA] = charObjects[indexB];
        charObjects[indexB] = tmpA;

        charObjects[indexA].transform.SetAsLastSibling();
        charObjects[indexB].transform.SetAsLastSibling();

        CheckWord();
    }
    

    public void Select (CharObject charObject)
    {
        if(firstSelected)
        {
            Swap(firstSelected.index, charObject.index);

            //unselect
            firstSelected.Select();
            charObject.Select();
            
        }else
        {
            firstSelected = charObject;
        }
    }

    public void UnSelect()
    {
        firstSelected = null;
    }
    public void CheckWord()
    {
        StartCoroutine(CoCheckWord());
    }

    IEnumerator CoCheckWord()
    {
        yield return new WaitForSeconds(0.5f);

        string word = "";
        foreach (CharObject charObject in charObjects)
        {
            word += charObject.character;
        }
        if(word == words[currentWord].word)
        {
            currentWord++;
            ShowScramble(currentWord);
            
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScramble : MonoBehaviour
{
    // this is a blank function in the form of a class.
    // you can create instances of this that trigger other functions.
    public delegate void OnWordComplete();

    // this is the declaration of the above.
    public OnWordComplete onWordComplete;

    public Word word;

    [Header("UI REFERENCE")]
    public CharObject prefab;
    public Transform container;
    public float space;

    public float lerpspeed = 5;


    List<CharObject> charObjects = new List<CharObject>();
    CharObject firstSelected;

    // Start is called before the first frame update
    void Start()
    {
        // ShowScramble();
    }

    // Update is called once per frame
    void Update()
    {
        RepostionObject();
    }

    void RepostionObject()
    {
        // if no objects, stop.
        if (charObjects.Count == 0)
        {
            return;
        }

        // swap positions with another letter.
        float center = (charObjects.Count - 1) / 2;
        for (int i = 0; i < charObjects.Count; i++)
        {
            charObjects[i].rectTransform.anchoredPosition = Vector2.Lerp(charObjects[i].rectTransform.anchoredPosition, new Vector2((i - center) * space, 0), lerpspeed * Time.deltaTime);
            charObjects[i].index = i;
        }

    }
    /*
        show word for collecton with desired index
        param index = index of the elemnt
     */
    public void ShowScramble()
    {
        // clear the list and destroy the children of this object.
        charObjects.Clear();
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // Get the word as an array of characters and clone/set up the prefab.
        char[] chars = word.GetRandomChars();
        foreach (char c in chars)
        {
            CharObject clone = Instantiate(prefab.gameObject).GetComponent<CharObject>();
            clone.transform.SetParent(container);

            // Inits the character visually and internally and then
            // adds that same character to the list for checking.
            charObjects.Add(clone.Init(c, this));
        }
    }

    // swap letters and check the word.
    public void Swap(int indexA, int indexB)
    {
        CharObject tmpA = charObjects[indexA];

        charObjects[indexA] = charObjects[indexB];
        charObjects[indexB] = tmpA;

        charObjects[indexA].transform.SetAsLastSibling();
        charObjects[indexB].transform.SetAsLastSibling();

        CheckWord();
    }

    // calling this function from the button inspector.
    public void Select(CharObject charObject)
    {
        // if this was selected second, swap it with another letter.
        if (firstSelected)
        {
            Swap(firstSelected.index, charObject.index);

            //unselect
            firstSelected.Select();
            charObject.Select();

        }
        else
        {
            // if there is no letter selected, this one is first.
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
        // gives the letters a chance to animate.
        yield return new WaitForSeconds(0.5f);

        // setting a blank word for later checking.
        string currentWord = "";

        // combine the letters into a single word.
        foreach (CharObject charObject in charObjects)
        {
            currentWord += charObject.character;
        }

        if (currentWord == word.word)
        {
            // whatever the onWordComplete function is made up of, use it.
            onWordComplete();
        }

    }
}

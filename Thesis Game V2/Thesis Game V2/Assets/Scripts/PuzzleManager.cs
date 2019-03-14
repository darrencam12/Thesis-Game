using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int wordLength;
    public GameObject cubePos;
    public GameObject letter;
    public Transform intialPos;
    public Vector3 latestPos;
    private List<Vector3> positions;
    // Start is called before the first frame update
    void Awake()
    {
        
        //Debug.Log(wordLength);
        
    }
    void Start()
    {
        positions = new List<Vector3>();
        for (int i = 0; i < wordLength; i++)
        {
            Instantiate(cubePos, new Vector3(intialPos.position.x + i, intialPos.position.y, intialPos.position.z), Quaternion.identity);
            latestPos = new Vector3(intialPos.position.x + i, intialPos.position.y, intialPos.position.z);
            positions.Add(latestPos);
        }

        foreach(Vector3 cu in positions)
        {
            Instantiate(letter, new Vector3(cu.x, cu.y, cu.z),Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Add()
    {

    }

}

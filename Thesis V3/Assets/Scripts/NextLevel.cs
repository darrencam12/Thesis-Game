using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    public int time;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag =="Player")
        {
            StartCoroutine(changeScene());
        }
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

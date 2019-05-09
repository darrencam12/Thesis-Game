using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    public string password;
    public float rotationSpeed;
    public float floatingSpeed;
    public float maxHeight;
    public float minHeight;
    public TextMeshProUGUI passwordText;
    public GameObject passwordHolder;
    public GameObject floppyDisk;
    // Start is called before the first frame update
    void Start()
    {
        passwordHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        passwordText.text = password;
        floppyDisk.transform.Rotate(0f,rotationSpeed * Time.deltaTime,0f);
        floppyDisk.transform.position = new Vector3(transform.position.x,Mathf.PingPong(Time.time*floatingSpeed,minHeight)+maxHeight,transform.position.z);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag =="Player")
        {
            passwordHolder.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
      if (other.tag =="Player")
        {
            passwordHolder.SetActive(false);
        }   
    }

   
}
 
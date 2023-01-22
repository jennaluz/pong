using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        //Debug.Log("help screen");
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("help screen");
            //gameObject.SetActive(true);
       } 
    }
}

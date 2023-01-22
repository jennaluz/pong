using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2PaddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            logic.moveUp(gameObject);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            logic.moveDown(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public LogicScript logic;
    public Camera mainCam;

    public Rigidbody2D ballBody;
    public float xVel;
    public float yVel;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        Time.timeScale = 1;

        xVel = Random.Range(-19f, -14f);
        yVel = Random.Range(-4f, 4f);
        ballBody.velocity = new Vector2(xVel, yVel);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];

        if (contact.point.x <= -13.9) {
            xVel = Random.Range(-19f, -14f);
        } else if (contact.point.x >= 13.9) {
            yVel = Random.Range(14f, 19f);
        } else if (collision.collider.tag == "Boundary") {
            if (yVel < 0) {
                yVel = Random.Range(1f, 5f);
            } else {
                yVel = Random.Range(-5f, -1f);
            }
        } else if ((contact.point.y <= -4) || (contact.point.y >= 4)) {
            xVel *= -1;
        
            if (yVel > 0) {
                yVel = Random.Range(5f, 7f);
            } else {
                yVel = Random.Range(-7f, -5f);
            }
        } else {
            if (yVel > 0) {
                yVel = Random.Range(5f, 7f);
            } else {
                yVel = Random.Range(-5f, -7f);
            }

            Debug.Log(contact.point.x + " " + contact.point.y);
            if (contact.point.x < 0) {
                xVel = Random.Range(16f, 21f);
            } else {
                xVel = Random.Range(-21f, -16f);
            }
            Debug.Log("xVel " + xVel);
        }

        ballBody.velocity = new Vector2(xVel, yVel);
        if (collision.collider.tag == "Paddle") {
            mainCam.backgroundColor = new Color(Random.Range(0.4784314f, 0.6784314f), Random.Range(0.4784314f,0.6784314f), Random.Range(0.4784314f, 0.6784314f), 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player 1 Boundary") {
            logic.restart(gameObject, 2);
        } else {
            logic.restart(gameObject, 1);
        }
    }
}
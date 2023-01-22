using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject helpScreen;
    public GameObject winnerScreen;
    public Camera mainCam;
    public Text p1TextScore;
    public Text p2TextScore;
    public Text pausePlay;
    public Text winner;

    public int paddleSpeed;
    public int p1Score = 0;
    public int p2Score = 0;
    private string pause = "[SPACE] for HELP\n[ESC] to EXIT";
    private string play = "[SPACE] to PLAY\n[ESC] to EXIT";
    private string newWinner = "PLAYER 2 WINS!";

    void Start()
    {
        helpScreen.SetActive(false);
        winnerScreen.SetActive(false);

        mainCam.backgroundColor = new Color(Random.Range(0.4784314f, 0.6784314f), Random.Range(0.4784314f,0.6784314f), Random.Range(0.4784314f, 0.6784314f), 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (helpScreen.activeSelf) {
                helpScreen.SetActive(false);
                pausePlay.text = pause;
                Time.timeScale = 1;
            } else {
                helpScreen.SetActive(true);
                pausePlay.text = play;
                Time.timeScale = 0;
            }
        }

        if ((p1Score == 10) || (p2Score == 10)) {
            if (p2Score == 10) {
                winner.text = newWinner;
            }

            winnerScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void moveUp(GameObject paddle)
    {
        paddle.transform.position = paddle.transform.position + (Vector3.up * paddleSpeed) * Time.deltaTime;
    }

    public void moveDown(GameObject paddle)
    {
        paddle.transform.position = paddle.transform.position + (Vector3.down * paddleSpeed) * Time.deltaTime;
    }

    public void addPoint(int player)
    {
        if (player == 1) {
            Debug.Log("player 1 point");
            p1Score++;
            p1TextScore.text = p1Score.ToString();
        } else {
            Debug.Log("player 2 point");
            p2Score++;
            p2TextScore.text = p2Score.ToString();
        }
    }

    public void restart(GameObject ball, int player) {
        float xVel = Random.Range(12, 18);
        float yVel = Random.Range(2, 5);

        if (player == 1) {
            addPoint(1);
            xVel *= -1;
        } else {
            addPoint(2);
        }

        ball.transform.position = new Vector3(0, 0, 0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);

        StartCoroutine(delayStart());
    }

    public IEnumerator delayStart()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
    }
}
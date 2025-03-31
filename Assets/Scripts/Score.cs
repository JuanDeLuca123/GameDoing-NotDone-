using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            score++;
            Debug.Log("Se sumo 1 moneda");
            Debug.Log("Tus monedas son: " + score);
            scoreText.text = "" + score;
        }
    }
}

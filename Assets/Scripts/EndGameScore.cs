using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour
{
    public Text scoreDisplay;

    private void Start()
    {
        scoreDisplay.text = "Your score was " + Mathf.Round(PlayerController.playerScore);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : EnemyManager
{
    //public float score = BulletScript.score;
    public Text scoreDisplay;
    //public float timer = EnemyManager.timer;
    public Text timeDisplay;
    public Text comboDisplay;
    public Text rocketDisplay;
    public Text wideshotDisplay;

    public Text shipHealthDisplay;

    public void Update()
    {
        scoreDisplay.text = "Score: " + Mathf.Round(PlayerController.playerScore);
        timeDisplay.text = "Time: " + Mathf.Round(timer);
        if (PlayerController.altWeaponType == "Rocket" && PlayerController.rocketCount > 0)
        {
            rocketDisplay.gameObject.SetActive(true);
            rocketDisplay.text = "Rockets: " + PlayerController.rocketCount;
        }
        if (PlayerController.altWeaponType != "Rocket" || PlayerController.rocketCount <= 0)
        {
            rocketDisplay.gameObject.SetActive(false);
        }


        if (PlayerController.altWeaponType == "Wideshot" && PlayerController.wideshotCount > 0)
        {
            wideshotDisplay.gameObject.SetActive(true);
            wideshotDisplay.text = "Wideshot: " + PlayerController.wideshotCount;
        }
        if (PlayerController.altWeaponType != "Wideshot" || PlayerController.wideshotCount <= 0)
        {
            wideshotDisplay.gameObject.SetActive(false);
        }

        if (PointShop.isCarrierSelected || PointShop.isDestroyerSelected)
        {
            shipHealthDisplay.gameObject.SetActive(true);
            shipHealthDisplay.text = "Ship health: " + PlayerController.shipHealth;
        }

        comboDisplay.text = "Combo Multiplier: " + PlayerController.comboMultiplier;

    }
}

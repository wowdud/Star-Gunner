using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed;
    public GameObject bullet;
    public GameObject rocket;
    public GameObject wideshot;

    public GameObject corvette;
    public GameObject frigate;
    public GameObject cruiser;
    public GameObject carrier;
    public GameObject destroyer;

    public static int rocketCount;
    public static int wideshotCount;
    public static int shipHealth;

    public bool gameOver;
    public float mainfireDelay;
    public float altfireDelay;
    public static string altWeaponType = "None";
    public static float playerScore = 0;
    public static float comboMultiplier = 1;
    public float totalScore;
    void Start()
    {
        playerScore = 0;
        rocketCount = 0;
        wideshotCount = 0;
        altWeaponType = "None";

        if (PointShop.isCorvetteEquipped)
        {
            mainfireDelay = 0.455f;
            altfireDelay = 0.45f;
            speed = 9f;
            shipHealth = 1;
            corvette.SetActive(true);
            frigate.SetActive(false);
            cruiser.SetActive(false);
            carrier.SetActive(false);
            destroyer.SetActive(false);
        }
        if (PointShop.isFrigateSelected)
        {
            mainfireDelay = 0.425f;
            altfireDelay = 0.42f;
            speed = 7.7f;
            shipHealth = 1;
            corvette.SetActive(false);
            frigate.SetActive(true);
            cruiser.SetActive(false);
            carrier.SetActive(false);
            destroyer.SetActive(false);
        }
        if (PointShop.isCruiserSelected)
        {
            mainfireDelay = 0.43f;
            altfireDelay = 0.43f;
            speed = 8.8f;
            shipHealth = 1;
            corvette.SetActive(false);
            frigate.SetActive(false);
            cruiser.SetActive(true);
            carrier.SetActive(false);
            destroyer.SetActive(false);
        }
        if (PointShop.isCarrierSelected)
        {
            mainfireDelay = 0.42f;
            altfireDelay = 0.25f;
            speed = 7f;
            shipHealth = 2;
            corvette.SetActive(false);
            frigate.SetActive(false);
            cruiser.SetActive(false);
            carrier.SetActive(true);
            destroyer.SetActive(false);
        }
        if (PointShop.isDestroyerSelected)
        {
            mainfireDelay = 0.325f;
            altfireDelay = 0.3f;
            speed = 7.5f;
            shipHealth = 2;
            corvette.SetActive(false);
            frigate.SetActive(false);
            cruiser.SetActive(false);
            carrier.SetActive(false);
            destroyer.SetActive(true);
        }
    }


    void Update()
    {
        //movement left right and up down
        Vector3 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;
        movement.z = Input.GetAxisRaw("Vertical");
        movement *= Time.deltaTime * speed;
        transform.Translate(movement);

        //keep the player on the screen
        Vector3 clamped = transform.position;
        clamped.x = Mathf.Clamp(clamped.x, -20, 20);
        clamped.z = Mathf.Clamp(clamped.z, -11, 11);
        clamped.y = 0;
        transform.position = clamped;

        mainfireDelay -= Time.deltaTime;
        altfireDelay -= Time.deltaTime;

        //shoot button
        if (Input.GetButtonDown("Fire1"))
        {
            if (mainfireDelay <= 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                if (PointShop.isCorvetteEquipped)
                {
                    mainfireDelay = 0.455f;;
                }
                if (PointShop.isFrigateSelected)
                {
                    mainfireDelay = 0.425f;
                }
                if (PointShop.isCruiserSelected)
                {
                    mainfireDelay = 0.43f;
                }
                if (PointShop.isCarrierSelected)
                {
                    mainfireDelay = 0.385f;
                }
                if (PointShop.isDestroyerSelected)
                {
                    mainfireDelay = 0.325f;
                }

            }
        }
        //alternative fire
        if (Input.GetButtonDown("Fire2"))
        {
            if (altfireDelay <= 0 && altWeaponType == "Rocket" && rocketCount > 0)
            {
                Instantiate(rocket, transform.position, transform.rotation);
                rocketCount -= 1;
                if (PointShop.isCorvetteEquipped)
                {
                    altfireDelay = 0.9f;  
                }
                if (PointShop.isFrigateSelected)
                {
                    altfireDelay = 0.7f;
                }
                if (PointShop.isCruiserSelected)
                {
                    altfireDelay = 0.75f;
                }
                if (PointShop.isCarrierSelected)
                {
                    altfireDelay = 0.5f;
                }
                if (PointShop.isDestroyerSelected)
                {
                    altfireDelay = 0.65f;
                }
            }
            if (altfireDelay <= 0 && altWeaponType == "Wideshot" && wideshotCount > 0)
            {
                Instantiate(wideshot, transform.position, transform.rotation);
                wideshotCount -= 1;
                if (PointShop.isCorvetteEquipped)
                {
                    altfireDelay = 0.55f;
                }
                if (PointShop.isFrigateSelected)
                {
                    altfireDelay = 0.52f;
                }
                if (PointShop.isCruiserSelected)
                {
                    altfireDelay = 0.53f;
                }
                if (PointShop.isCarrierSelected)
                {
                    altfireDelay = 0.35f;
                }
                if (PointShop.isDestroyerSelected)
                {
                    altfireDelay = 0.4f;
                }
            }
        }
        if (wideshotCount == 0 && rocketCount == 0)
        {
            altWeaponType = "None";
        }

    }
    //getting hit kills the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            shipHealth -= 1;
            Destroy(collision.gameObject);
            if (shipHealth <= 0)
            {
                gameOver = true;
                Invoke("GameOver", 2);
                gameObject.SetActive(false);
           
                totalScore = PlayerPrefs.GetFloat("points");
                //totalScore += BulletScript.score;
                totalScore += playerScore;
                PlayerPrefs.SetFloat("points", totalScore);
                Debug.Log(totalScore);
            }
        }
        if (collision.collider.CompareTag("Rockets"))
        {
            if (altWeaponType != "Rocket")
            {
                altWeaponType = "Rocket";
                if (PointShop.isCarrierSelected)
                {
                    rocketCount = 20;
                }
                else if (PointShop.isCorvetteEquipped)
                {
                    rocketCount = 10;
                }
                else
                {
                    rocketCount = 12;
                }

                wideshotCount = 0;
            }
            else
            {
                if (PointShop.isCarrierSelected)
                {
                    rocketCount += 10;
                }
                else if (PointShop.isCorvetteEquipped)
                {
                    rocketCount += 5;
                }
                else
                {
                    rocketCount += 6;
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Wideshot"))
        {
            if (altWeaponType != "Wideshot")
            {
                altWeaponType = "Wideshot";
                if (PointShop.isCarrierSelected)
                {
                    wideshotCount = 25;
                }
                else if (PointShop.isCorvetteEquipped)
                {
                    wideshotCount = 18;
                }
                else
                {
                    wideshotCount = 20;
                }
                
                rocketCount = 0;
            }
            else
            {
                if (PointShop.isCarrierSelected)
                {
                    wideshotCount += 15;
                }
                else if (PointShop.isCorvetteEquipped)
                {
                    wideshotCount += 8;
                }
                else
                {
                    wideshotCount += 10;
                }
            }
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}

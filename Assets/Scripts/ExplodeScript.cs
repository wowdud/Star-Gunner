using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    //float timer = 0.1f;
    //public static float score;

    void Update()
    {
        //timer -= Time.deltaTime;
        //if (timer <= 0)
        //{
        //    Destroy(gameObject);
        //}

        // Not needed; object is destroyed when parent rocket projectile is destroyed.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerController.playerScore += 0.4f * EnemyManager.timer * PlayerController.comboMultiplier;

            Destroy(other.gameObject);
        }
    }
}
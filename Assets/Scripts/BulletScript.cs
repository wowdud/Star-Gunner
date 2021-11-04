using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 9f;
    //public static float score;

    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 15f || transform.position.z < -20f)
        {
            Destroy(gameObject);
            PlayerController.comboMultiplier = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            PlayerController.comboMultiplier += 0.01f;
            PlayerController.playerScore += 0.4f * EnemyManager.timer * PlayerController.comboMultiplier;

            Destroy(gameObject);
            Destroy(collision.gameObject);      
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveshotScript : MonoBehaviour
{
    public float speed = 12f;
    public int bulletPierce = 2;
    //public static float score;

    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 15f || transform.position.z < -20f)
        {
            Destroy(gameObject);
            if (bulletPierce == 2)
            {
                PlayerController.comboMultiplier = 1;
            }
        }
        if (bulletPierce == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            PlayerController.comboMultiplier += 0.01f;
            PlayerController.playerScore += 0.4f * EnemyManager.timer * PlayerController.comboMultiplier;

            bulletPierce -= 1;
            Destroy(collision.gameObject);
        }
    }
}

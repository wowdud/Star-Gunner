using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed = 22f;
    public GameObject explosion;
    public MeshRenderer skin;
    public Rigidbody rigid;
    //public static float score;
    float time = 0.08f;
    bool startTime = false;

    private void Start()
    {
        skin = GetComponent<MeshRenderer>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 15f || transform.position.z < -20f)
        {
            Destroy(gameObject);
            PlayerController.comboMultiplier = 1;
        }
        if (startTime == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Destroy(gameObject);
                // Gives time for explosion to destroy asteroids.
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            PlayerController.comboMultiplier += 0.01f;
            PlayerController.playerScore += 0.4f * EnemyManager.timer * PlayerController.comboMultiplier;
            explosion.SetActive(true);
            skin.enabled = false;
            rigid.isKinematic = true;
            startTime = true;
            //Set rocket to be invisible so that only explosion is visible.



            //Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * EnemyManager.enemySpeed);
        if (transform.position.z > 15f || transform.position.z < -20f)
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public event EventHandler<EnemyScript> EnemyIsDead;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyIsDead.Invoke(this, this);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            EnemyIsDead.Invoke(this, this);
        }
    }

}

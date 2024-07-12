using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoodlePlayScript : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Rigidbody rb;
    private Vector3 doodleVelocity;
    public event EventHandler CollisionChecked;
    public event EventHandler DoodleIsDead;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ScreenEnd();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform")) 
        {
            CollisionChecked.Invoke(this, EventArgs.Empty);
            rb.AddForce(collision.contacts[0].normal * jumpForce, ForceMode.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DeathZone"))
        {
            DoodleIsDead.Invoke(this, EventArgs.Empty);
        }
    }

    private void ScreenEnd()
    {
        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x)
        {
            //doodleVelocity = rb.velocity;
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x, transform.position.y, transform.position.z);
            //rb.velocity = doodleVelocity;
        }
        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x)
        {
            //doodleVelocity = rb.velocity;
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x, transform.position.y, transform.position.z);
            //rb.velocity = doodleVelocity;
        }
    }
}

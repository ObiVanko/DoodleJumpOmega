using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class DoodlePlayScript : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float bulletForce = 10f;
    private float lastTapTime = 0f;
    private float tapDelay = 0.5f;

    public event EventHandler CollisionChecked;
    public event EventHandler DoodleIsDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        HandleDoubleTap();

        if (GetComponent<Rigidbody>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

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
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x)
        { 
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x, transform.position.y, transform.position.z);
        }
    }

    void HandleDoubleTap()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time - lastTapTime < tapDelay)
            {
                ShootAtClosestEnemy();
            }
            lastTapTime = Time.time;

        }
    }

    void ShootAtClosestEnemy()
    {
        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null && IsEnemyInCameraView(closestEnemy))
        {
            Vector3 targetPosition = closestEnemy.transform.position;
            GameObject bullet = Instantiate(bulletPref, transform.position, Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());        
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            Vector3 direction = (targetPosition - transform.position).normalized;
            rbBullet.AddForce(direction * bulletForce, ForceMode.Impulse);

            StartCoroutine(BulletCoroutine(bullet));


        }
    }

    IEnumerator BulletCoroutine(GameObject go)
    {
        yield return new WaitForSeconds(3);
        Destroy(go);
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) return null;

        GameObject closestEnemy = enemies.OrderBy(e => (e.transform.position - transform.position).sqrMagnitude).First();
        return closestEnemy;
    }

    bool IsEnemyInCameraView(GameObject enemy)
    {
        Vector3 enemyViewportPosition = Camera.main.WorldToViewportPoint(enemy.transform.position);
        return enemyViewportPosition.x >= 0 && enemyViewportPosition.x <= 1 && enemyViewportPosition.y >= 0 && enemyViewportPosition.y <= 1;
    }
}



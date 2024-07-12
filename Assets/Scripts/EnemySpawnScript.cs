using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPref;
    [SerializeField] private EnemyScript es;
    private Vector3 spawnPoz = new Vector3();
    private int enemyCount = 10;
    void Start()
    {
        EnemySpawn(enemyCount);
    }

    private void es_SpawnNew(object sender, EnemyScript e)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        if (enemies.Length <= enemyCount)
        {
            EnemySpawn((enemyCount + 1) - enemies.Length);
        }
        e.EnemyIsDead -= es_SpawnNew;
        Destroy(e.gameObject);
    }

    private void EnemySpawn(int n)
    {

        for (int i = 0; i < n; i++)
        {
            spawnPoz.x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x + 1, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x - 1);
            spawnPoz.y += Random.Range(6f, 12f);

            GameObject enemyCopy = Instantiate(enemyPref, spawnPoz, Quaternion.identity);
            EnemyScript esCopy = enemyCopy.GetComponent<EnemyScript>();
            esCopy.EnemyIsDead += es_SpawnNew;
        }
       
    }

}

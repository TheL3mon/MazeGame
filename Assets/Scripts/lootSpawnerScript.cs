using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootSpawnerScript : MonoBehaviour
{
    int chestChance;
    int enemyChance;
    int numberOfEnemies;
    float newX;
    float newY;
    Vector3 chestPos;
    Vector3 enemyPos;

    void Start()
    {
        chestChance = Random.Range(1, 101);
        if (chestChance <= 30)
        {
            newX = Random.Range(-3.3f, 3.3f);
            newY = Random.Range(-3.3f, 3.3f);
            chestPos.x = gameObject.transform.position.x + newX;
            chestPos.y = gameObject.transform.position.y + newY;
            chestPos.z = 0;
            GameObject newChest = GameObject.Instantiate(Resources.Load("chest"), chestPos, Quaternion.identity) as GameObject;
            newChest.tag = "Chest";
        }

        enemyChance = Random.Range(1, 101);
        numberOfEnemies = Random.Range(1, 5);
        if (enemyChance <= 50)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                newX = Random.Range(-3.3f, 3.3f);
                newY = Random.Range(-3.3f, 3.3f);
                enemyPos.x = gameObject.transform.position.x + newX;
                enemyPos.y = gameObject.transform.position.y + newY;
                enemyPos.z = 0;
                GameObject newEnemy = GameObject.Instantiate(Resources.Load("enemy"), enemyPos, Quaternion.identity) as GameObject;
                newEnemy.tag = "Enemy";
            }
        }

    }

    void Update()
    {

    }
}

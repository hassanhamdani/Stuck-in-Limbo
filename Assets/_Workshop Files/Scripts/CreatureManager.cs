using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    public GameManager gameManager;      // Reference to the player's heatlh.
    public float spawnTime = 1.5f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public GameObject[] enemies;     // An array of possible enemies.
    public Transform ellenTransform;    // Reference to the Transform component of the Ellen prefab.

    //set max lenght of enemy array
    public int maxEnemies = 10;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }


    void Spawn()
    {
        if(gameManager.EllenonChest == true || gameManager.ElleninHouse==true)
        {
            return;
        }
        else{

        
        // If the player has no health left...
        if (!gameManager.playerAlive)
        {
            // ... exit the function.
            return;
        }

        // Get Ellen's position.
        Vector3 ellenPosition = ellenTransform.position;

        // Define the spawn area.
        float spawnAreaX = 7f;
        float spawnAreaZ = 7f;
        Vector3 spawnAreaMin = new Vector3(ellenPosition.x - spawnAreaX, 0f, ellenPosition.z - spawnAreaZ);
        Vector3 spawnAreaMax = new Vector3(ellenPosition.x + spawnAreaX, 0f, ellenPosition.z + spawnAreaZ);

        // Generate a random position within the spawn area.
        float spawnPosX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnPosZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0f, spawnPosZ);


        // Cast a ray down to find the ground level at the spawn point.
        RaycastHit hit;
        if (Physics.Raycast(spawnPosition + Vector3.up * 10f, Vector3.down, out hit, 100f))
        {
            // Adjust the spawn position to the ground level.
            spawnPosition.y = hit.point.y;
        }
        else
        {
            // If the raycast didn't hit anything, use a default y value of 0.
            spawnPosition.y = ellenPosition.y+5f;
        }

        // Create an instance of the enemy prefab at the spawn position.
        //add enemy to array, make sure array is not longer than maxEnemies
        if (enemies.Length < maxEnemies)
        {
             GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
        }
        }
    }

}

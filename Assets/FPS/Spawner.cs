using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] private float spawnInterval;
    private float spawnCooldown;

    [SerializeField] List<Enemy> enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCooldown >= 0)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                Spawn();
                spawnCooldown = spawnInterval;
            }
        }
    }

    private void Spawn()
    {
        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        var position = GetPosition();
        Instantiate(prefab, position, Quaternion.identity);
    }

    private Vector3 GetPosition()
    {
        var pos = new Vector3(1,1,1);
        if (player.position.x > 0)
            pos.x *= -1;
        if(player.position.z > 0)
            pos.z *= -1;

        pos.x *= Random.Range(3, 15);
        pos.z *= Random.Range(3, 15);

        return pos;
    }
}

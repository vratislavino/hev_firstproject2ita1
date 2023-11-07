using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    List<SpawnData> spawnData;

    [SerializeField]
    Score score;

    float probSum;
    float levelMultiplier = 1f;

    

    void Start()
    {
        score.ScoreChanged += OnScoreChanged;

        probSum = spawnData.Sum(data => data.Probability);
        InvokeRepeating("CreateRandomPrefab", 0, 0.3f);   
    }

    private void OnScoreChanged(int score) {
        levelMultiplier = Mathf.Pow(1.2f, score / 100);
    }

    private void CreateRandomPrefab() {
        CreatePrefab(GetRandomPrefab());
    }

    private void CreatePrefab(GameObject prefab) {
        var g = Instantiate(prefab, GetRandomPosition(), Quaternion.identity, transform);

        var rb = g.GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * 5 * levelMultiplier;
        rb.AddTorque(Vector3.up * 100);
        Destroy(g, 4f);
    }

    private Vector3 GetRandomPosition() {
        return new Vector3(
            Random.Range(-3f,3f),
            transform.position.y,
            transform.position.z
           );
    }

    private GameObject GetRandomPrefab() {

        float rnd = Random.Range(0f, probSum);
        float sum = 0;
        
        for(int i = 0; i < spawnData.Count; i++) {
            sum += spawnData[i].Probability;
            if(rnd <= sum) {
                return spawnData[i].Prefab;
            }
        }

        return spawnData[0].Prefab;
    }
}

[System.Serializable]
class SpawnData
{
    public GameObject Prefab;
    public float Probability;
}
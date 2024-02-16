using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject molePrefab;
    [SerializeField]
    private float maxSpawnTickRange, minSpawnTickRange;
    [SerializeField]
    private float maxMoleLifeSpan, minMoleLifeSpan;

    private float moleLifeSpanBound;
    private Vector2 maxSpawnRange, minSpawnRange;
    private float spawnTick;

    private void Awake()
    {
        float canvasH = GetComponent<RectTransform>().rect.height;  // Set up spawn position boundaries
        float canvasW = GetComponent<RectTransform>().rect.width;
        float moleH = molePrefab.GetComponent<RectTransform>().rect.height;
        float moleW = molePrefab.GetComponent<RectTransform>().rect.width;
        minSpawnRange += new Vector2(moleW / 2, moleH / 2);
        maxSpawnRange += new Vector2(canvasW - moleW / 2, canvasH - moleH / 2);
    }

    private void Start()
    {
        moleLifeSpanBound = (maxMoleLifeSpan - minMoleLifeSpan) / 2;
        Invoke("SpawnMole", 2);
    }

    private void SpawnMole()
    {
        Vector3 pos = Vector3.zero;                                 // Set up Mole stats
        pos.x = Random.Range(minSpawnRange.x, maxSpawnRange.x);
        pos.y = Random.Range(minSpawnRange.y, maxSpawnRange.y);
        float moleLifeSpan = Random.Range(minMoleLifeSpan, maxMoleLifeSpan);
        int molePointAmount = moleLifeSpan >= moleLifeSpanBound ? 1 : 2;

        GameObject mole = Instantiate(molePrefab) as GameObject;    // Instatiate and assign Mole stats
        mole.transform.SetParent(transform);
        mole.transform.position = pos;
        mole.GetComponent<Mole>().SetDifficulty(moleLifeSpan, molePointAmount);

        IncreaseDifficulty();                                       // Increase Diff and keep ticking
        spawnTick = Random.Range(maxSpawnTickRange, minSpawnTickRange);
        Invoke("SpawnMole", spawnTick);
    }
    private void IncreaseDifficulty()
    {
        maxSpawnTickRange = maxSpawnTickRange <= minSpawnTickRange + 0.1f ? maxSpawnTickRange : maxSpawnTickRange - Time.deltaTime * 30;
        maxMoleLifeSpan = maxMoleLifeSpan <= moleLifeSpanBound ? maxMoleLifeSpan : maxMoleLifeSpan -= Time.deltaTime * 30;
    }
}

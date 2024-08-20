using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillManager : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] Arms arms;
    [SerializeField] GameObject pillPrefab;
    [SerializeField] Queue<GameObject> pills = new Queue<GameObject>();
    [SerializeField] BoxCollider2D spawnRegion;

    public void SpawnPill()
    {
        Debug.Log("SpawnPill() from PillManager");

        float randomXPoint = Random.Range(spawnRegion.bounds.min.x, spawnRegion.bounds.max.x);
        float randomYPoint = Random.Range(spawnRegion.bounds.min.y, spawnRegion.bounds.max.y);

        GameObject bottle = Instantiate(pillPrefab, new Vector3(randomXPoint, randomYPoint, -1), Quaternion.identity);
        bottle.transform.SetParent(transform);
        PillBottle pb = bottle.GetComponent<PillBottle>();
        pb.SetPill(arms, this);
    }

    public void TakePill(){
        dataManager.RestoreMorality();
    }
}

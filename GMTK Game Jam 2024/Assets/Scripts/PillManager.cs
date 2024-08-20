using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillManager : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] GameObject armL;
    [SerializeField] GameObject pillPrefab;
    [SerializeField] Queue<GameObject> pills = new Queue<GameObject>();

    //Vector2 startPos = ();

    // Start is called before the first frame update
    void Start()
    {
        SpawnPill();
    }

    public void SpawnPill(){
        float yOffset = (float) 1 * pills.Count;   // depends on how many pills you have bought

        GameObject pill = Instantiate(pillPrefab, this.transform);
        pill.GetComponent<PillBottle>().arm = armL;
        pill.transform.position = new Vector2(-1.65f, -1.275f + yOffset);

        pills.Enqueue(pill);
    }

    public void TakePill(){
        if (pills.Count > 0) {
            GameObject removed = pills.Peek();
            removed.GetComponent<PillBottle>().ArmMove();

            pills.Dequeue();
            dataManager.RestoreMorality();

            foreach (GameObject pill in pills){
                pill.GetComponent<PillBottle>().DropAnim();
            }
        }
    }
}

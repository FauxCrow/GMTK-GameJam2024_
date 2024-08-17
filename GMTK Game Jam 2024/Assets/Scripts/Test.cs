using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject tospawn;
    public Transform at;
    public DocumentSO so;

    // Start is called before the first frame update
    void Start()
    {
        GameObject t = Instantiate(tospawn, at);
        t.GetComponent<Document>().FillInDocument(so);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveTexture : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] Signature signature;
    [SerializeField] GameObject contract;
    [SerializeField] GameObject variablesUI;
    [SerializeField] TextMeshPro timeText;
    
    void OnMouseDown()
    {
        signature.SaveText();
        // reset elements for gameplay
        contract.SetActive(false);
        variablesUI.SetActive(true);
        timeText.color = new Color (1,1,1,1);

        gm.GameStart();
    }
}

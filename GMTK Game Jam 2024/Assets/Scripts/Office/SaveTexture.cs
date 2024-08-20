using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveTexture : MonoBehaviour
{
    [SerializeField] Signature signature;
    [SerializeField] BoxCollider2D monitor;
    [SerializeField] GameObject contract;
    [SerializeField] TimeManager timeManager;
    [SerializeField] DataManager dataManager;
    [SerializeField] GameObject variablesUI;
    [SerializeField] TextMeshPro timeText;
    
    void OnMouseDown()
    {
        signature.SaveText();

        // reset elements for gameplay
        monitor.enabled = true;
        contract.SetActive(false);
        timeManager.enabled = true;
        variablesUI.SetActive(true);
        timeText.color = new Color (1,1,1,1);

        dataManager.Reset();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmailSingle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI senderText, contextText, detailsText;

    public void SetEmail(EmailData data){
        senderText.text = data.Sender;
        contextText.text = data.Context;
        detailsText.text = data.Details;
    }
}
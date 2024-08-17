using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Document : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] TextMeshProUGUI dateText;
    [SerializeField] TextMeshProUGUI companyText;
    [SerializeField] TextMeshProUGUI addressText;
    [SerializeField] TextMeshProUGUI salutationText;
    [SerializeField] TextMeshProUGUI subjectText;
    [SerializeField] TextMeshProUGUI detailsText;
    [SerializeField] TextMeshProUGUI endText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FillInDocument(DocumentSO documentInfo)
    {
        headerText.text = documentInfo.Header;
        dateText.text = documentInfo.Date;
        companyText.text = documentInfo.Company;
        addressText.text = documentInfo.Address;
        salutationText.text = documentInfo.Salutation;
        subjectText.text = documentInfo.Subject;
        detailsText.text = documentInfo.Details;
        endText.text = documentInfo.End;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Document")]
public class DocumentSO : ScriptableObject
{
    [TextArea(7,100)]
    [SerializeField] string documentDetails;
    [SerializeField] string date;
    [SerializeField] string companyName;
    [SerializeField] string address;
    [Multiline]
    [SerializeField] string salutation;
    [SerializeField] string subject;
    [Multiline]
    [SerializeField] string end;
    [SerializeField] string header;

    public string Details { get { return documentDetails; } private set { } }
    public string Header { get { return header; } private set { } }
    public string Date { get { return date; } private set { } }
    public string Company { get { return companyName; } private set { } }
    public string Address { get { return address; } private set { } }
    public string Salutation { get { return salutation; } private set { } }
    public string Subject { get { return subject; } private set { } }
    public string End { get { return end; } private set { } }
}
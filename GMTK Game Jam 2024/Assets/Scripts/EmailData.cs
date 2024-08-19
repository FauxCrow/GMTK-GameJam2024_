using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Email Data")]
public class EmailData : ScriptableObject
{
    [SerializeField] string sender;
    [SerializeField] string context;
    [TextArea(7,100)]
    [SerializeField] string details;

    public string Sender {get {return sender;} private set{}}
    public string Context {get {return context;} private set{}}
    public string Details {get {return details;} private set{}}
}

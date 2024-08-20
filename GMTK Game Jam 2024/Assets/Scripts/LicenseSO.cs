using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Licence")]
public class LicenseSO : ScriptableObject
{
    [SerializeField] string productName;
    [SerializeField] string companyName;
    [SerializeField] string productionCost;
    [SerializeField] int profit;
    [TextArea(7,100)]
    [SerializeField] string termsConditions;
    [SerializeField] int morality;
    [SerializeField] int reputation;
    
    public string Product { get { return productName; } private set { } }
    public string Details { get { return companyName; } private set { } }
    public string Cost { get { return productionCost; } private set { } }
    public int Profit { get { return profit; } private set { } }
    public string Conditions { get { return termsConditions; } private set { } }
    public int Morality { get { return morality; } private set { } }
    public int Reputation { get { return reputation; } private set { } }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// stores game variables across scenes
public class DataManager : MonoBehaviour
{
    // stores all variables
    public float Money { get; set; }
    public float Morality { get; set; }
    public float Reputation { get; set; }
    public int Licenses { get; set; }
    public GameObject SignaturePrefab;
    public Sprite SignatureSprite;

    // store UI sliders
    public SliderBar moneyBar;
    public SliderBar moralityBar;
    public SliderBar reputationBar;

    void Awake()
    {
        Reset();
    }

    // function: sets all variables to starting number
    void Reset(){
        Money = 0;
        Morality = 100;
        Reputation = 100;
        Licenses = 0;
    }

    // function: increase morality when pill is popped (we love drugs)
    // balancing -- currently, minus 1 morality earned every 10 licenses approved, at 500 licenses pills do nothing
    void RestoreMorality(){
        int offset = (Licenses/10);
        Morality += 50 - offset;

        moralityBar.startUpdate();
    }

    // function: increase reputation when pill is popped (we love drugs)
    void DeclineLawsuit(int reputationChange){
        Reputation += reputationChange;

        reputationBar.startUpdate();
    }

    // function: set values when license is accepted
    // +/- should be included when function is called
    void AcceptLicense(int moneyChange, int moralityChange, int reputationChange){
        Money += moneyChange;
        Morality += moralityChange;
        Reputation += reputationChange;

        // Guard Clause: ensure maximum / minimum on variables 
        // (not sure if necessary in the long run but yknow optimise later woo)
        if (Money < 0) { 
            Money = 0; 
        }
        if (Morality > 100){ 
            Morality = 100; 
        }
        else if (Morality < 0){ 
            Morality = 0; 
        }
        if (Reputation > 100){ 
            Reputation = 100; 
        }
        else if (Reputation < 0){ 
            Reputation = 0; 
        }

        moneyBar.startUpdate();
        moralityBar.startUpdate();
        reputationBar.startUpdate();

        Licenses++;
    }

    // function: set values when license is declined
    // +/- should be included when function is called
    void DeclineLicense(int moralityChange, int reputationChange){
        Morality += moralityChange;
        Reputation += reputationChange;

        // Guard Clause: ensure maximum / minimum on variables 
        // (not sure if necessary in the long run but yknow optimise later woo)
        if (Morality > 100){ 
            Morality = 100; 
        }
        else if (Morality < 0){ 
            Morality = 0; 
        }
        if (Reputation > 100){ 
            Reputation = 100; 
        }
        else if (Reputation < 0){ 
            Reputation = 0; 
        }

        moralityBar.startUpdate();
        reputationBar.startUpdate();

        Licenses++;
    }

    public void SpawnSignature(){
        GameObject signature = Instantiate(SignaturePrefab);
        signature.GetComponent<SpriteRenderer>().sprite = SignatureSprite;
        // set transform to license page but not rn cause i'm LAZY and SICK and TIRED and EEPY
    }
}

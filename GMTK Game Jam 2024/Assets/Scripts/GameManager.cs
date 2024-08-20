using System;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] PillManager pillManager;
    [SerializeField] TimeManager timeManager;

    [Header("License")]
    [SerializeField] LicenseReader licenseReader;
    [SerializeField] Licence licenseApp;
    
    [Header("Black Screen")]
    [SerializeField] CanvasGroup fadeScreen;
    [SerializeField] float fadeDuration;

    [Header("Others")]
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject tutorialScreen;
    [SerializeField] GameObject startMenuScreen;
    [SerializeField] OfficerMonitor monitor;
    [SerializeField] GameObject rightArm;
    [SerializeField] Signature signature;

    public bool GameInPlay {get; set;}

    void Start()
    {
        GameInPlay = false;
        monitor.gameObject.SetActive(false);
        timeManager.StopTimer();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && GameInPlay)
        {
             Pause();              
        }
    }

    public void Play(){
        ChangeScene(() => {
            timeManager.ResetAll();
            startMenuScreen.SetActive(false);
            tutorialScreen.SetActive(true);   
            monitor.Reset();
        });
    }

    public void Pause(){
        timeManager.StopTimer();
        pauseScreen.SetActive(true);
        SetMonitorState(false);

        GameInPlay = false;

        fadeScreen.DOFade(.5f, fadeDuration/4);
    }

    public void BackToMenu(){
        GameInPlay = false;
        pauseScreen.SetActive(false);
        ChangeScene(() => {
            startMenuScreen.SetActive(true);
            tutorialScreen.SetActive(false); 
        });
    }

    public void Continue(){
        SetMonitorState(true);
        pauseScreen.SetActive(false);
        timeManager.StartTimer();

        GameInPlay = true;

        fadeScreen.DOFade(0f, fadeDuration/4);
    }

    public void GameStart(){
        timeManager.StartTimer();
        timeManager.ResetTime();

        monitor.gameObject.SetActive(true);
        pillManager.ClearPills();
        pillManager.SpawnPill();
        rightArm.SetActive(true);

        licenseReader.NewLicenses(timeManager.currentDay);
        licenseApp.NotificationAlert();

        GameInPlay = true;
    }

    public void StartNewDay(){
        ChangeScene(() => {
            GameInPlay = true;
            timeManager.ResetTime();
            timeManager.StartTimer();
            licenseReader.NewLicenses(timeManager.currentDay);
            licenseApp.NotificationAlert();
        });
    }

    void ChangeScene(Action action){
        Sequence blackoutSequence = DOTween.Sequence();
        blackoutSequence.Append(fadeScreen.DOFade(1, fadeDuration).OnComplete(() => action()));
        blackoutSequence.Append(fadeScreen.DOFade(0, fadeDuration));
    }

    void SetMonitorState(bool state){
        monitor.GetComponent<Collider2D>().enabled = state;
    }
}
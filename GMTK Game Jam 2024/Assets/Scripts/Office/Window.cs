using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public DataManager dataManager;
    public Sprite[] windowSprites;      // list in decreasing morality :D
    private SpriteRenderer spriteRenderer;
    private int currentState;
    private int newState;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState = 0;

        WindowUpdate();
    }

    // function: call when player opens computer -- checks morality for window sprite
    public void WindowUpdate(){

        switch(dataManager.Morality){
            case > 90:
                newState = 0;
                break;
            case > 70:
                newState = 1;
                break;
            case > 50:
                newState = 2;
                break;
            case > 25:
                newState = 3;
                break;
            case > 0:
                newState = 4;
                break;
        }

        // only changes window sprite if number change is detected
        if (newState != currentState) {
            spriteRenderer.sprite = windowSprites[newState];
            currentState = newState;
        }
    }
}

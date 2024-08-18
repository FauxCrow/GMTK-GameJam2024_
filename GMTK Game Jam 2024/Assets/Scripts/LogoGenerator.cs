using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoGenerator : MonoBehaviour
{
    [SerializeField] Sprite[] whiteLogos = null;
    [SerializeField] Sprite[] blackLogos = null;
    [SerializeField] SpriteRenderer finalSpriteRenderer = null;
    
    List<Sprite> logosToUse = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Merge();
        }
    }
    void Merge()
    {
        Resources.UnloadUnusedAssets();

        logosToUse.Clear();

        for (int i = 0; i < 2; i++)
        {
            logosToUse.Add(whiteLogos[Random.Range(0, whiteLogos.Length - 1)]);
        }
        for (int i = 0; i < 2; i++)
        {
            logosToUse.Add(blackLogos[Random.Range(0, blackLogos.Length - 1)]);
        }

        var newText = new Texture2D(500, 500);

        for (int x = 0; x < newText.width; x++)
        {
            for (int y = 0; y < newText.height; y++)
            {
                newText.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        for (int i = 0; i < logosToUse.Count; i++)
        {
            for(int x = 0; x < logosToUse[i].texture.width; x++)
            {
                for(int y = 0; y < logosToUse[i].texture.height; y++)
                {
                    var color = logosToUse[i].texture.GetPixel(x, y).a == 0 ?
                        newText.GetPixel(x,y) :
                        logosToUse[i].texture.GetPixel(x,y);
                    newText.SetPixel(x, y, color);
                }
            }
        }

        newText.Apply();
        var finalSprite = Sprite.Create(newText, new Rect(0, 0, newText.width, newText.height),
            new Vector2(.5f,.5f));
        finalSprite.name = "New Sprite";
        finalSpriteRenderer.sprite = finalSprite;
    }
}
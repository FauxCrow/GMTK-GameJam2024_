using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class BreakingNews : App
{
    Vector2 outPosition = new (556f, -32.2f);
    Vector2 inPosition = new (29.5f, -32.2f);
    RectTransform rt;


    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public override void OpenApp()
    {
        rt.DOAnchorPos(inPosition, animationDuration);
    }

    public override void CloseApp()
    {
        rt.DOAnchorPos(outPosition, animationDuration);
    }
}
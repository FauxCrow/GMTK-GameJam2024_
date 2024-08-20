using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PillBottle : MonoBehaviour
{
    public GameObject arm;
    public float animationDuration;
    Vector3 armOriginalPosition;

    void Start(){
        armOriginalPosition = arm.transform.position;
    }

    void OnMouseDown()
    {
        Debug.Log("Pill Bottle clicked on");
        GetComponentInParent<PillManager>().TakePill();
    }

    public void DropAnim(){
        StartCoroutine(EnableCollider());

        Sequence bottleMove = DOTween.Sequence();
        bottleMove.Insert(animationDuration/2, transform.DOMove(new Vector2(transform.position.x, transform.position.y - 1f), animationDuration / 2));
    }

    public void ArmMove()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        Sequence armSequence = DOTween.Sequence();
        armSequence.Append(arm.transform.DOMove(transform.position, animationDuration / 2));
        armSequence.Append(arm.transform.DOMove(armOriginalPosition, animationDuration / 2));
        armSequence.Insert(animationDuration / 2, transform.DOMove(armOriginalPosition, animationDuration / 2));

        // don't know if we should kill the game object after the anim?
        // Destroy(this.gameObject);
    }

    IEnumerator EnableCollider(){
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
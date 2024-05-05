using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SawController : MonoBehaviour
{
    [SerializeField] Transform endPoint;

    void Start()
    {
        transform.DOMove(endPoint.position, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the saw.");
            this.GetComponentInParent<Animator>().enabled = false;
            //animator.SetBool("StopAnimation", true);
            DOTween.Kill(transform);
            EventManager.OnGameOver();
        }
    }

}

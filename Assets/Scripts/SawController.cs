using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SawController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform endPoint;
    public UnityEvent onHitEvent;

    void Start()
    {
        transform.DOMove(endPoint.position, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        CharacterController characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        if (characterController != null)
        {
            onHitEvent.AddListener(characterController.GameStop);
        }else
        {
            Debug.LogError("CharacterController not found.");
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the saw.");
            this.GetComponentInParent<Animator>().enabled = false;
            //animator.SetBool("StopAnimation", true);
            DOTween.Kill(transform);
            onHitEvent.Invoke();
        }
    }

}

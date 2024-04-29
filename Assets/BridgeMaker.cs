using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BridgeMaker : MonoBehaviour
{
    [SerializeField] private Transform bridge;
    [SerializeField] private float delatBetweenActivation = 0.2f;

    public UnityEvent makeBridgeEvent;
    public UnityEvent decreaseScoreByOne;

    void Start()
    {
        makeBridgeEvent.AddListener(MakeBridge);
        decreaseScoreByOne.AddListener(gameObject.gameObject.GetComponent<GameController>().DecreaseScore);
        decreaseScoreByOne.AddListener(gameObject.gameObject.GetComponent<UIController>().UpdateScore);
        //Debug.Log(bridge.childCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            makeBridgeEvent.Invoke();
        }
    }

    public void MakeBridge()
    {
        StartCoroutine(ActivateBridge());
    }
    IEnumerator ActivateBridge()
    {

        for (int i = 0; i < bridge.childCount; i++)
        {
            bridge.GetChild(i).gameObject.SetActive(true);
            decreaseScoreByOne.Invoke();
            yield return new WaitForSeconds(delatBetweenActivation);
        }

        //foreach (Transform child in bridge)
        //{
        //    child.gameObject.SetActive(true);
        //    yield return new WaitForSeconds(delatBetweenActivation);
        //}
    }
}

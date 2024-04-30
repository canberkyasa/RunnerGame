using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BridgeMaker : MonoBehaviour
{
    [SerializeField] private Transform bridge;
    [SerializeField] private float delatBetweenActivation = 0.2f;

    public UnityEvent decreaseScoreByOne;

    void Start()
    {
        

        // Eðer GameController veya UIController bileþenleri bu nesnede eksikse, null hatasý alabiliriz.
        // FindGmeObjectWithTag hýzlý, FindObjectOfType ise daha yavaþ çalýþýr.
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (gameController != null)
            decreaseScoreByOne.AddListener(gameController.DecreaseScore);
        else
            Debug.LogError("GameController component not found on " + gameController.name);

        UIController uiController = GameObject.FindObjectOfType<UIController>();
        if (uiController != null)
            decreaseScoreByOne.AddListener(uiController.UpdateScore);
        else
            Debug.LogError("UIController component not found on " + uiController.name);
        
        //Debug.Log(bridge.childCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MakeBridge();
        }
    }

    public void MakeBridge()
    {
        StartCoroutine(ActivateBridge());
    }
    IEnumerator ActivateBridge()
    {
        if (bridge == null)
        {
            Debug.LogError("Bridge reference not set in BridgeMaker script.");
            yield break;
        }

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

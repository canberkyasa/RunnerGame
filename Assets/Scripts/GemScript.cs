using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if(!other.gameObject.CompareTag("Player")) return;
        
        EventManager.OnIncrementScore(1);
        EventManager.OnGemColllected();
        Destroy(gameObject);
    }
}

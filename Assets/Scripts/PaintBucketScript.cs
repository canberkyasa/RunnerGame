using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucketScript : MonoBehaviour
{
    [SerializeField] private GameController.Color paintBucketColor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        EventManager.OnSetColor(paintBucketColor);
        Destroy(gameObject);
    }
}

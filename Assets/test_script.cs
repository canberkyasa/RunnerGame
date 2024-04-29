using System.Collections;
using UnityEngine;

public class test_script : MonoBehaviour
{
    public float delayBetweenDisable = 0.5f;

    void Start()
    {
        StartCoroutine(DisableChildObjects());
    }

    IEnumerator DisableChildObjects()
    {
        // Parent objenin altýndaki tüm child objeleri al
        foreach (Transform child in transform)
        {
            // Child objeyi devre dýþý býrak
            child.gameObject.SetActive(false);
            // Belirli bir süre bekleyerek diðer child objelere geç
            yield return new WaitForSeconds(delayBetweenDisable);
        }
    }
}

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
        // Parent objenin alt�ndaki t�m child objeleri al
        foreach (Transform child in transform)
        {
            // Child objeyi devre d��� b�rak
            child.gameObject.SetActive(false);
            // Belirli bir s�re bekleyerek di�er child objelere ge�
            yield return new WaitForSeconds(delayBetweenDisable);
        }
    }
}

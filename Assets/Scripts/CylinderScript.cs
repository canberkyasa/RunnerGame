using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CylinderScript : MonoBehaviour
{
    public UnityEvent cylinderHitEvent;
    // Start is called before the first frame update
    void Start()
    {

        cylinderHitEvent.AddListener(FindObjectOfType<UIController>().GameOver);
        CharacterController characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        if (characterController != null)
        {
            cylinderHitEvent.AddListener(characterController.GameStop);
        }
        else
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
            this.GetComponent<Animator>().enabled = false;
            cylinderHitEvent.Invoke();
            
        }
    }
}

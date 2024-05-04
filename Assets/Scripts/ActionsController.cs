using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //start cutting
        if (other.gameObject.tag == "Cuttable")
        {
            Debug.Log("Cutting");
            //cutting logic
            //destroy the object
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Gem")
        {
            Debug.Log("Gem Collected");
            //destroy the object
            Destroy(other.gameObject);
        }
        return;
    }
}

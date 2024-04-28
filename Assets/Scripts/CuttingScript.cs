using UnityEngine;
using UnityEngine.Events;
public class CuttingScript : MonoBehaviour
{
    public UnityEvent cutEvent;


    private void Start()
    {
        
        cutEvent.AddListener(GameObject.FindObjectOfType<GameController>().IncrementScore);
        cutEvent.AddListener(GameObject.FindObjectOfType<UIController>().UpdateScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        //start cutting
        if (other.gameObject.tag == "Cuttable")
        {
            cutEvent.Invoke();
            Debug.Log("Cutting");
            //cutting logic
            //destroy the object
            Destroy(other.gameObject);
        }
    }

}

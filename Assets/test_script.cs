using System.Collections;
using UnityEngine;

public class test_script : MonoBehaviour
{
    private GameController.Color color;

    private void Start()
    {
        color = GameController.Color.Blue;
    }

    private void Update()
    {
        Debug.Log(color);
    }
}

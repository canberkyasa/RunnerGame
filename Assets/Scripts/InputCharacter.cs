using UnityEngine;

public class InputCharacter : MonoBehaviour
{

    private float horizantalValue;
    public float HorizantalValue
    {
        get { return horizantalValue; }
    }

    private void Update()
    {
        HandleHorizantalInput();
    }

    private void HandleHorizantalInput()
    {
        if(Input.GetMouseButton(0))
        {
            horizantalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizantalValue = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private InputCharacter inputCharacter;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float horizantalSpeed = 2.0f;
    [SerializeField] private float horizantalLimitValue;
    private bool isGameStarted = true;   

    private float newPositionX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isGameStarted)
        {
            WalkForward();
            MoveHorizantal();
        }
        
    }

    private void WalkForward()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    private void MoveHorizantal()
    {
        newPositionX = transform.position.x + inputCharacter.HorizantalValue * horizantalSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizantalLimitValue, horizantalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    public void GameStop()
    {
        isGameStarted = false;
    }
}

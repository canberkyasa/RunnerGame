using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private InputCharacter inputCharacter;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float horizantalSpeed = 2.0f;
    [SerializeField] private float horizantalLimitValue;
    private bool isGameStarted = true;   

    private float newPositionX;

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

    private void StopGame() // CHANGE THIS TO PRIVATE
    {
        isGameStarted = false;
    }

    private void OnEnable()
    {
        EventManager.GameOver += StopGame;
    }
    private void OnDisable()
    {
        EventManager.GameOver -= StopGame;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //camera should follow the player

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame  
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }

    //private void FixedUpdate()
    //{
    //    Vector3 desiredPosition = player.position + offset;
    //    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    //    transform.position = smoothedPosition;

    //}
}

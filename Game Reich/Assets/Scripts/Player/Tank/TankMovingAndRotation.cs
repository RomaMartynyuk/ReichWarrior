using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovingAndRotation : MonoBehaviour
{
    [Header("TankSettings")]
    [SerializeField] public float rotationSpeed = 3.5f;
    [SerializeField] public float accelerationSpeed = 30.0f;

    //Local variables
    float accelerationInput = 0;
    float steeringInput = -90f;
    float rotationAngle = 0;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        EngineForce();
        Steering();
    }
    void EngineForce()
    {
        Vector2 engineForceVector = transform.right * accelerationInput * accelerationSpeed;

        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }
    void Steering()
    {
        rotationAngle -= steeringInput * rotationSpeed;

        rb.MoveRotation(rotationAngle);
    }
    public void SetInputVector(Vector2 InputVector)
    {
        steeringInput = InputVector.x;
        accelerationInput = InputVector.y;
    }
}

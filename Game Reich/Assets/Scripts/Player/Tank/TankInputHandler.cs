using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInputHandler : MonoBehaviour
{
    TankMovingAndRotation tmar;
    // Start is called before the first frame update
    void Start()
    {
        tmar = GetComponent<TankMovingAndRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        tmar.SetInputVector(inputVector);
    }
}

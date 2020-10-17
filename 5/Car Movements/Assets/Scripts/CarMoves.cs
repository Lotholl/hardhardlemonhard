using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoves : MonoBehaviour
{
    public float speedValue = 0f;
    //private float speedValue = 0f;

    public float maxFrontSpeed = 15f;
    public float maxRearSpeed = 7f;
    public float accelerationValue = 1f;
    //public float inertialBrakingValue = 0.1f;
    //public float brakingValue = 0.5f;
    private float inertialBrakingValue = 0f;
    private float brakingValue = 0f;

    public float rotationSpeed = 45f;


    // Направление движения
    private int direction = -1;
    private const int rearDirection = -1;
    private const int frontDirection = 1;
    // Направление вращения
    private int rotation = -1;
    private const int leftRotation = -1;
    private const int rightRotation = 1;
    // Start is called before the first frame update
    void Start()
    {
        inertialBrakingValue = accelerationValue * 0.5f;
        brakingValue = accelerationValue * 4f;
    }

    // Update is called once per frame
    void Update()
    {
        // Движение вперёд
        if (Input.GetKey(KeyCode.W))
        {
            if ((speedValue == 0) && (direction == rearDirection))
            {
                direction *= -1;
            }
            if (direction == frontDirection)
            {
                if (speedValue < maxFrontSpeed)
                {
                    speedValue += accelerationValue;
                }
                Move(direction);
            }
        }

        // Движение назад
        if (Input.GetKey(KeyCode.S))
        {
            if ((speedValue == 0) && (direction == frontDirection))
            {
                direction *= -1;
            }
            if (direction == rearDirection)
            {
                if (speedValue < maxRearSpeed)
                {
                    speedValue += accelerationValue;
                }
                Move(direction);
            }

        }
        // Движение по инерции
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && (speedValue > 0))
        {
            speedValue -= inertialBrakingValue;
            Move(direction);
            //MyLerp();
        }



        /////////// Ready ////////////

        // Поворот налево
        if (Input.GetKey(KeyCode.A))
        {
            if (rotation == rightRotation)
            {
                rotation *= -1;
            }
            Rotate(rotation);
        }

        // Поворот направо
        if (Input.GetKey(KeyCode.D))
        {
            if (rotation == leftRotation)
            {
                rotation *= -1;
            }
            Rotate(rotation);
        }
    }

    private void Move(int direction)
    {
        transform.Translate(Vector3.forward * direction * Time.deltaTime * speedValue);
    }

    private void Rotate(int rotation)
    {
        transform.Rotate(Vector3.up * rotation * Time.deltaTime * rotationSpeed);
    }
    //private void MyLerp()
    //{
    //    transform.position = Vector3.Lerp(transform.position, Vector3.forward, Time.deltaTime * speedValue);
    //}
}

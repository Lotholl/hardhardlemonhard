using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoves : MonoBehaviour
{
    public float speedValue = 0f;   // Текущая скорость
    public float maxFrontSpeed = 10f; // Максимальная скорость при движении вперёд
    public float maxRearSpeed = 4f; // Максимальная скорость при движении назад
    public float accelerationValue = 0.25f; // Постоянное ускорение
    private float inertialBrakingValue = 0f; // Велечина замедления по инерции
    private float brakingValue = 0f; // Величина замедления при нажатии на "тормоз"
    public float rotationSpeed = 60f; // Скорость вращения объекта


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
        brakingValue = accelerationValue * 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        // Движение вперёд
        if (Input.GetKey(KeyCode.W) && (speedValue == 0) && (direction == rearDirection)) // Смена направления движения
        {
            direction *= -1;
        }
        if (Input.GetKey(KeyCode.W) && (direction == frontDirection))  // Если мы уже движемся назад, не сможем двигаться вперёд
        {
            if (speedValue < maxFrontSpeed)  // Ускорение до максимальной скорости
            {
                speedValue += accelerationValue;
            }
            Move(direction);  // Движение объекта
        }

        // Движение назад
        if (Input.GetKey(KeyCode.S) && (speedValue == 0) && (direction == frontDirection)) // Смена направления движения
        {
            direction *= -1;
        }
        if (Input.GetKey(KeyCode.S) && (direction == rearDirection))  // Если мы уже движемся назад, не сможем двигаться вперёд
        {
            if (speedValue < maxRearSpeed)   // Ускорение до максимальной скорости
            {
                speedValue += accelerationValue;
            }
            Move(direction);
        }

        // Движение по инерции и торможение
        if (speedValue > 0)
        {
            if (Input.GetKey(KeyCode.S) && (direction == frontDirection)) // Если нажали на "тормоз", то торможение будет быстрее, чем по инерции
            {
                speedValue -= brakingValue;  // Замедление с "тормозом"
            }
            else
            {
                speedValue -= inertialBrakingValue;  // Замедление по инерции
            }
            Move(direction);
        }

        /////////// Ready ////////////

        // Поворот налево
        if (Input.GetKey(KeyCode.A))
        {
            if (rotation == rightRotation)  // Смена направления поворота
            {
                rotation *= -1;
            }
            Rotate(rotation);   // Поворот объекта
        }

        // Поворот направо
        if (Input.GetKey(KeyCode.D))
        {
            if (rotation == leftRotation)   // Смена направления поворота
            {
                rotation *= -1;
            }
            Rotate(rotation);   // Поворот объекта
        }
    }

    private void Move(int direction)  // Функция движения объекта
    {
        transform.Translate(Vector3.forward * direction * Time.deltaTime * speedValue);
    }

    private void Rotate(int rotation)  // Функция поворота объекта вокруг своей оси
    {
        transform.Rotate(Vector3.up * rotation * Time.deltaTime * rotationSpeed);
    }
}

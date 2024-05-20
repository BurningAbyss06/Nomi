using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravite_Swap : MonoBehaviour
{
    private enum GravityDirection
    {
        Left,
        Right,
        Up,
        Down
    }
    private GravityDirection currentDirection = GravityDirection.Down;
    private bool isRotating = false;
    public float rotationSpeed = 200f; 
    private Quaternion targetRotation;


    void Start()
    {
    }

    void Update()
    {

         if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeGravity(GravityDirection.Down);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeGravity(GravityDirection.Up);
        }
        
    }

     void ChangeGravity(GravityDirection direction)
    {
        if (currentDirection != direction)
        {
            currentDirection = direction;
            Vector2 newGravity = Vector2.zero;

            switch (direction)
            {
                case GravityDirection.Left:
                    newGravity = new Vector2(-9.81f, 0f);
                    targetRotation = Quaternion.Euler(0, 0, 90);
                    break;
                case GravityDirection.Right:
                    newGravity = new Vector2(9.81f, 0f);
                    targetRotation = Quaternion.Euler(0, 0, -90);
                    break;
                case GravityDirection.Up:
                    newGravity = new Vector2(0f, 9.81f);
                    targetRotation = Quaternion.Euler(0, 0, 180);
                    break;
                case GravityDirection.Down:
                    newGravity = new Vector2(0f, -9.81f);
                    targetRotation = Quaternion.Euler(0, 0, 0);
                    break;
            }
            Physics2D.gravity = newGravity;
            if (!isRotating)
            {
                StartCoroutine(RotateCharacter());
            }
        }
    }

    IEnumerator RotateCharacter()
    {
        isRotating = true;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
            

        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}

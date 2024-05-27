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
    public bool isReverse { get; private set; }
    private bool isRotating = false;
    public float rotationSpeed = 200f; 
    private Quaternion targetRotation;
    private bool isCooldown = false;
    public float cooldownTime = 5f; // Cooldown time in seconds


    void Start()
    {
        isReverse = false;
    }

    void Update()
    {
        if (!isCooldown)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                isReverse = false;
                ChangeGravity(GravityDirection.Down);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                isReverse = true;
                ChangeGravity(GravityDirection.Up);
            }
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
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator RotateCharacter()
    {
        // Indica que la rotaci�n est� en curso
        isRotating = true;

        // Mientras la diferencia angular entre la rotaci�n actual y la rotaci�n objetivo sea mayor que un peque�o umbral
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            // Rota gradualmente el objeto hacia la rotaci�n objetivo
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Espera hasta el siguiente frame antes de continuar la ejecuci�n
            yield return null;
        }

        // Asegura que la rotaci�n finalice exactamente en la rotaci�n objetivo
        transform.rotation = targetRotation;

        // Invertir la escala en el eje X para el flip horizontal
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Invertir el eje X
        transform.localScale = newScale;

        // Indica que la rotaci�n ha terminado
        isRotating = false;
    }
    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}

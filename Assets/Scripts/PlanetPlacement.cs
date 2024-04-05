using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPlacement : MonoBehaviour
{
    // Definición de las posiciones como Vector3
    public Vector3 leftPosition = new Vector3(0f, 0f, 0f);
    public Vector3 centerPosition = new Vector3(0f, 0f, 0f);
    public Vector3 rightPosition = new Vector3(0f, 0f, 0f);

    private Vector3[] positions; // Arreglo de posiciones a las que el objeto puede moverse
    private int currentPositionIndex = 1; // Índice de la posición actual
    public float speed = 5f; // Velocidad de movimiento
    private bool isMoving = false; // Bandera para evitar múltiples movimientos simultáneos

    void Start()
    {
        // Inicializar el arreglo de posiciones con los vectores definidos
        positions = new Vector3[] { leftPosition, centerPosition, rightPosition };

        // Posicionar el objeto inicialmente en la posición central
        transform.position = centerPosition;
    }

    void Update()
    {
        // Verifica si se presiona la tecla A o la flecha izquierda
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        // Verifica si se presiona la tecla D o la flecha derecha
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        // Si el índice actual es mayor que cero y no está en la posición más a la izquierda, mueve el objeto a la posición anterior
        if (currentPositionIndex > 0 && currentPositionIndex != 0 && !isMoving)
        {
            currentPositionIndex--;
            // Inicia la interpolación hacia la posición objetivo
            StartCoroutine(MoveToPosition(positions[currentPositionIndex]));
        }
    }

    void MoveRight()
    {
        // Si el índice actual es menor que la longitud del arreglo - 1 y no está en la posición más a la derecha, mueve el objeto a la siguiente posición
        if (currentPositionIndex < positions.Length - 1 && currentPositionIndex != positions.Length - 1 && !isMoving)
        {
            currentPositionIndex++;
            // Inicia la interpolación hacia la posición objetivo
            StartCoroutine(MoveToPosition(positions[currentPositionIndex]));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true; // Indica que el objeto está en movimiento

        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            // Interpola entre la posición actual y la posición objetivo
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;
        }

        transform.position = targetPosition; // Asegura que el objeto llegue exactamente a la posición objetivo
        isMoving = false; // Indica que el movimiento ha terminado
    }
}
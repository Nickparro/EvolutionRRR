using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPlacement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private bool isMoving = false; // Bandera para evitar múltiples movimientos simultáneos

    public void MoveToPosition(Vector3 targetPosition, Vector3 targetScale)
    {
        if (!isMoving)
        {
            // Iniciar la interpolación hacia la posición objetivo y la modificación de escala
            StartCoroutine(MoveToPositionCoroutine(targetPosition, targetScale));
        }
    }

    IEnumerator MoveToPositionCoroutine(Vector3 targetPosition, Vector3 targetScale)
    {
        isMoving = true; // Indica que el objeto está en movimiento

        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            // Interpola entre la posición actual y la posición objetivo
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

            // Interpola entre la escala actual y la escala objetivo
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);

            yield return null;
        }

        transform.position = targetPosition; // Asegura que el objeto llegue exactamente a la posición objetivo
        transform.localScale = targetScale; // Asegura que el objeto tenga la escala objetivo
        isMoving = false; // Indica que el movimiento ha terminado
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetPlacement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private bool isMoving = false; // Bool para evitar múltiples movimientos simultáneos

    public AudioSource leftPositionSound;
    public AudioSource centerPositionSound;
    public AudioSource rightPositionSound;

    void OnMouseDown()
    {
        Vector3 currentScale = transform.localScale;

        if (currentScale == new Vector3(74.59f, 74.59f, 74.59f)) 
        {
            rightPositionSound.Play();
        }
        else if (currentScale == new Vector3(128.3f, 128.3f, 128.3f)) 
        {
            centerPositionSound.Play();
            //SceneManager.LoadNextScene();
        }
        else if (currentScale == new Vector3(186.15f, 186.15f, 186.15f)) 
        {
            leftPositionSound.Play();
        }
    }


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

            yield return true;
        }

        transform.position = targetPosition; // Asegura que el objeto llegue exactamente a la posición objetivo
        transform.localScale = targetScale; // Asegura que el objeto tenga la escala objetivo
        isMoving = false; // Indica que el movimiento ha terminado
    }
}
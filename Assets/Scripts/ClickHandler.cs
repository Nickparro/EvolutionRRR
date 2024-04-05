using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public PlanetPlacement clickMovement; // Referencia al script ClickMovement adjunto al objeto que se moverá
    public Vector3 targetPosition; // La posición a la que se moverá el objeto al hacer clic en este GameObject
    public Vector3 targetScale; // La escala que se aplicará al objeto al hacer clic en este GameObject

    void OnMouseDown()
    {
        if (clickMovement != null)
        {
            clickMovement.MoveToPosition(targetPosition, targetScale);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Transform planetCenter;
    public float gravityStrength = 9.8f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravityDirection = (transform.position - planetCenter.position).normalized;
        rb.AddForce(-gravityDirection * gravityStrength);

        // Alinear al animal con la superficie del planeta
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, -gravityDirection) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 50 * Time.deltaTime);

        // Alinear al animal con la superficie del planeta.
        // Esta rotación asegura que los 'pies' estén siempre orientados hacia la superficie.
        AlignToSurface(gravityDirection);
    }

     void AlignToSurface(Vector3 gravityDirection)
    {
        // Orientación deseada: arriba del animal opuesto a la dirección de la gravedad.
        Quaternion targetOrientation = Quaternion.FromToRotation(transform.up, gravityDirection) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientation, 50 * Time.deltaTime);
    }
}

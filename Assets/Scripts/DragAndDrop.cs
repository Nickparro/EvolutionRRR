using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    private GameObject draggedObject;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        if (Input.GetMouseButtonDown(0))
        {
            if (draggedObject == null)
            {
                RaycastHit hit = CastRay();
                if (hit.collider != null && hit.collider.CompareTag("drag"))
                {
                    draggedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && draggedObject != null)
        {
            draggedObject = null;
            Cursor.visible = true;
        }

        if (draggedObject != null)
        {
            UpdateDraggedObjectPosition();
        }
    }

    private void UpdateDraggedObjectPosition()
    {
        float minX = 0;
        float maxX = Screen.width;
        float minY = 0;
        float maxY = Screen.height;

        float clampedX = Mathf.Clamp(Input.mousePosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(Input.mousePosition.y, minY, maxY);
        float distanceToCamera = Camera.main.WorldToScreenPoint(draggedObject.transform.position).z;

        Vector3 screenPosition = new Vector3(clampedX, clampedY, distanceToCamera);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        draggedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private EarthController earthController;

    private void Awake()
    {
        if (earthController == null && gameObject.GetComponent<EarthController>())
        {
            earthController = GetComponent<EarthController>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        earthController.EarthPressed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        earthController.EarthReleased();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}

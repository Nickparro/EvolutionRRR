using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStates : MonoBehaviour
{
    private Renderer rendererObject;
    private Color targetColor;
    public float transitionSpeed;
    public Color dryColor, fireColor, iceColor;
    public bool isHot;
    public bool isCold;
    public bool isPerfect;
   
    void Start()
    {
        rendererObject = GetComponent<Renderer>();
        isPerfect = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeatherState(targetColor);
    }

    public void ChangeWeatherState(Color colorToChange)
    {
        Vector3 currentScale = transform.localScale;
        
        if(currentScale == new Vector3(74.59f, 74.59f, 74.59f))
        {
            isCold = false;
            isPerfect = false;
            targetColor = fireColor;
        } else if (currentScale == new Vector3(186.15f, 186.15f, 186.15f))
        {
            isHot = false;
            isPerfect = false;
            targetColor = iceColor;
        } else 
        {
            isPerfect = true;
            isHot = false;
            isCold = false;
            targetColor = dryColor;
        }
        
        // Asegúrate de que rendererObject no sea null
        if (rendererObject != null)
    {
        // Itera sobre todos los materiales y cambia su color.
        for (int i = 0; i < rendererObject.materials.Length; i++)
        {
            rendererObject.materials[i].color = Color.Lerp(rendererObject.materials[i].color, targetColor, transitionSpeed * Time.deltaTime);
        }
    }
    }

    
    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("Ice"))
    //     {
    //         isCold = true;
    //         isPerfect = false;
    //         isHot = false;
    //     } else if (other.gameObject.CompareTag("Perfect"))
    //     {
    //         isPerfect = true;
    //         isHot = false;
    //         isCold = false;
    //     } else if (other.gameObject.CompareTag("Fire"))
    //     {
    //         isHot = true;
    //         isPerfect = false;
    //         isCold = false;
    //     }
    // }

    
}

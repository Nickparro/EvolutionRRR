using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhases : MonoBehaviour
{
    private Renderer rendererObject;
    public float transitionSpeed;
    public Color waterColor,greenColor,iceColor;
    public Animator planetAnimator;
    public GameObject rainyCloud, phase1, phase2, phase3;

    void Start()
    {
        rendererObject = GetComponent<Renderer>();
    }
    public void WaterPlanet()
    {
        planetAnimator.SetTrigger("Water_in");
        rainyCloud.SetActive(true);
        Destroy(rainyCloud, 2);
        
        StartCoroutine(WaterAddedCoroutine());
        
        
    }

    public void WetPlanet()
    {
        StartCoroutine(WaterOutCoroutine());
        
    }

    public void GreenPlanet()
    {
        StartCoroutine(GreenAddedCoroutine());
    }

    public void DinasoursBorn()
    {
        StartCoroutine(LizardAddedCoroutine());
    }    

    private IEnumerator WaterOutCoroutine()
    {
        // Espera por la cantidad de segundos especificada.
        yield return new WaitForSeconds(3);

        // Ejecuta las acciones después del retraso.
        planetAnimator.SetTrigger("Water_out");
    }

    private IEnumerator WaterAddedCoroutine()
{
      yield return new WaitForSeconds(2);  // Espera antes de comenzar la transición.

    float time = 0;
    Color originalColor0 = rendererObject.materials[0].color;
    Color originalColor2 = rendererObject.materials[2].color;

    Material[] materials = rendererObject.materials;

    while (time < 1)
    {
        time += Time.deltaTime * transitionSpeed;
        materials[0].color = Color.Lerp(originalColor0, waterColor, time);
        materials[2].color = Color.Lerp(originalColor2, iceColor, time);

        rendererObject.materials = materials;
        yield return null;
    }

    // Asegurarse de que los colores finales se establecen correctamente
    materials[0].color = waterColor;
    materials[2].color = iceColor;
    rendererObject.materials = materials;

    phase1.SetActive(true);
}

private IEnumerator GreenAddedCoroutine()
{
    float time = 0;
    Color originalColor1 = rendererObject.materials[1].color;
    Material[] materials = rendererObject.materials;

    while (time < 1)
    {
        time += Time.deltaTime * transitionSpeed;
        materials[1].color = Color.Lerp(originalColor1, greenColor, time);
        rendererObject.materials = materials;
        yield return null;
    }

    // Asegurarse de que los colores finales se establecen correctamente
    materials[1].color = greenColor;
    rendererObject.materials = materials;

    yield return new WaitForSeconds(2);  // Espera antes de comenzar la transición.
    phase2.SetActive(true);
}

private IEnumerator LizardAddedCoroutine()
{
    yield return new WaitForSeconds(3);  // Espera antes de comenzar la transición.
    phase3.SetActive(true);
}

}

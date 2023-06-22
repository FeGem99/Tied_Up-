using UnityEngine;
using UnityEngine.UI;

public class icon_colors : MonoBehaviour
{
    public float colorChangeDuration = 1f; // Durata del cambio di colore
    public Color color1 = Color.red; // Primo colore
    public Color color2 = Color.blue; // Secondo colore

    private Graphic buttonGraphic;
    private bool isColor1 = true;
    private float timer = 0f;

    private void Start()
    {
        buttonGraphic = GetComponent<Graphic>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= colorChangeDuration)
        {
            isColor1 = !isColor1;
            timer = 0f;
        }

        if (isColor1)
        {
            buttonGraphic.color = Color.Lerp(buttonGraphic.color, color1, timer / colorChangeDuration);
        }
        else
        {
            buttonGraphic.color = Color.Lerp(buttonGraphic.color, color2, timer / colorChangeDuration);
        }
    }
}

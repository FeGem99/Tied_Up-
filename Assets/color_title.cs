using UnityEngine;
using UnityEngine.UI;

public class color_title : MonoBehaviour
{
     public float colorChangeDuration = 1f; // Durata del cambio di colore
    public Color[] colors; // Array di colori da alternare
    //public float colorChangeDuration = 1f; // Durata del cambio di colore
    public Color color1 = Color.red; // Primo colore
    public Color color2 = Color.blue; // Secondo colore

    private Text titleText;
    private bool isColor1 = true;
    private float timer = 0f;

    private void Start()
    {
        titleText = GetComponent<Text>();
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
            titleText.color = Color.Lerp(titleText.color, color1, timer / colorChangeDuration);
        }
        else
        {
            titleText.color = Color.Lerp(titleText.color, color2, timer / colorChangeDuration);
        }
    }
}

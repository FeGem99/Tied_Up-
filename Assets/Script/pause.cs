using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject pausaPanel;
    public Text punteggioText;
    public Button pausaButton;
    private bool isPaused = false;
    private int defaultPunteggio = 100000;
    private int punteggio;

    private void Start()
    {
        punteggio = defaultPunteggio;
        punteggioText.text = "Punteggio: " + punteggio;

        pausaButton.onClick.AddListener(TogglePausa);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausa();
        }
    }

    public void TogglePausa()
    {
        if (isPaused)
        {
            RiprendiGioco();
        }
        else
        {
            MettiInPausa();
        }
    }

    public void MettiInPausa()
    {
        isPaused = true;
        pausaPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RiprendiGioco()
    {
        isPaused = false;
        pausaPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGioco()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TornaAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
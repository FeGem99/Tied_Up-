using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("itinerario");
    }
}

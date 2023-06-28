using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_loader : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("itinerario");
    }
}

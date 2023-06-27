using UnityEngine;
using UnityEngine.SceneManagement;

public class back_to_menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("menu");
    }
}

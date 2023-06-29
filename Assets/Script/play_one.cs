using UnityEngine;
using UnityEngine.SceneManagement;

public class play_one : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("livello_1");
    }
}

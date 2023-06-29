using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_livello : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("livello_1");
    }
}

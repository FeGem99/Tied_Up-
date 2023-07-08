using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("livello_1");
    }
}

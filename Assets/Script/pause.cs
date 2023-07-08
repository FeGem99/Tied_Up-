using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("pause");
    }
}

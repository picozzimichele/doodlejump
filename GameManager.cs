using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void EndGame ()
    {
        SceneManager.LoadScene("Menu");
    }
}

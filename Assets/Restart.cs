using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameManager gameManager;
    public void RestartGame()
    {
        gameManager.LoadLevel("SampleScene");
    }
}

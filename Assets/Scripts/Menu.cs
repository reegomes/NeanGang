using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scene01"))
        {
            SceneManager.LoadScene(3);
        }
        if (other.CompareTag("Scene02"))
        {
            SceneManager.LoadScene(2);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTeleporter : MonoBehaviour
{
    [SerializeField] private string targetSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

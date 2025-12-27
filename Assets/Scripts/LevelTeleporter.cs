using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTeleporter : MonoBehaviour
{
    [SerializeField] string targetSceneName; // Gidilecek sahnenin adý



    public static bool cameFromTransition = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
           
            SceneManager.LoadScene(targetSceneName);
        }
    } 
  
}


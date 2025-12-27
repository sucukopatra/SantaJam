using UnityEngine;

public class Calendar : MonoBehaviour
{
    [SerializeField] GameObject calendarContent;
    bool canBeOpened = false;

    private void Update()
    {
        if (canBeOpened && Input.GetKeyDown(KeyCode.E))
        {
            calendarContent.SetActive(true);
        }

    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
         if (other.CompareTag("player"))
         {
             canBeOpened = true;
         }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canBeOpened = false;
            calendarContent.SetActive(false);
        }
    }
}

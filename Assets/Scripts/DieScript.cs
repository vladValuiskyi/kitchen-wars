using UnityEngine;

public class DieScript : MonoBehaviour
{
    public GameObject respawn;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}

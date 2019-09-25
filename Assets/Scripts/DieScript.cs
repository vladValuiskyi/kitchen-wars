using UnityEngine;
public class DieScript : MonoBehaviour
{
    public PlayerController player;
    public GameObject respawn;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.DieScript();
        }
    }
}

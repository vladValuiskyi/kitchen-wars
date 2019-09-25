using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CameraMove : MonoBehaviour
{
    public PlayerController player;
    public Button restartButton;

    void Update()
    {
        if (player.isAlive)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        }
        else
        {
            if (CrossPlatformInputManager.GetButtonDown("Restart"))
            {
                restartButton.gameObject.SetActive(false);
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}

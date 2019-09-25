using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActive;
    public Trap connectedTrap;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isActive)
        {
            changeState();
            connectedTrap.Activate();
        }
    }

    public void changeState()
    {
        isActive = !isActive;
        Vector3 lTemp = transform.localScale;
        lTemp.x *= -1;
        transform.localScale = lTemp;
    }
}

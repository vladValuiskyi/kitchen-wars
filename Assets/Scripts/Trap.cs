using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trap;
    public Lever connectedLever;
    public bool isActive;

    public void Activate()
    {
        isActive = true;
        Debug.Log(trap.name.ToString());
        trap.GetComponent<Animator>().Play("TrapAnimation");
    }

    public void Deactivate()
    {
        isActive = false;
        connectedLever.changeState();
        trap.GetComponent<Animator>().Play("DoNothing");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isActive)
        {
            GameObject enteredObject = other.gameObject;

            EnemyController enemy = enteredObject.GetComponent(typeof(EnemyController)) as EnemyController;

            enemy.Die();
        }
    }
}

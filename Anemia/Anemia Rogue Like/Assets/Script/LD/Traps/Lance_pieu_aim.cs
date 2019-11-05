using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance_pieu_aim : Lance_pieu
{
    public Transform player;
    public float lookSpeed;
    private void LookAtTarget()
    {
        // get a rotation that points Z axis forward, and the Y axis towards the target
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (player.position - transform.position));

        // rotate toward the target rotation, never rotating farther than "lookSpeed" in one frame.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookSpeed);
    }
    private void Update()
    {
        Shoot();
        LookAtTarget();
    }
}

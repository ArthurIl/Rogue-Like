using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleModifier : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon sickle;

    public GameHandler attack;

    private void Start()
    {
        attack = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        attack.attackDammage = sickle.attackDammage;
        attack.attackRangeX = sickle.attackRangeX;
        attack.attackRangeY = sickle.attackRangeY;
        attack.timeBtwAttack = sickle.timeBtwAttack;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableBehavior : MonoBehaviour
{
    private GameHandler playerHandler;
    public Disposable myDisposable;
    void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (myDisposable.healthRefill > 0)
            {
                playerHandler.TakeDamage(0 - myDisposable.healthRefill);
                Debug.Log("Health refilled of: " + myDisposable.healthRefill);
            }
            else if (myDisposable.dammageBoost > 0)
            {
                Debug.Log("Attack damage : " + playerHandler.attackDammage + ",");
                playerHandler.attackDammage = myDisposable.HitMore(playerHandler.attackDammage);
                Debug.Log("Has become : " + playerHandler.attackDammage);

            }
            else if (myDisposable.soulsAdd > 0)
            {
                Debug.Log("Souls count : " + playerHandler.soulsCount + ",");
                playerHandler.soulsCount = myDisposable.GiveSouls(playerHandler.soulsCount);
                Debug.Log("Has become : " + playerHandler.soulsCount);

            }

            Destroy(gameObject);
        }
    }
}

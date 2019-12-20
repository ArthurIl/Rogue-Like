using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableBehavior : MonoBehaviour
{
    private GameHandler playerHandler;
    public Disposable myDisposable;
    public GameObject GameManager;
    public GameManager GM;
    void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<GameHandler>();
        GameManager = GameObject.Find("GameManager");
        GM = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("UseItem"))
        {
            if (myDisposable.healthRefill > 0)
            {
                playerHandler.TakeDamage(0 - myDisposable.healthRefill);
            }
            else if (myDisposable.dammageBoost > 0)
            {
                playerHandler.attackDammage = myDisposable.HitMore(playerHandler.attackDammage);

            }
            else if (myDisposable.soulsAdd > 0)
            {
                GM.soulsCount = myDisposable.GiveSouls(GM.soulsCount);

            }

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoinWhenDie : DeadAction
{
    public override void Perform()
    {
        FindObjectOfType<CheckPointManager>().MoveToCheckPoint(this.transform);
        Player player = gameObject.GetComponent<Player>();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        if (player != null) {
            player.hp = 1;
        }
    }
}

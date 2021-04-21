using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipWhenDead : DeadAction
{
    public override void Perform() {
        EndGame("You are already dead!", "You are so Noob eiei.");
    }

    private void EndGame(string title, string description) {
        EndScreen config = new EndScreen();

        config.title = title;
        config.description = description;
        config.isVictory = false;

        FindObjectOfType<GameManager>().ShowEndScreen(config);
    }
}

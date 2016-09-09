using System;
using UnityEngine;

public class ManagerGame : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    private enum Turnstate {
        BATTLE_START,
        TURN_PLAYER,
        TURN_ENEMY,
        RESULT
    }

    private Turnstate state;

    private event EventHandler state_BATTLE_START;

    private event EventHandler state_TURN_PLAYER;

    private event EventHandler state_TURN_ENEMY;

    private event EventHandler state_RESULT;

    void Start() {
    }

    void Update() {
        switch (state) {
            case Turnstate.BATTLE_START:
                break;
            case Turnstate.TURN_PLAYER:
                break;
            case Turnstate.TURN_ENEMY:
                break;
            case Turnstate.RESULT:
                break;
        }
    }

    void Battle_Start() {
        state = Turnstate.BATTLE_START;
    }

    void Turn_Player() {
        state = Turnstate.TURN_PLAYER;
    }

    void Turn_Enemy() {
        state = Turnstate.TURN_ENEMY;
    }

    void Result() {
        state = Turnstate.RESULT;
    }
}
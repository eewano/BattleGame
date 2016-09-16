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

    private TextTurn textTurn;
    private TextWinLose textWinLose;

    private bool battleWin;

    private event EventHandler state_BATTLE_START;

    private event EventHandler state_TURN_PLAYER;

    private event EventHandler state_TURN_ENEMY;

    private event EventHandler state_RESULT_WIN;

    private event EventHandler state_RESULT_LOSE;

    void Awake() {
        textTurn = GameObject.Find("TextTurn").GetComponent<TextTurn>();
        textWinLose = GameObject.Find("TextWinLose").GetComponent<TextWinLose>();
    }

    void Start() {
        state_BATTLE_START += new EventHandler(textTurn.Text_BATTLE_START);
        state_TURN_PLAYER += new EventHandler(textTurn.Text_TURN_PLAYER);
        state_TURN_ENEMY += new EventHandler(textTurn.Text_TURN_ENEMY);
        state_RESULT_WIN += new EventHandler(textWinLose.Text_WIN);
        state_RESULT_LOSE += new EventHandler(textWinLose.Text_LOSE);

        Battle_Start();
    }

    void Update() {
        switch (state) {
            case Turnstate.BATTLE_START:
                break;
            case Turnstate.TURN_PLAYER:
                if (Input.GetMouseButtonUp(0)) {
                    battleWin = true;
                    Result();
                }

                if (Input.GetMouseButtonUp(1)) {
                    battleWin = false;
                    Result();
                }
                break;
            case Turnstate.TURN_ENEMY:
                break;
            case Turnstate.RESULT:
                break;
        }
    }

    void Battle_Start() {
        state = Turnstate.BATTLE_START;
        this.state_BATTLE_START(this, EventArgs.Empty);
        Invoke("Turn_Player", 2.0f);
    }

    void Turn_Player() {
        state = Turnstate.TURN_PLAYER;
        this.state_TURN_PLAYER(this, EventArgs.Empty);
    }

    void Turn_Enemy() {
        state = Turnstate.TURN_ENEMY;
        this.state_TURN_ENEMY(this, EventArgs.Empty);
    }

    void Result() {
        state = Turnstate.RESULT;
        if (battleWin == true)
        {
            this.state_RESULT_WIN(this, EventArgs.Empty);
        }

        if (battleWin == false)
        {
            this.state_RESULT_LOSE(this, EventArgs.Empty);
        }
    }
}
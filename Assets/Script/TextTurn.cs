using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTurn : MonoBehaviour {

    [SerializeField]
    private Text textTurn;

    void Start() {
        textTurn.text = "";
    }

    public void Text_BATTLE_START(object o, EventArgs e) {
        textTurn.text = "BATTLE START";
    }

    public void Text_TURN_PLAYER(object o, EventArgs e) {
        textTurn.text = "TURN PLAYER";
        StartCoroutine("TextHide", 2.0f);
    }

    public void Text_TURN_ENEMY(object o, EventArgs e) {
        textTurn.text = "TURN ENEMY";
        StartCoroutine("TextHide");
    }

    IEnumerator TextHide() {
        yield return new WaitForSeconds(2.0f);
        textTurn.text = "";
    }
}
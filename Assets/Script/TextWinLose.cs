using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextWinLose : MonoBehaviour {

    [SerializeField]
    private Text textWinLose;

    void Start() {
        textWinLose.text = "";
    }

    public void Text_WIN(object o, EventArgs e) {
        textWinLose.text = "あなたの\n勝ち";
        StartCoroutine("TextHide", 2.0f);
    }

    public void Text_LOSE(object o, EventArgs e) {
        textWinLose.text = "あなたの\n負け";
        StartCoroutine("TextHide", 2.0f);
    }

    IEnumerator TextHide() {
        yield return new WaitForSeconds(2.0f);
        textWinLose.text = "";
    }
}
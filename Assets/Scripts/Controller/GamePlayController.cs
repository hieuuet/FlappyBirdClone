using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {
    [SerializeField]
    private Button instructionButton;
    void Awake () {
        Time.timeScale = 0; //dong bang hoan toan tien trinh
    }
    public void _InstructionButton (){
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }
}

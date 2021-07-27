using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject gameOverText;
    private GameObject runLengthText;
    //走行距離
    private float len = 0;
    //走行速度
    private float speed = 5f;
    //ゲームオーバーの判定
    private bool isGameOver = false; 
    // Start is called before the first frame update
    void Start()
    {
        //sceneビューから実体を取得し代入
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーじゃない時
        if(this.isGameOver == false){
            //走行距離を更新する。距離 = 時間 × 速さ　
            this.len += this.speed * Time.deltaTime;
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
        }
    }
    //ゲームオーバーになった時UnitychanControlleに呼び出される
    public void GameOver(){
        //ゲームオーバーテキストにゲームオーバーと表示
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        //ゲームオーバー判定を下す
        this.isGameOver = true;
    }
}

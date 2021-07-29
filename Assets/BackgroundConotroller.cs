using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundConotroller : MonoBehaviour
{
    //スクロール速度(キューブより少し遅めに設定)
    private float scrollSpeed = -1;
    //背景終了位置
    private float deadLine = -16;
    //背景開始位置(背景の流れを自然に見せるためあえてきしょい数にしている)
    private float startLine = 15.8f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //経過時間によって背景を移動させる
        transform.Translate(this.scrollSpeed * Time.deltaTime, 0 , 0);
        //画面外に出たら画面右端に移動する
        if(transform.position.x < this.deadLine){
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}

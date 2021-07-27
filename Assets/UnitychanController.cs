using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{

    //アニメーションコンポーネントを入れる箱(スクリプトからUnityちゃんに走る動きをつけるため)
    Animator animator;
    //オブジェクトの移動に必要なRigidbody2D
    Rigidbody2D rigid2d;
    //地面の位置
    private float groundLevel = -3.0f;
    //ジャンプの速度(=高さ)
    float jumpVelocity = 20;

    private float dump = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        //アニメーターコンポーネントを取得
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dコンポーネントを取得
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //右方向に進むアニメーションを実現するためにHorizontalに1を代入
        this.animator.SetFloat("Horizontal",1);
        //三項演算子を使ってUnityちゃんが着地していない時はfalse、着地している時はtrueを返す
        bool isGround = (transform.position.y > this.groundLevel)? false : true;
        //isGroundパラメータに結果を代入。着地している時は右方向に走るアニメーション
        this.animator.SetBool("isGround", isGround);

        //Unityちゃんが着地した状態でクリックボタンが押された時
        if(Input.GetMouseButtonDown(0) && isGround){
            //Rigidbody2Dの速度を司るvelocityでUnityちゃんに上向きの力を加える
            this.rigid2d.velocity = new Vector2(0, this.jumpVelocity);
        }
        //クリックボタンが離された時
        if(Input.GetMouseButtonDown(0) == false){
            if(this.rigid2d.velocity.y > 0){
                //上方向への速度を減衰する
                this.rigid2d.velocity *= this.dump;
            }
        }
    }
}

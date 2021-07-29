using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12; 
    //消滅位置
    private float deadLine = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を利用してキューブを徐々に左に移動させる
        this.transform.Translate (this.speed * Time.deltaTime, 0, 0);
        //画面外に出たら
        if(this.transform.position.x < this.deadLine){
            //破棄する
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
	    Debug.Log("OnTriggerEnterが呼ばれた");
	    if(other.gameObject.tag == "groundTag" || other.gameObject.tag == "cubeTag"){
		    GetComponent<AudioSource>().Play();
	    }
	    if(other.gameObject.tag == "UnitychanTag"){
	        Debug.Log("Unityちゃんと衝突した");
	    }
    }
}

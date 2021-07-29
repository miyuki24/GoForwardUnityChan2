using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //CubeのPrefab
    public GameObject cubePrefab;
    //時間計測用の変数
    private float delta = 0;
    //キューブの生成間隔
    private float span = 1.0f;
    //キューブの生成位置(X座標)
    private float genPosX = 12;
    //キューブの生成位置オフセット
    private float offsetY = 0.3f;
    //キューブの縦の大きさ。バランスよく落ちてくる数を指定
    private float spaceY = 6.9f;
    //キューブの生成位置オフセット
    private float offSetX = 0.5f;
    //キューブの横方向の間隔
    private float spaceX = 0.4f;
    //キューブの生成個数の上限
    private int maxBlockNum = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間が代入されていく
        this.delta += Time.deltaTime;
        //span以上の時間が経過した時→一定時間ごとに動作を繰り返すようになる
        if(this.delta > this.span){
            //deltaを初期化
            this.delta = 0;
            //生成するキューブの数は1~4の中からランダム個
            int n = Random.Range(1, maxBlockNum + 1);
            //↑の数だけキューブを生成
            for(int i = 0; i < n; i ++){
                //キューブの生成(scene上に存在しないprefab変数から実体を生成)
                GameObject go = Instantiate(cubePrefab);
                //キューブのposition。x座標は12で固定、y軸にオフセットを足すのはUnityちゃんのy座標と同じ奥行きにするため。数が大きくなるにつれ高いところから落ちてくる→トントントン
                go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
            }
            this.span = this.offSetX + this.spaceX * n;
        }
    }
}

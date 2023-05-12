using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public float speed = 0.01f;//speed
    public Text scoreText;// score UI
    public Text winText; //リザルト UI

    [SerializeField] private Rigidbody rb;
    private int score;//score

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbodyの取得

        score =0;
        SetCountText();
        winText.text="";
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルキーの入力の取得
        var moveHorizontal=Input.GetAxis("Horizontal");
        var moveVertical=Input.GetAxis("Vertical");

        //カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal,0,moveVertical);

        //Rigidbodyに力を与えて球を動かす
        rb.AddForce(movement * speed);
        
        if(transform.position.y<-10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    //玉がほかのオブジェクトにぶつかったときに呼び出される
    void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //その収集アイテムを非表示にする
            other.gameObject.SetActive(false);

            score=score+1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreText.text="Count:"+score.ToString();
        if(score>=12)
        {
            winText.text="You Win!";
        }
    }
}

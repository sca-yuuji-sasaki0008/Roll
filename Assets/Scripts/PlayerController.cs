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
    public Text winText; //���U���g UI

    [SerializeField] private Rigidbody rb;
    private int score;//score

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�̎擾

        score =0;
        SetCountText();
        winText.text="";
    }

    // Update is called once per frame
    void Update()
    {
        //�J�[�\���L�[�̓��͂̎擾
        var moveHorizontal=Input.GetAxis("Horizontal");
        var moveVertical=Input.GetAxis("Vertical");

        //�J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
        var movement = new Vector3(moveHorizontal,0,moveVertical);

        //Rigidbody�ɗ͂�^���ċ��𓮂���
        rb.AddForce(movement * speed);
        
        if(transform.position.y<-10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    //�ʂ��ق��̃I�u�W�F�N�g�ɂԂ������Ƃ��ɌĂяo�����
    void OnTriggerEnter(Collider other)
    {
        //�Ԃ������I�u�W�F�N�g�����W�A�C�e���������ꍇ
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //���̎��W�A�C�e�����\���ɂ���
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

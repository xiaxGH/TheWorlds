using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Image ph;
    public Sprite hp1;
    public Sprite hp2;
    public Sprite hp3;
    public Sprite hp4;
    public Sprite hp5;


    // Start is called before the first frame update
    void Start()
    {
        player = transform.Find("user").GetComponent<Player>();
        Transform aa = transform.Find("Canvars");
        ph = aa.transform.Find("PlayerHelth").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("�÷��̾� HP : " + player.hp);
        if(player.hp == 5){
            //Sprite newSprite = Resources.Load<Sprite>(hp5); // ���ҽ����� ��������Ʈ �ε�
            if (ph.sprite != null)
            {
                 ph.sprite = hp5;
            }
        }
        else if(player.hp == 4){
            //Sprite newSprite = Resources.Load<Sprite>(hp4); // ���ҽ����� ��������Ʈ �ε�
            if (ph.sprite != null)
            {
                 ph.sprite = hp4;
            }
        }
        else if(player.hp == 3){
            //Sprite newSprite = Resources.Load<Sprite>(hp3); // ���ҽ����� ��������Ʈ �ε�
            if (ph.sprite != null)
            {
                 ph.sprite = hp3;
            }
        }
        else if(player.hp == 2){
            //Sprite newSprite = Resources.Load<Sprite>(hp2); // ���ҽ����� ��������Ʈ �ε�
            if (ph.sprite != null)
            {
                 ph.sprite = hp2;
            }
        }
        else if(player.hp == 1){
            //Sprite newSprite = Resources.Load<Sprite>(hp1); // ���ҽ����� ��������Ʈ �ε�
            if (ph.sprite != null)
            {
                 ph.sprite = hp1;
            }
        
    }

    
        
        
    }
}

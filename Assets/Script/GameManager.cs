using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Image ph;
    public Sprite sp;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.Find("user").GetComponent<Player>();
        ph = transform.Find("PlayerHelth").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hp == 5)
        {
            sp = Resources.Load<Sprite>("HP_UI_5");
            ph.sprite = sp;
            Debug.Log("HP°¡ " + player.hp + "³²À½");

        }
    }
}

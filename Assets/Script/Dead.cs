using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject PlayerObject;
    private float playerY_lastPosition;
    public float pos = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerY_lastPosition =  PlayerObject.transform.position.y;

        if(PlayerObject.activeSelf){
            Vector2 PP = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y + pos);
            transform.position = PP;
        }
        else{
            Vector2 newPosition = transform.position;
            newPosition.y = playerY_lastPosition;
            transform.position = newPosition;    
            }
        
    }
}

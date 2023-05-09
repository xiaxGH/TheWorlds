using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public Transform userTransform;
    public Transform MineTransform;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    transform= MineTransform.position;
    //    transform2= userTransform.position;
    //}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "user")
        {
            userTransform.position = MineTransform.position;
        }
    }
    //void Awake()
    //{
    //    userTransform.position = MineTransform.position;
    //}
}

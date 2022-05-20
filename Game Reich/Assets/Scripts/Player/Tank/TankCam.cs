using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCam : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private string playerTag;
    [SerializeField] private float speed;

    private void Awake()
    {
        if(this.playerPos == null)
        {
            if(this.playerTag == "")
            {
                this.playerTag = "Player";
            }
            this.playerPos = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }
        this.transform.position = new Vector3()
        {
            z = this.playerPos.position.z - 10,
            x = this.playerPos.position.x,
            y = this.playerPos.position.y,
        };
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (this.playerPos)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerPos.position.x,
                y = this.playerPos.position.y,
                z = this.playerPos.position.z - 10,
            };
            Vector3 pos = Vector3.Lerp(this.transform.position, target, speed);

            this.transform.position = pos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip deadsound;

    private void Awake()
    {
        if(this.playerTransform == null)
        {
            if(this.playerTag == "")
            {
                this.playerTag = "Player";
            }
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }
        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10,
        };
    }
    private void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10,
            };
            Vector3 pos = Vector3.Lerp( this.transform.position, target, cameraSpeed );
            
            this.transform.position = pos;
        }
        if (!player)
        {
            StartCoroutine(DieSong());
        }
    }
    IEnumerator DieSong()
    {
        GetComponent<AudioSource>().PlayOneShot(deadsound);

        yield return new WaitForSeconds(5);

        Destroy(deadsound);
    }
}

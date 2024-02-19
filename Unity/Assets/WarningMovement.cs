using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMovement : MonoBehaviour
{
    public GameObject WarningBlock;
    public Shaker Shaker;
    public float durationToSet = 0.3f;
    Transform target;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        Shaker.Shake(durationToSet);

        target = GetComponent<Transform>();
        initPos = target.localPosition;
        
        var slideLeft = new Vector3(-225f, initPos.y, initPos.z);
        target.localPosition = slideLeft;

        WarningBlock.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMovement : MonoBehaviour
{
    public GameObject WarningBlock;
    public Shaker Shaker;
    public float durationToSet = 0.3f;
    Transform target;
    Transform target2;
    Vector3 initPos;
    Vector3 initPos2;
    // Start is called before the first frame update
    void Start()
    {
        Shaker.Shake(durationToSet);

        target = GetComponent<Transform>();
        initPos = target.localPosition;
        
        var slideLeft = new Vector3(-225f, initPos.y, initPos.z);
        target.localPosition = slideLeft;

        WarningBlock.SetActive(true);
        target2 = WarningBlock.GetComponent<Transform>();
        initPos2 = target2.localPosition;
        var slideRight = new Vector3(225f, initPos2.y, initPos2.y);
        target2.localPosition = slideRight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

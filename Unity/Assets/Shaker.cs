using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    Vector3 initPos;
    Transform target;
    public float duration = 1f;
    //float shakeDuration = 0.0
    bool isShaking = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        initPos = target.localPosition;
    }

    //public void Shake(float duration) 
    //{
      //  if (duration > 0) {

      //  }
    //} 

    // Update is called once per frame
    void Update()
    {
        if (duration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + duration)
        {
            var randomPoint = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), initPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        duration = 0f;
        target.localPosition = initPos;
        isShaking = false;       
    }
}

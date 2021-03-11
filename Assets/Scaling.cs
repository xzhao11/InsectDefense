using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    public float scaleSize = 0.2f;
    public bool isFinished;
    int tweenId;
    float scalex;
    float scaley;
    float scalez;
    void Start()
    {
        scalex = transform.localScale.x;
        scaley = transform.localScale.y;
        scalez = transform.localScale.z;
        isFinished = false;
        tweenId = LeanTween.scale(gameObject, new Vector3(scalex + scaleSize, scaley + scaleSize, scalez + scaleSize), 1f).setEase(LeanTweenType.easeInOutCirc).setLoopPingPong().id;
    }

    public void OnClose()
    {
        isFinished = true;
        if (tweenId != 0)
        {
            LeanTween.cancel(tweenId);
        }
        //transform.localScale = new Vector3(scalex, scaley, scalez);
    }
}

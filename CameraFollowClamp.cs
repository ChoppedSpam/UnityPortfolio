using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowClamp : MonoBehaviour
{

    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;


    public bool YMaxEnabled = false;
    public float YMaxValue = 0;
    public bool YMinEnabled = false;
    public float YMinValue = 0;
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;
    public bool XMinEnabled = true;
    public float XMinValue = -63.42f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        targetPos.z = transform.position.z;

        //Vertical

        if (YMinEnabled && YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);
        }
        else if (YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
        }
        else if (YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);
        }

        //Horizontal

        if (XMinEnabled && XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        }
        else if (XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }


}

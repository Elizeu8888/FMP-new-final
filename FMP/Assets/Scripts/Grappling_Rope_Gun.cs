using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling_Rope_Gun : MonoBehaviour
{
    private Spring spring;
    public LineRenderer lr;
    private Vector3 currentGrapplePosition;
    public GrappleV2 grapplingGun;
    public int quality;
    public float damper;
    public float strength;
    public float velocity;
    public float waveCount;
    public float waveHeight;
    public AnimationCurve affectCurve;
    public GameObject pos;

    void Awake()
    {
        spring = new Spring();
        spring.SetTarget(0);
    }

    //Called after Update
    void Update()
    {
       
        //transform.position = pos.transform.position;
        //transform.rotation = pos.transform.rotation;
    }


    void FixedUpdate()
    {
        DrawRope();
    }


    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!grapplingGun.IsGrappling())
        {
            currentGrapplePosition = grapplingGun.grappleTip.transform.position;
            spring.Reset();
            if (lr.positionCount > 0)
                lr.positionCount = 0;
            return;
        }

        if (lr.positionCount == 0)
        {
            spring.SetVelocity(velocity);
            lr.positionCount = quality + 1;
        }

        spring.SetDamper(damper);
        spring.SetStrength(strength);
        spring.Update(Time.deltaTime);

        var grapplePoint = grapplingGun.GetGrapplePoint();
        var gunTipPosition = grapplingGun.grappleTip.transform.position;
        var up = Quaternion.LookRotation((grapplePoint - gunTipPosition).normalized) * Vector3.up;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 12f);

        for (var i = 0; i < quality + 1; i++)
        {
            var delta = i / (float)quality;
            var right = Quaternion.LookRotation((grapplePoint - gunTipPosition).normalized) * Vector3.right;

            var offset = up * waveHeight * Mathf.Sin(delta * waveCount * Mathf.PI) * spring.Value *
                                     affectCurve.Evaluate(delta) +
                                     right * waveHeight * Mathf.Cos(delta * waveCount * Mathf.PI) * spring.Value *
                                     affectCurve.Evaluate(delta);

            lr.SetPosition(i, Vector3.Lerp(gunTipPosition, currentGrapplePosition, delta) + offset);
        }
    }
}



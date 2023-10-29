using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3 grapplePoint;
    public LayerMask grapple;
    public Transform grappleStart, cam, player;
    float maxDistance;
    SpringJoint joint;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            //StopGrapple();
        }

        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, grapple))
        {
             grapplePoint = hit.point;
             joint = player.gameObject.AddComponent<SpringJoint>();
             joint.autoConfigureConnectedAnchor = false;
             joint.connectedAnchor = grapplePoint;

             float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //Distance grapple will keep from point
             joint.maxDistance = distanceFromPoint * 0.8f;
             joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    private void StopGrapple()
    {
            
    }

    private void DrawRope()
    {
        lineRenderer.SetPosition(0, grappleStart.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }
}

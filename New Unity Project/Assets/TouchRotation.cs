using UnityEngine;
using System.Collections;

public class TouchRotation : MonoBehaviour
{

    GameObject targetItem;
    Camera GUICamera;
    GameObject ambient;


    /********Rotation Variables*********/
    float rotationRate = 1.0f;
    bool wasRotating;

    /************Scrolling inertia variables************/
    private Vector2 scrollPosition = Vector2.zero;
    private float scrollVelocity = 0;
    private float timeTouchPhaseEnded;
    private float inertiaDuration = 0.5f;

    private float itemInertiaDuration = 1.0f;
    private float itemTimeTouchPhaseEnded;
    private float rotateVelocityX = 0;
    private float rotateVelocityY = 0;


    RaycastHit hit;

    //private int layerMask = (1 << 8) | (1 << 2);
    //private var layerMask = (1 <<  0);

    void Start()
    {
        //layerMask = ~layerMask;
    }

    void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {        //    If there are touches...
            var theTouch = Input.GetTouch(0);        //    Cache Touch (0)

            var ray = Camera.main.ScreenPointToRay(theTouch.position);
            //Ray GUIRayq = GUICamera.ScreenPointToRay(theTouch.position);


           //if (Physics.Raycast(ray, out hit, 50f, layerMask))
           //{

                if (Input.touchCount == 1)
                {

                    if (theTouch.phase == TouchPhase.Began)
                    {
                        wasRotating = false;
                    }

                    if (theTouch.phase == TouchPhase.Moved)
                    {

                        gameObject.transform.Rotate(theTouch.deltaPosition.y * rotationRate, -theTouch.deltaPosition.x * rotationRate, 0, Space.World);
                        wasRotating = true;
                    }

                }
            //}
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    Rigidbody2D bladeRigidBody;
    TrailRenderer bladeTrailRender;
    Collider2D bladeCollider;
        
    void Awake(){
        bladeRigidBody = GetComponent<Rigidbody2D>();
        bladeTrailRender = GetComponent<TrailRenderer>();
        bladeCollider = GetComponent<CircleCollider2D>();
    }

    void Update(){
        SetBladeToMouse();
        if(Input.GetMouseButton(0)){
            bladeTrailRender.enabled = true; 
            bladeCollider.enabled = true; 
        }
        else{
            bladeTrailRender.enabled = false;
            bladeCollider.enabled = false; 
        }
    }

    void SetBladeToMouse(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        bladeRigidBody.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}

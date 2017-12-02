using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    Transform trans;

    [SerializeField]
    Rigidbody rb;


    [SerializeField]
    float targetPosThreshold = 0.05f;

    Vector3 targetPos;
	
    // Use this for initialization
	void Start () {
        targetPos = trans.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            targetPos = trans.position + trans.forward;
        }
	}

    private void FixedUpdate()
    {
        if (!nearTargetPos())
        {
            rb.MovePosition(trans.position + trans.forward * Time.fixedDeltaTime);
        }
        else
        {
            targetPos.y = trans.position.y;
            rb.MovePosition(targetPos);
        }
    }

    private bool nearTargetPos()
    {
        if(Mathf.Abs(trans.position.x - targetPos.x) < targetPosThreshold 
            && Mathf.Abs(trans.position.z - targetPos.z) < targetPosThreshold)
        {
            return true;
        }
        return false;
    }

}

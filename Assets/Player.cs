using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    Transform trans;

    [SerializeField]
    Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            
        }
	}

    private void FixedUpdate()
    {
        rb.MovePosition(trans.position + trans.forward * Time.deltaTime);
    }

}

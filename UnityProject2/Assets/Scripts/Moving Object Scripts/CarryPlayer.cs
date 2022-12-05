using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPlayer : MonoBehaviour
{
    private Rigidbody rb;
    	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
    CharacterController cc;
    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			cc = other.GetComponent<CharacterController>();
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
			cc.Move(rb.velocity * Time.deltaTime);
	}
}

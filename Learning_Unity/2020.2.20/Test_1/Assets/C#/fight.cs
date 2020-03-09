using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight : MonoBehaviour
{
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag=="Player"){
			other.gameObject.GetComponent<hp>().hpdecrease(100);
		}
	}
}

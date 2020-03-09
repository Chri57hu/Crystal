using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openthedoor : MonoBehaviour
{
	public GameObject door;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
		{
			bool state = door.GetComponent<Animator>().GetBool("open");
			state = !state;
			door.GetComponent<Animator>().SetBool("open", state);
		}
	}
}

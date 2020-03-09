using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour{
	private Collider2D coll;
	public void Death(){
		coll = GetComponent<Collider2D>();
		if (coll.tag == "Cherry"){
			FindObjectOfType<PlayerController>().CherryCount();
		}
		if (coll.tag == "Gem"){
			FindObjectOfType<PlayerController>().GemCount();
		}
		Destroy(gameObject);
	}
}

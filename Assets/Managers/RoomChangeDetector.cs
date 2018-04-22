using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == TagHandler.tagRoom) {
      Camera.main.transform.position = new Vector3(other.transform.position.x +0.5f, other.transform.position.y, Camera.main.transform.position.z);
    }
  }
}

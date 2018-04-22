using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
  private GameObject player;

	// Use this for initialization
	void Start () {
    this.player = GameObject.FindGameObjectWithTag(TagHandler.tagPlayer);
	}
	
	// Update is called once per frame
	void Update () {
    if (this.player) {
      //Camera.main.transform.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y, Camera.main.transform.position.z);
    }
	}
}

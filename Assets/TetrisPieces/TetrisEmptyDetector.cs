﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisEmptyDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  void OnTriggerStay2D(Collider2D other) {
    if (other.tag == TagHandler.tagBlock) {
      BarrierScript parentBarrier = this.GetComponentInParent<BarrierScript>();
      if (parentBarrier) {
        parentBarrier.CheckIfVanish();
        //other.gameObject.SetActive(false);
      }
    }
  }
}

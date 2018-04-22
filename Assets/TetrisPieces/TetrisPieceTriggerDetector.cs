using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPieceTriggerDetector : MonoBehaviour {
  [HideInInspector]
  public int collidersWithSomething = 0;
  [HideInInspector]
  public int collidersWithRoom = 0;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == TagHandler.tagRoom) {
      collidersWithRoom++;
    } else {
      collidersWithSomething++;
    }
  }
  void OnTriggerExit2D(Collider2D other) {
    if (other.tag == TagHandler.tagRoom) {
      collidersWithRoom--;
    } else {
      collidersWithSomething--;
    }
  }
}

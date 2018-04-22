using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == TagHandler.tagPlayer) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}

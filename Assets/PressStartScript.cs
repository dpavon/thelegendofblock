using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStartScript : MonoBehaviour {
  private float timeToStart = 1f;

	// Use this for initialization
	void Start () {
	}

  // Update is called once per frame
  void Update() {
    if (Input.anyKey && Time.timeSinceLevelLoad > timeToStart) {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % (SceneManager.sceneCount + 1));
    }
  }
}

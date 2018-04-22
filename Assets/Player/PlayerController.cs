using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public string horizontalAxisName = "Horizontal";
  public string verticalAxisName = "Vertical";
  public float movementSpeed = 4;
  private float deadRange = 0.9f;
  private string animationWalking = "walking";
  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    CheckMovementKeys();
    CheckSprite();

  }

  void CheckMovementKeys() {
    float vertical = Input.GetAxisRaw(this.verticalAxisName);
    float horizontal = Input.GetAxisRaw(this.horizontalAxisName);
    if (vertical <= deadRange && vertical >= (-1 * deadRange)) {
      vertical = 0f;
    } else {
      vertical = 1f * Mathf.Sign(vertical);
    }
    if (horizontal <= deadRange && horizontal >= (-1 * deadRange)) {
      horizontal = 0f;
    } else {
      horizontal = 1f * Mathf.Sign(horizontal);
    }

    if (horizontal == 0 && vertical == 0) {
      this.GetComponent<Animator>().SetBool(animationWalking, false);
    } else {
      this.GetComponent<Animator>().SetBool(animationWalking, true);
    }

    Vector2 movement = new Vector2(horizontal, vertical).normalized * movementSpeed;
    this.GetComponent<Rigidbody2D>().velocity = movement;
  }

  void CheckSprite() {
    float horizontal = Input.GetAxisRaw(this.horizontalAxisName);

    if (horizontal > 0) {
      this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x) * -1, this.transform.localScale.y, this.transform.localScale.z);
    } else if (horizontal < 0){
      this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
    }
  }
}

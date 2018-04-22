using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPieceToGrid : MonoBehaviour {
  private float gridScale = 1f;
  private Vector3 initialLocalPosition = Vector2.zero;
  private float offsetX = 0.5f;
  private float offsetY = 0.5f;


  // Use this for initialization
  void Start () {
    if (this.transform.parent) {
      this.initialLocalPosition = this.transform.localPosition;
    }
	}
	
	// Update is called once per frame
	void LateUpdate () {
    if (this.transform.parent) {
      SetToParentGrid();
    } else {
      SetToGrid();
    }
  }

  void SetToParentGrid() {

    Vector3 worldPos = this.transform.parent.position + this.initialLocalPosition;

    float xNextPosition = Mathf.Round((worldPos.x - offsetX) / gridScale) * gridScale;
    float yNextPosition = Mathf.Round((worldPos.y - offsetY) / gridScale) * gridScale;
    Vector3 desiredWorldPosition = new Vector3(xNextPosition + offsetX, yNextPosition + offsetY, worldPos.z);

    transform.localPosition = desiredWorldPosition - this.transform.parent.position;
  }
  void SetToGrid() {
    Vector3 currentPos = this.transform.localPosition;
    float xNextPosition = Mathf.Round((currentPos.x - offsetX) / gridScale) * gridScale;
    float yNextPosition = Mathf.Round((currentPos.y - offsetY) / gridScale) * gridScale;

    transform.position = new Vector3(xNextPosition + offsetX, yNextPosition + offsetY, currentPos.z);

  }
}

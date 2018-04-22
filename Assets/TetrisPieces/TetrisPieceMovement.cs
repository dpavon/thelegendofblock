using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPieceMovement : MonoBehaviour {
  private bool followMouse = false;

	// Use this for initialization
	void Start () {
    if (this.transform.parent) {
      this.enabled = false;
    }
	}
	
	// Update is called once per frame
	void Update () {
    if (followMouse == true) {
      Vector2 worldMouse = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
      this.transform.position = new Vector3(worldMouse.x, worldMouse.y, this.transform.position.z);
    }
	}

  public void SetFollowMouse(bool follow) {
    this.followMouse = follow;

    if (follow == true) {
      SetAllChildrenWithColor(new Color(1f,1f,1f,0.2f), TagHandler.tagSelectedBlock, LayerHandler.layerSelectedBlock);
      ChangeAllColliderStatuses(true);
    } else {
      SetAllChildrenWithColor(Color.white, TagHandler.tagBlock, LayerHandler.layerBlock);
      ChangeAllColliderStatuses(false);
    }
  }

  void SetAllChildrenWithColor(Color color, string newTag, string newLayer) {
    SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
    foreach (SpriteRenderer child in allChildren) {
      child.color = color;
      if (tag != "") {
        child.gameObject.tag = newTag;
      }
      if (newLayer != "") {
        child.gameObject.layer = LayerMask.NameToLayer(newLayer);
      }
    }
  }

  void ChangeAllColliderStatuses(bool isTrigger) {
    BoxCollider2D[] allChildren = GetComponentsInChildren<BoxCollider2D>();
    foreach (BoxCollider2D child in allChildren) {
      child.isTrigger = isTrigger;
    }
  }
}

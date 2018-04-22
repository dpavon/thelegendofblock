using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour {
  public AudioClip disappearSound;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void CheckIfVanish() {

    bool vanish = CalculateBarrierVanish();

    if (vanish) {
      Vanish();
    }
  }

  void Vanish() {
    if (disappearSound) {
      SoundManager.GetInstance().gameObject.GetComponent<AudioSource>().PlayOneShot(disappearSound);
    }
    this.gameObject.SetActive(false);
  }

  bool CalculateBarrierVanish() {
    bool blocksFound = true;
    List<GameObject> list = new List<GameObject>();
    TetrisEmptyDetector[] allChildren = this.GetComponentsInChildren<TetrisEmptyDetector>();
    foreach (TetrisEmptyDetector child in allChildren) {
      Vector3 checkPos = child.transform.position;
      Vector2 checkPos2D = new Vector2(checkPos.x, checkPos.y);

      RaycastHit2D hitRoom = Physics2D.Raycast(checkPos2D, Vector2.zero, 30f, 1 << LayerMask.NameToLayer(LayerHandler.layerBlock));
      blocksFound = blocksFound && (hitRoom.collider != null);
      if (hitRoom.collider != null) {
        list.Add(hitRoom.collider.gameObject);
      }
    }

    if (list.Count > 0 && blocksFound == true) {
      for (int i = 0; i < list.Count; ++i) {
        list[i].SetActive(false);
      }
    }
    return blocksFound;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public float rayLength = 100f;
  public LayerMask layerMask;
  private GameObject clicked;
  private float PPUScale = 4f;
  private float PPU = 16f;

  public AudioClip song;
  public AudioClip moveBlockSound;

  // Use this for initialization
  void Awake () {
   // Screen.SetResolution(480, 270, false);
    //Orthographic size = ((Vert Resolution)/(PPUScale * PPU)) * 0.5
    //Camera.main.orthographicSize = (Screen.height / (PPUScale * PPU)) * 0.5f;

    //DontDestroyOnLoad(gameObject);

  }

  void Start() {
    AudioSource musicSource = MusicManager.GetInstance().gameObject.GetComponent<AudioSource>();
    if (song && musicSource) {
      musicSource.clip = song;
      musicSource.Play();
    }
  }


  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0) && clicked) {
      // TODO: IF IT DOES NOT COLLIDE
      StopPreviousFromFollowing();
    } else if (Input.GetMouseButtonDown(0)) {
      DetectClickBlock();
    }

    //Right button
    if (Input.GetMouseButtonDown(1) && clicked) {
      //RotateParent();
      
    }
  }

  void DetectClickBlock() {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 20f, ~(1 << LayerMask.NameToLayer(LayerHandler.layerRoom)));

    if (hit.collider != null) {
      if (hit.transform.tag == TagHandler.tagGem || hit.transform.tag == TagHandler.tagBlock) {
        MakeItemMove(hit);
      }
    }
  }

  void MakeItemMove(RaycastHit2D hit) {
    // Unlink previous clicked item.
    TetrisPieceMovement moveScript;
    if (hit.transform.gameObject.transform.parent == null) {
      return;
    }
    moveScript = hit.transform.gameObject.transform.parent.GetComponentInParent<TetrisPieceMovement>();
    if (moveScript == null) {
      return;
    }
    clicked = moveScript.gameObject;

    if (moveBlockSound) {
      SoundManager.GetInstance().gameObject.GetComponent<AudioSource>().PlayOneShot(moveBlockSound);
    }

    if (moveScript) {
      moveScript.SetFollowMouse(true);
    }
  }
  void StopPreviousFromFollowing() {
    if (clicked != null) {
      bool insideRoom = CheckClickInsideRoom();
      if (insideRoom) {
        TetrisPieceMovement oldMoveScript = clicked.GetComponentInParent<TetrisPieceMovement>();
        if (oldMoveScript) {
          oldMoveScript.SetFollowMouse(false);
        }

        clicked = null;

        if (moveBlockSound) {
          SoundManager.GetInstance().gameObject.GetComponent<AudioSource>().PlayOneShot(moveBlockSound);
        }
      }
    }
  }

  void RotateParent() {
    if (clicked && clicked.transform.parent && clicked.transform.gameObject.GetComponentInParent<TetrisPieceMovement>()) {
      clicked.transform.parent.transform.rotation *= Quaternion.Euler(0, 0, 90);
    }
  }

  bool CheckClickInsideRoom() {
    if (this.clicked == null) {
      return false;
    }
    bool insideRoom = true;
    bool collidesWithSomething = false;

    TetrisPieceTriggerDetector[] allChildren = this.clicked.GetComponentsInChildren<TetrisPieceTriggerDetector>();
    foreach (TetrisPieceTriggerDetector child in allChildren) {
      Vector3 checkPos = child.transform.position;
      Vector2 checkPos2D = new Vector2(checkPos.x, checkPos.y);

      RaycastHit2D hitRoom = Physics2D.Raycast(checkPos2D, Vector2.zero, 30f, 1 << LayerMask.NameToLayer(LayerHandler.layerRoom));
      insideRoom = insideRoom && (hitRoom.collider != null);

      LayerMask allLayersThatBlock = ~ (1 << LayerMask.NameToLayer(LayerHandler.layerRoom) 
                                       | 1 << LayerMask.NameToLayer(LayerHandler.layerSelectedBlock)
                                       | 1 << LayerMask.NameToLayer(LayerHandler.layerEmpty));
      RaycastHit2D hitOther = Physics2D.Raycast(checkPos2D, Vector2.zero, 30f, allLayersThatBlock);
        
      collidesWithSomething = collidesWithSomething || (hitOther.collider != null);
    }

    if (insideRoom && !collidesWithSomething) {
      return true;
    }
    return false;
  }
}

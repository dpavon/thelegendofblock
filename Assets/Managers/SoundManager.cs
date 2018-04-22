using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
  // Singleton
  public static SoundManager instance = null;

  void Awake() {
    if (instance == null) {
      instance = this;
    } else if (instance != this) {
      Destroy(gameObject);
    }
  }

  public static SoundManager GetInstance() {
    if (instance == null) {
      instance = new SoundManager();
    }
    return instance;
  }
}

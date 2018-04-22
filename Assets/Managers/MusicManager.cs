using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
  // Singleton
  public static MusicManager instance = null;

  void Awake() {
    if (instance == null) {
      instance = this;
    } else if (instance != this) {
      Destroy(gameObject);
    }
  }

  public static MusicManager GetInstance() {
    if (instance == null) {
      instance = new MusicManager();
    }
    return instance;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {
  public GameObject prefabToSpawn;
  private GameObject instantiated;

	// Use this for initialization
	void Start () {
    if (prefabToSpawn) {
      this.instantiated = Instantiate(prefabToSpawn);
      this.instantiated.transform.position = this.transform.position;
      this.instantiated.transform.parent = this.transform;
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

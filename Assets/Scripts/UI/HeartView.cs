using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartView : MonoBehaviour {
  // Heart prefab to be instantiated
  [SerializeField] private Heart heartPrefab;

  // Transform used as parent for heart prefabs
  [SerializeField] private Transform instantiator;

  // List of references to child hearts
  private List<Heart> hearts;
  
  public void Initialize(int maxHealth) {
    // Destroy any existing hearts before re-instantiating
    foreach (Transform child in this.instantiator) {
      Destroy(child.gameObject);
    }

    // Re-instantiate a number of hearts equal to the player health
    this.hearts = new List<Heart>();
    for (int i = 0; i < maxHealth; i++) {
      Heart heart = Instantiate<Heart>(this.heartPrefab, this.instantiator);
      heart.Initialize();
      this.hearts.Add(heart);
    }
  }

  public void UpdateView(int currentHealth) {
    // Active hearts
    for (int i = 0; i < currentHealth; i++) {
      this.hearts[i].EnableHeart();
    }

    // Inactive hearts
    for (int i = currentHealth; i < this.hearts.Count; i++) {
      this.hearts[i].DisableHeart();
    }
  }
}

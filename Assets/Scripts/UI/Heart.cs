using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {
  [SerializeField] private Image heartFill;

  public void Initialize() {
    this.EnableHeart();
  }

  // Enabling/Disabling heart currently only toggles visibility of fill
  // In the future, this could involve some animation of particle effect
  public void EnableHeart() {
    this.heartFill.gameObject.SetActive(true);
  }

  public void DisableHeart() {
    this.heartFill.gameObject.SetActive(false);
  }
}

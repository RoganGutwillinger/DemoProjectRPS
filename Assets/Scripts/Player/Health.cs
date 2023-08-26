using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health {
  public int MaxHealth { get; private set; }

  public int CurrentHealth { get; private set; }

  public Health(int maxHealth) {
    this.MaxHealth = maxHealth;
    this.CurrentHealth = maxHealth;
  }

  public void DecrementHealth(int amount) {
    // Ensure health never drops below 0
    this.CurrentHealth = Mathf.Max(this.CurrentHealth - amount, 0);
  }
}

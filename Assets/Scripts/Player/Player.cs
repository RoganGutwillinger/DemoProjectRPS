using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
  // Player's health in the current game
  public Health Health { get; protected set; }

  // Player's current move, updates at the start of every round
  public GameMove SelectedGameMove { get; set; }

  // Indicates whether or not the player won the current round
  public bool WonRound { get; set; }

  public Player(int maxHealth) {
    this.Health = new Health(maxHealth);
  }
}

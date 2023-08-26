using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Player {
  public Opponent(int maxHealth) : base(maxHealth) {
    return;
  }

  public void SelectRandomGameMove() {
    // Randomly select between rock, paper, scissors
    this.SelectedGameMove = (GameMove)Random.Range(0, 3);
  }
}

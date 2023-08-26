using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic {
  public void ResolveRound(Player player, Player opponent) {
    // Resolve the logic for this round on a case-by-case basis
    // The two players' `WonRound` variables must be set accordingly and the losing player will lose a life
    if (player.SelectedGameMove == GameMove.Rock) {
      if (opponent.SelectedGameMove == GameMove.Rock) {
        this.TiedRound(player, opponent);
      }
      else if (opponent.SelectedGameMove == GameMove.Paper) {
        this.PlayerLosesRound(player, opponent);
      }
      else {
        this.PlayerWinsRound(player, opponent);
      }
    }
    else if (player.SelectedGameMove == GameMove.Paper) {
      if (opponent.SelectedGameMove == GameMove.Rock) {
        this.PlayerWinsRound(player, opponent);
      }
      else if (opponent.SelectedGameMove == GameMove.Paper) {
        this.TiedRound(player, opponent);
      }
      else {
        this.PlayerLosesRound(player, opponent);
      }
    }
    else {
      if (opponent.SelectedGameMove == GameMove.Rock) {
        this.PlayerLosesRound(player, opponent);
      }
      else if (opponent.SelectedGameMove == GameMove.Paper) {
        this.PlayerWinsRound(player, opponent);
      }
      else {
        this.TiedRound(player, opponent);
      }
    }
  }

  private void PlayerWinsRound(Player player, Player opponent) {
    player.WonRound = true;
    opponent.WonRound = false;
    opponent.Health.DecrementHealth(1);
  }

  private void PlayerLosesRound(Player player, Player opponent) {
    player.WonRound = false;
    player.Health.DecrementHealth(1);
    opponent.WonRound = true;
  }

  private void TiedRound(Player player, Player opponent) {
    player.WonRound = false;
    opponent.WonRound = false;
  }
}

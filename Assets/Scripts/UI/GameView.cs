using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameView : View {
  // Game view component references
  [SerializeField] private PlayerView playerView;
  [SerializeField] private PlayerView opponentView;
  [SerializeField] private GameMoveView gameMoveView;

  public GameMoveView GameMoveView => this.gameMoveView;

  public void Initialize(Player player, Player opponent) {
    this.playerView.Initialize(player);
    this.opponentView.Initialize(opponent);
    this.gameMoveView.Initialize();
  }

  public void PlayGameAnimation(Action onComplete = null) {
    // Play animation for both players, calling onComplete once
    this.playerView.PlayGameAnimation();
    this.opponentView.PlayGameAnimation(onComplete);
  }
}

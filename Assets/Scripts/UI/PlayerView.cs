using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerView : MonoBehaviour {
  // View used to display player's current life
  [SerializeField] private HeartView heartView;

  // Main hand sprite representing player
  [SerializeField] private Image playerHand;

  // Hand options sprites
  [SerializeField] private Sprite rockSprite;
  [SerializeField] private Sprite paperSprite;
  [SerializeField] private Sprite scissorsSprite;

  private Player player;

  public void Initialize(Player player) {
    this.player = player;
    this.heartView.Initialize(player.Health.MaxHealth);
  }

  public void PlayGameAnimation(Action onComplete = null) {
    // Hand will bounce up and down a few times; get relevant y values
    float originalY = this.playerHand.transform.localPosition.y;
    float raisedY = originalY + 50f;

    Sequence gameSequence = DOTween.Sequence();
    
    // Hand bounce animation
    gameSequence.Append(this.playerHand.transform.DOLocalMoveY(raisedY, 0.3f));
    gameSequence.Append(this.playerHand.transform.DOLocalMoveY(originalY, 0.2f).SetEase(Ease.InQuad));
    gameSequence.Append(this.playerHand.transform.DOLocalMoveY(raisedY, 0.2f).SetEase(Ease.OutQuad));
    gameSequence.Append(this.playerHand.transform.DOLocalMoveY(originalY, 0.2f).SetEase(Ease.InQuad));
    gameSequence.Append(this.playerHand.transform.DOLocalMoveY(raisedY, 0.2f).SetEase(Ease.OutQuad));
    gameSequence.Append(this.playerHand.transform.DOLocalMoveY(originalY, 0.2f).SetEase(Ease.InQuad));

    // Show selected move, before returning to rock by default
    gameSequence.AppendCallback(() => this.playerHand.sprite = this.GetSpriteForGameMove(this.player.SelectedGameMove));
    gameSequence.AppendInterval(1f);
    gameSequence.AppendCallback(() => this.playerHand.sprite = this.rockSprite);

    if (this.player.WonRound) {
      // Add some kind of round win animation here; particle effect behind hand?
    } else {
      gameSequence.AppendCallback(() => this.heartView.UpdateView(this.player.Health.CurrentHealth));
    }

    if (onComplete != null) {
      gameSequence.AppendCallback(onComplete.Invoke);
    }

    gameSequence.Play();
  }

  // Sprite lookup for each game move
  private Sprite GetSpriteForGameMove(GameMove move) {
    switch (move) {
      case GameMove.Rock:
        return this.rockSprite;
      case GameMove.Paper:
        return this.paperSprite;
      case GameMove.Scissors:
        return this.scissorsSprite;
      default:
        return this.rockSprite;
    }
  }
}

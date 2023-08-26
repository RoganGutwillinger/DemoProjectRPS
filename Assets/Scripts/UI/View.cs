using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class View : MonoBehaviour {
  [SerializeField] private CanvasGroup canvasGroup;
  [SerializeField] private float viewFadeDuration = 0.3f;

  public float ViewAlpha {
    get { return this.canvasGroup.alpha; }
    set { this.canvasGroup.alpha = value; }
  }

  // Returns a tween to smoothly fade in the view contents
  public Tween GetShowTween() {
    return this.canvasGroup.DOFade(1f, this.viewFadeDuration);
  }

  // Returns a tween to smoothly fade out the view contents
  public Tween GetHideTween() {
    return this.canvasGroup.DOFade(0f, this.viewFadeDuration);
  }
}

using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

public class CoinCounterUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    private void Start() {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score) {
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(Ease.OutBounce);
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score) {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        coinTextContainer.localPosition = new Vector3(
            coinTextContainer.localPosition.x, containerInitPosition, coinTextContainer.localPosition.z);
    }
}

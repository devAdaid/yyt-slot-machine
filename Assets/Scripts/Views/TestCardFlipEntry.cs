using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardFlipEntry : MonoBehaviour
{
    public TestCardUI FixCardUI;
    public TestCardUI FlipCardUI;
    public Vector2 FlipTimeRange = new Vector2(0.2f, 0.5f);
    public float DefaultFlipTime = 0.5f;
    public bool IsAnimating = false;
    public bool IsAutoFliping = false;

    private void Start()
    {
        FlipCardUI.gameObject.SetActive(false);
    }

    public void AutoFlip()
    {
        StartCoroutine(AutoAnimateFlip());
    }

    public void SetFixCardSprite(Card fixCard)
    {
        FixCardUI.SetFrontCardSprite(Util.GetCardFrontSprite(fixCard));
    }

    public void ShowFlip(Card newFixCard)
    {
        if (IsAnimating)
        {
            return;
        }

        var prevFixCardSprite = FixCardUI.FrontCardRenderer.sprite;
        FlipCardUI.SetFrontCardSprite(prevFixCardSprite);
        FixCardUI.SetFrontCardSprite(Util.GetCardFrontSprite(newFixCard));
        StartCoroutine(AnimateFlip(DefaultFlipTime));
    }

    private IEnumerator AutoAnimateFlip()
    {
        IsAutoFliping = true;

        while(true)
        {
            if (!IsAutoFliping)
            {
                yield break;
            }

            float flipTime = Random.Range(FlipTimeRange.x, FlipTimeRange.y);

            var newFixCard = Util.GetRandomCard();
            var prevFixCardSprite = FixCardUI.FrontCardRenderer.sprite;
            FlipCardUI.SetFrontCardSprite(prevFixCardSprite);
            FixCardUI.SetFrontCardSprite(Util.GetCardFrontSprite(newFixCard));
            yield return AnimateFlip(flipTime);
        }
    }

    private IEnumerator AnimateFlip(float flipTime)
    {
        IsAnimating = true;

        FlipCardUI.gameObject.SetActive(true);

        float fromXAngle = 0f;
        float toXAngle = -115f;

        float t = 0f;
        float step = Time.deltaTime / flipTime;
        while (t < 1f)
        {
            float angleX = Mathf.LerpAngle(fromXAngle, toXAngle, t);
            FlipCardUI.transform.localEulerAngles = new Vector3(angleX, 0, 0);
            t += step;
            yield return null;
        }

        TestSound.I.PlayRandomCardSound();
        FlipCardUI.gameObject.SetActive(false);

        IsAnimating = false;
    }
}

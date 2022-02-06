using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Ctrl_Sheft_Hint : MonoBehaviour
{
    public SpriteRenderer ctrl;
    public SpriteRenderer sheft;
    public TextMeshPro hint;

    bool firstTime;

    private void Awake()
    {
        LeanTween.alpha(gameObject, 0, 0);
        hint.alpha = 0;

        Bow.BowDown += ShowHint;
        firstTime = true;
    }


    private void ShowHint()
    {
        if (firstTime)
        {
            firstTime = false;
            LeanTween.delayedCall(.5f, () =>
            {
                //LeanTween.value(hint.gameObject,()=> { },)
                LeanTween.value(hint.gameObject, (value) => { hint.alpha = value; }, 0, 0.75f, 2f);

                LeanTween.alpha(gameObject, 0.75f, 2f).setEaseInOutQuart();
                //LeanTween.value(hint.alpha, 0.75f, 1.5f).setEaseInOutQuart();
                LeanTween.delayedCall(5f, () => { HideHint(); });
            });
            
        }
    }

    void HideHint()
    {
        LeanTween.alpha(gameObject, 0, .75f).setEaseInOutQuart();
        LeanTween.value(hint.gameObject, (value) => { hint.alpha = value; }, 0.75f, 0, .75f);




    }
}

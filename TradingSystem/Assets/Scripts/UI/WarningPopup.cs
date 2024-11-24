using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPopup : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI warningText;

    public void Show(string warning, float duration)
    {
        gameObject.SetActive(true);
        warningText.text = warning;
        StopAllCoroutines();
        StartCoroutine(ShowWarning(warning, duration));
    }

    IEnumerator ShowWarning(string warning, float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}

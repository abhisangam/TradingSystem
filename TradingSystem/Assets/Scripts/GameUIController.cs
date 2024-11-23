using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI currencyText;
    
    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = playerController.GetCurrency().ToString();
        playerController.OnCurrencyChanged += OnCurrencyChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCurrencyChanged(int currency)
    {
        currencyText.text = currency.ToString();
    }
}

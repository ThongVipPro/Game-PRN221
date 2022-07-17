using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    GameObject alert;
    TextMeshProUGUI meleePrice;
    TextMeshProUGUI rangerPrice;
    TextMeshProUGUI cavalryPrice;

    Purchase purchase = new Purchase();

    // Start is called before the first frame update
    void Start()
    {
        alert = transform.GetChild(5).gameObject;
        meleePrice = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        rangerPrice = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        cavalryPrice = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();

        EventManager.AddPurchaseInvoker(this);
        EventManager.AddUpGenerationListener(SetPrice);
        EventManager.AddPurchaseFailedListener(Alert);
    }

    // Update is called once per frame
    void Update() { }

    public void AddPurchaseListener(UnityAction<int, int> listener)
    {
        purchase.AddListener(listener);
    }

    public void Alert()
    {
        StartCoroutine(Message());
    }

    IEnumerator Message()
    {
        alert.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        alert.SetActive(false);
    }

    public void SetPrice()
    {
        meleePrice.text = (Int32.Parse(meleePrice.text) * 2).ToString();
        rangerPrice.text = (Int32.Parse(rangerPrice.text) * 2).ToString();
        cavalryPrice.text = (Int32.Parse(cavalryPrice.text) * 2).ToString();
        transform.GetChild(4).gameObject.SetActive(false);
    }

    public void BuyMelee()
    {
        purchase.Invoke(0, Int32.Parse(meleePrice.text));
    }

    public void BuyRanger()
    {
        purchase.Invoke(1, Int32.Parse(rangerPrice.text));
    }

    public void BuyCavalry()
    {
        purchase.Invoke(2, Int32.Parse(cavalryPrice.text));
    }

    public void BuyUpgrade()
    {
        purchase.Invoke(
            3,
            Int32.Parse(transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text)
        );
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Video;

public class PayManager : MonoBehaviour
{
    protected const string pay299 = "com.kendzz.shopiap.299";
    protected const string pay2999 = "com.kendzz.shopiap.2999";
    protected const string coin199 = "com.kendzz.shopiap.coin199";
    protected const string coin399 = "com.kendzz.shopiap.coin399";
    protected const string coin1999 = "com.kendzz.shopiap.coin1999";
    protected const string pay499 = "com.kendzz.shopiap.499";
    protected const string pay999 = "com.kendzz.shopiap.999";
    protected const string coin599 = "com.kendzz.shopiap.coin599";
    protected const string coin799 = "com.kendzz.shopiap.coin799";
    protected const string coin1499 = "com.kendzz.shopiap.coin1499";
    private int coin = 0;
    private string m_coin = "coin";
    public TMP_InputField Input;
    public VideoPlayer videoPlayer;


    void Update()
    {
        if (videoPlayer.frame > 2 && !videoPlayer.isPlaying)
        {
            this.addCoin(9999);
        }
    }

    public void OnPurchaseComplete(Product item)
    {
        switch (item.definition.id)
        {
            case pay299:
                Debug.Log(pay299);
                this.addItem("item1",1);
                this.addItem("item2", 1);
                this.addItem("item3", 1);
                this.addCoin(299);
                break;
            case pay2999:
                Debug.Log(pay2999);
                this.addItem("item1", 1);
                this.addItem("item2", 1);
                this.addItem("item3", 1);
                this.addItem("item4", 1);
                this.addCoin(2999);
                break;
            case coin199:
                Debug.Log(coin199);
                this.addCoin(199);
                break;
            case coin399:
                Debug.Log(coin399);
                this.addCoin(399);
                break;
            case coin1999:
                Debug.Log(coin1999);
                this.addCoin(1999);
                break;
            case pay499:
                Debug.Log(pay499);
                this.addItem("item1", 1);
                this.addItem("item2", 1);
                this.addItem("item3", 1);
                this.addCoin(499);
                break;
            case pay999:
                Debug.Log(pay999);
                this.addItem("item1", 1);
                this.addItem("item2", 1);
                this.addItem("item3", 1);
                this.addItem("item4", 1);
                this.addCoin(999);
                break;
            case coin599:
                Debug.Log(coin599);
                this.addCoin(599);
                break;
            case coin799:
                Debug.Log(coin799);
                this.addCoin(799);
                break;
            case coin1499:
                Debug.Log(coin1499);
                this.addCoin(1499);
                break;
        }
    }

    public void addCoin(int coinAdd)
    {
        int coinTotal = PlayerPrefs.GetInt(m_coin) + coinAdd;
        PlayerPrefs.SetInt(m_coin, coinTotal);
        PlayerPrefs.Save();
        this.loadData();
    }

    private void addItem(string type , int count)
    {
        int itemTotal = PlayerPrefs.GetInt(type) + count;
        PlayerPrefs.SetInt(type, itemTotal);
        PlayerPrefs.Save();
    }


    public void Start()
    {
        this.loadData();
    }

    private void loadData()
    {
        coin = PlayerPrefs.GetInt(m_coin);
        Input.text = string.Format("Coin: {0}", coin);
    }

    public void OnPurchaseFailed(Product item, PurchaseFailureReason fail)
    {
        Debug.Log(string.Format("Item: {0} | Code: {1}", item, fail));
    }
}

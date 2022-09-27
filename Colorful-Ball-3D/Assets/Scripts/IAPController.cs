using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;

public class IAPController : MonoBehaviour,IStoreListener
{
    public UIManager uimanager;
    public SoundManager soundmanager;

    public string[] product;
    IStoreController controller;

   public void Start()
    {
        IAPStart();
    }

    public void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach (string item in product)
        {
            builder.AddProduct(item, ProductType.Consumable);   
        }
        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialize Failed");
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Failed");
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id, product[0], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("moneyy", PlayerPrefs.GetInt("moneyy") + 2500);
            uimanager.CoinTextUpdate();
            soundmanager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[1], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("moneyy", PlayerPrefs.GetInt("moneyy") + 5000);
            uimanager.CoinTextUpdate();
            soundmanager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[2], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("moneyy", PlayerPrefs.GetInt("moneyy") + 15000);
            uimanager.CoinTextUpdate();
            soundmanager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else
            return PurchaseProcessingResult.Pending;
    }
    public void IAPButton(string id)
    {
        Product product = controller.products.WithID(id);
        if (product !=null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
            Debug.Log("buying");
        }
        else
            Debug.Log("not buying");
    }
}

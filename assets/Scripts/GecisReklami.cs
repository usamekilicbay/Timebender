using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class GecisReklami : MonoBehaviour
{
    [Header("Debuging")]
    public bool isActivate = false;
    public bool yenidenGoster = true;
    public float waitsec;
    public float adsShowTime;
    public float firstAdsShowTime;
   // string adIDs = "ca-app-pub-3940256099942544/1033173712";
    string adIDs = "ca-app-pub-5489432413164397/3614904359";
    InterstitialAd interstitial;
    public void Start()
    {
        RequestInterstitial();
        StartCoroutine(IlkRelamiGoster());
    }
    // reklamı yükler
    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adIDs);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        // loading.text = "Ads Loading";
        StartCoroutine(ResetTexts());
        if (isActivate)
        {
            StartCoroutine(ShowAds());
        }
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        // loading.text = "Ads Loaded";
        StartCoroutine(ResetTexts());
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // loading.text = "Ads Failed To Load";
        StartCoroutine(ResetTexts());
        RequestInterstitial();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {

        // status.text = "Ads Opened";
        StartCoroutine(ResetTexts());
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {

        // status.text = "Ads Closed";
        StartCoroutine(ResetTexts());
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

        //status.text = "User Left";
        StartCoroutine(ResetTexts());
    }
    IEnumerator IlkRelamiGoster()
    {
        yield return new WaitForSeconds(firstAdsShowTime);
        if (this.interstitial.IsLoaded())
        {
            //   status.text = "Ads Opening";
            StartCoroutine(ResetTexts());
            this.interstitial.Show();
        }

        RequestInterstitial();

    }
    IEnumerator ShowAds()//bura tekrar çağrılınca 100 saniye sonra yani tekrar ilk reklamı da çağırmaz mı ? 

    {
        yield return new WaitForSeconds(adsShowTime);// burası süreyi bekliyor
        if (this.interstitial.IsLoaded())// reklamın yüklendiğini kontrol eder
        {
            //   status.text = "Ads Opening";
            // StartCoroutine(ResetTexts());// reklam çalışır
            this.interstitial.Show();
        }
        if (yenidenGoster)
        {
            isActivate = true;
        }
        RequestInterstitial();
    }
    IEnumerator ResetTexts()
    {
        yield return new WaitForSeconds(waitsec);
        // loading.text = "";
        //m  status.text = "";
    }


}
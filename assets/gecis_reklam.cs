using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class gecis_reklam : MonoBehaviour
{

	public string intestinial_id;
	const float MAX_TİME = 10f;
	float time_Rew =  .4f;
    float adTime;
    public float maxAdTime;
	bool reklam_yuklu=false;
    //public Text debugText;
    // Use this for initialization
    void Start()
    {        
		#if UNITY_ANDROID
		string appId = "ca-app-pub-5489432413164397~2212648183";
		#elif UNITY_IPHONE
		string appId = "app-id";
		#else
		string appId = "unexpected_platform";
		#endif
		
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
        //Request Ad
        RequestInterstitialAds();
    }

    void Update()
    {
		if (!reklam_yuklu) {
			time_Rew -= Time.deltaTime;
			if (time_Rew <= 0) {
				RequestInterstitialAds ();
				time_Rew = MAX_TİME;
			}
		}

        adTime += Time.deltaTime;
        if (adTime >= maxAdTime)
        {
            showInterstitialAd();
            adTime = 0;
        }
    }

    public void showInterstitialAd()
    {
        //Show Ad)
        if (interstitial.IsLoaded ()) {
			interstitial.Show ();
			Debug.Log ("Reklam Yüklenmişse Göster");
		} 
		else 
		{
			reklam_yuklu=false;
		}

    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {

#if UNITY_ANDROID
		string adUnitId = intestinial_id;
		#elif UNITY_IOS
		string adUnitId = intestinial_id;
		#else
		string adUnitId = "unexpected_platform";
		#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        //***Test***


        //***Production***
        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;
		interstitial.OnAdFailedToLoad +=  Interstitial_OnAdFailedToLoad;
		interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
		interstitial.OnAdOpening+= Interstitial_OnAdOpening;
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("AD LOADED XXX");

    }

	void Interstitial_OnAdOpening (object sender, System.EventArgs e)
    {
		Debug.Log ("Açılıyor...");
		reklam_yuklu = true;
    }

	private void Interstitial_OnAdLoaded (object sender, System.EventArgs e)
    {
		Debug.Log ("Yüklendi...");
		reklam_yuklu = true;
	}

	private void Interstitial_OnAdFailedToLoad (object sender, AdFailedToLoadEventArgs e)
    {
        //debugText.text = e.Message;
		reklam_yuklu = false;
	}

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
		Debug.Log ("Kapandı...");
		reklam_yuklu = false;
    }
}
using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour {
    public static UnityAds instance;
    public string idadsAndroid;
    public string idadsIphone;
    public bool showads;
    public GameObject playnow;
    public GameObject getkey;
    void Awake()
    {
        if (showads)
        {
            if (Advertisement.isSupported)
            {
                Advertisement.Initialize(idadsAndroid, false);
                if (Application.platform == RuntimePlatform.Android)
                {
                    Advertisement.Initialize(idadsAndroid, false);
                }
                else if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    Advertisement.Initialize(idadsIphone, false);
                }
            }
        }
        else
        {
            playnow.SetActive(false);
            getkey.SetActive(false);
        }
       
    }
    public void clicadd()
    {
        if (Advertisement.IsReady())
        {
            //Debug.Log("vô");
            var option = new ShowOptions { resultCallback = HandleShowResuld };
            Advertisement.Show(null, option);
        }
    }
   
    private void HandleShowResuld(ShowResult obj)
    {
        switch (obj)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                UImanager.uimanager.Playnow();
                break;
            default:
                break;
        }
    }



    public void ShowAdsFofEarm3Key()
    {
        if (Advertisement.IsReady())
        {
            Debug.Log("vô");
            var option = new ShowOptions { resultCallback = HandleShowResuld3 };
            Advertisement.Show(null, option);
        }
    }

    private void HandleShowResuld3(ShowResult obj)
    {
        switch (obj)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                BuyADS.Instance.StopCoroutine(BuyADS.Instance.delayshow());
                BuyADS.Instance.StartAnimation("Get 3 keys");
                break;
            default:
                break;
        }
    }
    public bool UnityAdsloaded()
    {
        if (Advertisement.IsReady())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Use this for initialization
    void Start () {
        instance = this;

    }
	
 
}

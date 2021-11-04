using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointShop : MonoBehaviour
{
    public float points;
    public Text pointDisplay;

    public Button rocketBuy;
    public Text rocketPriceDisplay;
    public int rocketPrice = 7500;
    public static int areRocketsBought = 0;

    public Button wideshotBuy;
    public Text wideshotPriceDisplay;
    public int wideshotPrice = 6000;
    public static int isWideshotBought = 0;

    public Button frigateBuy;
    public Text frigateDisplay;
    public int isFrigateBought = 0;
    public static bool isFrigateSelected;

    public Button cruiserBuy;
    public Text cruiserDisplay;
    public int isCruiserBought = 0;
    public static bool isCruiserSelected;

    public Button destroyerBuy;
    public Text destroyerDisplay;
    public int isDestroyerBought;
    public static bool isDestroyerSelected;

    public Button carrierBuy;
    public Text carrierDisplay;
    public int isCarrierBought = 0;
    public static bool isCarrierSelected;

    public Button corvetteEquip;
    public static bool isCorvetteEquipped;
    public Text corvetteDisplay;

    public int frigatePrice = 10000;
    public int cruiserPrice = 24000;
    public int carrierPrice = 35000;
    public int destroyerPrice = 42000;

    public void Start()
    {

        areRocketsBought = PlayerPrefs.GetInt("areRocketsBought");
        isWideshotBought = PlayerPrefs.GetInt("isWideshotBought");
        
        isFrigateBought = PlayerPrefs.GetInt("isFrigateBought");
        isCruiserBought = PlayerPrefs.GetInt("isCruiserBought");
        isCarrierBought = PlayerPrefs.GetInt("isCarrierBought");
        isDestroyerBought = PlayerPrefs.GetInt("isDestroyerBought");
        if (areRocketsBought == 0)
        {
            rocketPriceDisplay.text = "Buy - " + rocketPrice;
        }
        else
        {
            rocketPriceDisplay.text = "Bought!";
        }

        if (isWideshotBought == 0)
        {
            wideshotPriceDisplay.text = "Buy - " + wideshotPrice;
        }
        else
        {
            wideshotPriceDisplay.text = "Bought!";
        }

        if (!isFrigateSelected && !isCruiserSelected && !isCarrierSelected && !isDestroyerSelected)
        {
            isCorvetteEquipped = true;
            corvetteDisplay.text = "Equipped!";
        }
        else
        {
            corvetteDisplay.text = "Equip";
        }

        if (isFrigateBought == 0)
        {
            frigateDisplay.text = "Buy - " + frigatePrice;
        }
        else if (isFrigateSelected == false && isFrigateBought == 1)
        {
            frigateDisplay.text = "Equip";
        }
        else
        {
            frigateDisplay.text = "Equipped!";
        }

        {
            
        }
        if (isCruiserBought == 0)
        {
            cruiserDisplay.text = "Buy - " + cruiserPrice;
        }
        else if (isCruiserSelected == false && isCruiserBought == 1)
        {
            cruiserDisplay.text = "Equip";
        }
        else
        {
            
        }

        if (isCarrierBought == 0)
        {
            carrierDisplay.text = "Buy - " + carrierPrice;
        }
        else if (isCarrierSelected == false)
        {
            carrierDisplay.text = "Equip";
        }
        else
        {
            carrierDisplay.text = "Equipped!";
        }

        if (isDestroyerBought == 0)
        {
            destroyerDisplay.text = "Buy - " + destroyerPrice;
        }
        else if (isDestroyerSelected == false)
        {
            destroyerDisplay.text = "Equip";
        }
        else
        {
            destroyerDisplay.text = "Equipped!";
        }

        points = PlayerPrefs.GetFloat("points");

        pointDisplay.text = "Points: " + Mathf.Round(points);
    }

    public void BuyRocket()
    {
        if (points >= rocketPrice && areRocketsBought == 0)
        {
            points -= rocketPrice;
            areRocketsBought = 1;
            PlayerPrefs.SetInt("areRocketsBought", areRocketsBought);
            PlayerPrefs.SetFloat("points", points);
            pointDisplay.text = "Points: " + Mathf.Round(points);
            rocketPriceDisplay.text = "Bought!";
        }
    }
    public void BuyWideshot()
    {
        if (points >= wideshotPrice && isWideshotBought == 0)
        {
            points -= wideshotPrice;
            isWideshotBought = 1;
            PlayerPrefs.SetInt("isWideshotBought", isWideshotBought);
            PlayerPrefs.SetFloat("points", points);
            pointDisplay.text = "Points: " + Mathf.Round(points);
            wideshotPriceDisplay.text = "Bought!";
        }
    }
    public void Frigate()
    {
        if (points >= frigatePrice && isFrigateBought == 0)
        {
            points -= frigatePrice;
            isFrigateBought = 1;
            PlayerPrefs.SetInt("isFrigateBought", isFrigateBought);
            PlayerPrefs.SetFloat("points", points);
            pointDisplay.text = "Points: " + Mathf.Round(points);
            frigateDisplay.text = "Equip";
        }
        if (isFrigateBought == 1 && !isFrigateSelected)
        {
            isDestroyerSelected = false;
            isCorvetteEquipped = false;
            isCarrierSelected = false;
            isCruiserSelected = false;
            isFrigateSelected = true;
            frigateDisplay.text = "Equipped!";
            if (isCruiserBought == 1)
            {
                cruiserDisplay.text = "Equip";
            }
            if (isCarrierBought == 1)
            {
                carrierDisplay.text = "Equip";
            }
            if (isDestroyerBought == 1)
            {
                destroyerDisplay.text = "Equip";
            }
            corvetteDisplay.text = "Equip";
        }
    }
    public void Cruiser()
    {
        if (points >= cruiserPrice && isCruiserBought == 0)
        {
            points -= cruiserPrice;
            isCruiserBought = 1;
            PlayerPrefs.SetInt("isCruiserBought", isCruiserBought);
            PlayerPrefs.SetFloat("points", points);
            pointDisplay.text = "Points: " + Mathf.Round(points);
            cruiserDisplay.text = "Equip";
        }
        if (isCruiserBought == 1 && !isCruiserSelected)
        {
            isDestroyerSelected = false;
            isCorvetteEquipped = false;
            isCarrierSelected = false;
            isCruiserSelected = true;
            isFrigateSelected = false;
            cruiserDisplay.text = "Equipped!";
            if (isFrigateBought == 1)
            {
                frigateDisplay.text = "Equip";
            }
            if (isCarrierBought == 1)
            {
                carrierDisplay.text = "Equip";
            }
            if (isDestroyerBought == 1)
            {
                destroyerDisplay.text = "Equip";
            }
            corvetteDisplay.text = "Equip";
        }
    }
    public void Carrier()
    {
        if (points >= carrierPrice && isCarrierBought == 0)
        {
            points -= carrierPrice;
            isCarrierBought = 1;
            PlayerPrefs.SetInt("isCarrierBought", isCarrierBought);
            PlayerPrefs.SetFloat("points", points);
            pointDisplay.text = "Points: " + Mathf.Round(points);
            carrierDisplay.text = "Equip";
        }
        if (isCarrierBought == 1 && !isCarrierSelected)
        {
            isDestroyerSelected = false;
            isCorvetteEquipped = false;
            isCarrierSelected = true;
            isCruiserSelected = false;
            isFrigateSelected = false;
            carrierDisplay.text = "Equipped!";
            if (isFrigateBought == 1)
            {
                frigateDisplay.text = "Equip";
            }
            if (isCruiserBought == 1)
            {
                cruiserDisplay.text = "Equip";
            }
            if (isDestroyerBought == 1)
            {
                destroyerDisplay.text = "Equip";
            }
            corvetteDisplay.text = "Equip";
        }
    }
    public void Destroyer()
    {
        if (points >= destroyerPrice && isDestroyerBought == 0)
        {
            points -= destroyerPrice;
            isDestroyerBought = 1;
            PlayerPrefs.SetInt("isDestroyerBought", isDestroyerBought);
            PlayerPrefs.SetFloat("points", points);
            pointDisplay.text = "Points: " + Mathf.Round(points);
            destroyerDisplay.text = "Equipped!";
        }
        if (isDestroyerBought == 1 && !isDestroyerSelected)
        {
            isDestroyerSelected = true;
            isCorvetteEquipped = false;
            isCarrierSelected = false;
            isCruiserSelected = false;
            isFrigateSelected = false;
            destroyerDisplay.text = "Equipped!";
            if (isFrigateBought == 1)
            {
                frigateDisplay.text = "Equip";
            }
            if (isCruiserBought == 1)
            {
                cruiserDisplay.text = "Equip";
            }
            if (isCarrierBought == 1)
            {
                carrierDisplay.text = "Equip";
            }
            corvetteDisplay.text = "Equip";
        }
    }

    public void Corvette()
    {
        if (isCorvetteEquipped == false)
        {
            corvetteDisplay.text = "Equip";
            isCorvetteEquipped = true;
        }
        if (isCorvetteEquipped == true)
        {
            isDestroyerSelected = false;
            isCarrierSelected = false;
            isCruiserSelected = false;
            isFrigateSelected = false;
            corvetteDisplay.text = "Equipped!";
            if (isFrigateBought == 1)
            {
                frigateDisplay.text = "Equip";
            }
            if (isCruiserBought == 1)
            {
                cruiserDisplay.text = "Equip";
            }
            if (isCarrierBought == 1)
            {
                carrierDisplay.text = "Equip";
            }
            if (isDestroyerBought == 1)
            {
                destroyerDisplay.text = "Equip";
            }
            
        }
    }

    public void ResetPoints()
    {
        points = 0;
        PlayerPrefs.SetFloat("points", 0);
        pointDisplay.text = "Points: " + Mathf.Round(points);
    }

    public void ResetPurchases()
    {
        PlayerPrefs.SetInt("areRocketsBought", 0);
        PlayerPrefs.SetInt("isWideshotBought", 0);
        PlayerPrefs.SetInt("isFrigateBought", 0);
        PlayerPrefs.SetInt("isCruiserBought", 0);
        PlayerPrefs.SetInt("isCarrierBought", 0);
        PlayerPrefs.SetInt("isDestroyerBought", 0);

        areRocketsBought = 0;
        isWideshotBought = 0;

        isFrigateBought = 0;
        isCruiserBought = 0;
        isCarrierBought = 0;
        isDestroyerBought = 0;

        isCorvetteEquipped = true;
        isDestroyerSelected = false;
        isCarrierSelected = false;
        isCruiserSelected = false;
        isFrigateSelected = false;

        rocketPriceDisplay.text = "Buy - " + rocketPrice;
        wideshotPriceDisplay.text = "Buy - " + wideshotPrice;

        corvetteDisplay.text = "Equipped!";
        frigateDisplay.text = "Buy - " + frigatePrice;
        cruiserDisplay.text = "Buy - " + cruiserPrice;
        carrierDisplay.text = "Buy - " + carrierPrice;
        destroyerDisplay.text = "Buy - " + destroyerPrice;
    }

    public void DebugPoints()
    {
        points += 9999;
        PlayerPrefs.SetFloat("points", points);
        pointDisplay.text = "Points: " + Mathf.Round(points);
    }

}

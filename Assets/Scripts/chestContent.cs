using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestContent : MonoBehaviour
{
    float distanceToPlayer;
    string[] itemList = {"Robe",
                        "Helmet",
                        "Wand",
                        "Sword",
                        "Shoes",
                        "Pants",
                        "Shirt",
                        "Lollipop",
                        "Sandwich",
                        "Chicken Nuggets",
                        "Pizza"};
                        
    string[] sufficList = {"",
                           " of Wisdom",
                           " of Power",
                           " of Love",
                           " of Weakness",
                           " of Fire",
                           " of Water",
                           " of Magic",
                           " of Darkness",
                           " of Doom"};

    void Start()
    {
        Vector3 placeOfTxt = transform.position;
        placeOfTxt.y += 0.5f;
        GameObject inventoryText = GameObject.Instantiate(Resources.Load("InvText"), placeOfTxt, Quaternion.identity) as GameObject;
        inventoryText.transform.SetParent(GameObject.Find("WorldCanvas").transform, false);
        inventoryText.GetComponent<Text>().text = GenContent();
        }

    void Update()
    {
    }    

    string GenContent(){
        string theContent = "";
        string newItem = "";
        int numberOfItems = 0;
        int prefixChance = 0;
        int whichItem = 0;
        int whichSuffix = 0;
        numberOfItems = Random.Range(1,8);
        for (int i = 0; i < numberOfItems; i++)
        {
            newItem = "";

            prefixChance = Random.Range(1,101);
            if(prefixChance<10){
                newItem += "Legendary ";
            }
            else if(prefixChance>=10 && prefixChance<35){
                newItem += "Epic ";
            }
            else if(prefixChance>=35 && prefixChance<65){
                newItem += "";
            }
            else if(prefixChance>=65){
                newItem += "Noob ";
            }

            whichItem = Random.Range(1,itemList.Length + 1);
            newItem += itemList[whichItem];

            whichSuffix = Random.Range(1,sufficList.Length + 1);
            newItem += sufficList[whichSuffix];

            newItem += "\n";

            theContent += newItem;            
        }

        theContent = theContent.Substring(0,theContent.Length-1);
        return theContent;
    }
}

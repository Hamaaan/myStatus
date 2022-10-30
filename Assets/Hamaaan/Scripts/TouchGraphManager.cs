using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System; //DateTimeを使用する為追加。

public class TouchGraphManager : MonoBehaviour, IDragHandler, IDropHandler, IPointerEnterHandler
{
    public Color color;

    public Color moodColor;
    public Color actionColor;
    public Color conditionColor;
    public Color stickerColor;

    Image rend;

    [SerializeField] Dropdown dropdown1;
    [SerializeField] Dropdown dropdown2;
    [SerializeField] Dropdown dropdown3;
    [SerializeField] Dropdown dropdown4;

    [SerializeField] Image PickedColor;

    private void Start()
    {
        rend = GetComponent<Image>();
        PickedColor = PickedColor.GetComponent<Image>();

        dropdown1 = dropdown1.GetComponent<Dropdown>();
        dropdown2 = dropdown2.GetComponent<Dropdown>();
        dropdown3 = dropdown3.GetComponent<Dropdown>();
        dropdown4 = dropdown4.GetComponent<Dropdown>();

        //ブロックの番地を名前に割り当て
        transform.name = transform.parent.GetSiblingIndex().ToString() + transform.GetSiblingIndex().ToString("D2");

        blockDataSave();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        color = PickedColor.color;

        if (Input.GetMouseButton(0))
        {
            rend.color = color;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        //rend.color = col;

        //Debug.Log("drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Destroy(gameObject);

        //Debug.Log("drop");
    }

    //ブロックデータのロード/セーブ

    public string keyname = null;
    public string blockData = null;

    public void blockDataSave()
    {
        DateTime timestamp = DateTime.Now;

        keyname = timestamp.Year.ToString() + timestamp.Month.ToString("D2") + timestamp.Day.ToString("D2") + this.gameObject.name;



        dropdown1.captionText.text = "a";


        blockData = "02,01,03,00";

        Debug.Log(keyname + " : " + blockData);

        //Debug.Log(timestamp.TimeOfDay.ToString().Substring(0,5));
    }

    void OnDestroy()
    {
        // blockData_(番地)　というキーでblockDataを格納
        PlayerPrefs.SetString("blockData_" + this.gameObject.name, keyname);
        PlayerPrefs.Save();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private bool _active;
    [SerializeField] public int count = 0;
    private Transform _button;
    public string text;
    public string itemName;

    public void SetText()
    {
        if (count > 1)
            text = count.ToString();
        else
            text = "";

        if (count == 0)
            _button.gameObject.SetActive(false);
        else
        {
            _button.gameObject.SetActive(true);
            transform.GetComponentInChildren<Text>().text = text;
        }
    }
    public void SetSprite(Sprite _sprite)
    {
        _button.gameObject.GetComponent<Image>().sprite = _sprite;
            //gameObject.GetComponentInChildren<Image>().sprite = _sprite;
    }

    public void Delete()
    {
        _active = false;
        count = 0;
        text = "";
        itemName = "";
        SetText();
    }

    void Start()
    {
        _button = transform.GetChild(0);
        _button.gameObject.SetActive(_active);
        text = _button.GetChild(0).GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

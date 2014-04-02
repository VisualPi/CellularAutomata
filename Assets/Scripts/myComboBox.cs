using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class myComboBox : MonoBehaviour {
    private List<string> listItems;
    private Rect m_box;
    private string m_selectedItem;
    private bool m_editing;

    public myComboBox(Rect box)
    {
        listItems = new List<string>();
        m_box = new Rect(box);
        m_selectedItem = "None";
        m_editing = false;
    }

    private void OnGUI()
    {
        if (GUI.Button(m_box, m_selectedItem))
            m_editing = true;

        if (m_editing)
            for(int x = 0; x<listItems.Count; x++)
                if (GUI.Button(new Rect(m_box.x, (m_box.height*x)+m_box.y+m_box.height,m_box.width, m_box.height), listItems[x])){
                    m_selectedItem = listItems[x];
                    m_editing = false;
                }
    }

    public void addItemToList(string str){
        listItems.Add(str);
    }

    public void removeItemToList(int index)
    {
        listItems.RemoveAt(index);
    }

    public void removeItemToList(string str)
    {
        listItems.Remove(str);
    }

    public void clearList()
    {
        listItems.Clear();
    }

    public List<string> getList()
    {
        return listItems;
    }

    public void setBox(Rect Box)
    {
        m_box = Box;
    }

    public void setHeightBox(int height)
    {
        m_box.height = height;
    }

    public void setWidthBox(int width)
    {
        m_box.width = width;
    }

    public void setposXBox(int posX)
    {
        m_box.x = posX;
    }

    public void setposYBox(int posY)
    {
        m_box.y = posY;
    }
}

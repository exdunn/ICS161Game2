using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public Sprite[] healthSprites;

    private float healthBarLen;

	// Use this for initialization
	void Start () {
        healthBarLen = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
        AdjustCurHealth(0);
	}

    void OnGUI()
    {
        //GUI.Box (new Rect (Screen.width / 4, 10, healthBarLen, 25), curHealth + "/" + maxHealth);
        Vector2 size = GetSpriteSize();

        GUI.DrawTextureWithTexCoords(
            new Rect(Screen.width / 8, Screen.height - Screen.height / 4, size.x * 1.5f, size.y * 1.5f),
            healthSprites[GetSpriteIndex()].texture, GetSpriteRect(healthSprites[GetSpriteIndex()])
            );
    } 

    public void AdjustCurHealth (int adj)
    {
        curHealth += adj;
        if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        healthBarLen = (Screen.width / 2) * (curHealth / (float) maxHealth);
    }

    private Rect GetSpriteRect (Sprite s)
    {
        Texture t = s.texture;
        Rect tr = s.textureRect;
        Rect r = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);
        return r;
    }

    private int GetSpriteIndex ()
    {
        int index = 4;
        if (curHealth >= 90)
            index = 0;
        else if (curHealth >= 60)
            index = 1;
        else if (curHealth >=30)
            index = 2;
        else if (curHealth >= 1)
            index = 3;
        return index;

        float healthPercent = (float)(curHealth + 10) / (float)maxHealth;
        int damage = 5 - (int)(healthPercent * 5);
        return damage < 5 ? damage : 4;
    }

    private Vector2 GetSpriteSize()
    {
        Sprite sprite = healthSprites[0];
        return new Vector2(sprite.rect.width, sprite.rect.height);
    }
}

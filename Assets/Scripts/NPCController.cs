﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class NPCController : MonoBehaviour {

    public BehaviourScript behaviour;
    public bool alwaysDead = false;
    private bool is_dead = false;
    private bool deathFlag = false;

    public bool IsDead
    {
        get
        {
            return is_dead;
        }

        set
        {
            is_dead = value;
        }
    }

    // Use this for initialization
    void Start () {
		if(alwaysDead)
        {
            is_dead = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        if (is_dead && !deathFlag)
        {
            deathFlag = true;
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
            //sr.sprite = deadSprite; // Change to the Dead Sprite

            Vector2 s = sr.sprite.bounds.size;
            bc.size = s;
            //bc.offset = new Vector2((s.x / 2), 0);
            bc.isTrigger = true;

            if(!alwaysDead)
            {
                transform.Rotate(new Vector3(0, 0, 90));
            }
        } else if (behaviour != null)
        {
            behaviour.updateHook();
        }
	}
}


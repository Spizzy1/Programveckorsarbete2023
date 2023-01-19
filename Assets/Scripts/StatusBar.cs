using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [Range(0f,1f)]
    public float fillPercentage;
    
    [Range(0f,10f)]
    public float test;
    
    [Header("References")] 
    [SerializeField]
    private Transform icon;
    [SerializeField]
    private Transform bar;
    [SerializeField]
    private Transform barFill;

    private Animator animator;

    private PlayerHealth health;

    private bool done = false;
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            health = GameManager.player.GetComponent<PlayerHealth>();   
            
        
        fillPercentage = ((float)health.GetHP())/5f;
        print(health.GetHP());
        animator.SetFloat("Fill", fillPercentage);
       // barFill.localScale = new Vector3(fillPercentage * bar.localScale.x,  bar.localScale.y, 1);
       // barFill.localPosition = new Vector2(fillPercentage * (bar.localPosition.x/test), 0);
        
    }


    void MakeDay()
    {
        
    }
}

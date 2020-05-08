using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroy : MonoBehaviour
{

     public static int score1=0;
     public static int score2=0;
     public Text Score1;
     public Text Score2;
     public Text win;
     public GameObject b1;
     public GameObject b2;

    // Start is called before the first frame update 
    void Start()
    {
        b1= GameObject.Find("Ball1");
    }

    // Update is called once per frame 
    void Update()
    {
    Score1.text="Player 1: "+score1;
    Score2.text="Player 2: "+score2;

    if(Input.GetKey(KeyCode.Escape))
        {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        }
    }


    void OnCollisionEnter(Collision collision){
         // Destroy(collision.collider.gameObject);



         if(collision.gameObject.name=="Ball1")
         {
         collision.gameObject.transform.localScale += new Vector3(-0.25f , -0.25f , -0.25f);
         if(score1+score2==9){
         score1++;
          
        // b1.gameObject.transform.localScale += newVector3(5,5,5);
         Score1.text="Player 1: "+score1;
    Score2.text="Player 2: "+score2;


    if(score1>score2){
    win.text="Player 1 win";
     
    
    }
    else if(score2>score1){
    
    win.text="Player 2 win";
    }
    else{
    
    win.text="Draw!!";
    }
      //  UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
         }


         score1++;
        Destroy(gameObject);
         
        // Debug.Log("score 1 : "+score1);
         }

         if(collision.gameObject.name=="Ball2")
         {
         collision.gameObject.transform.localScale += new Vector3(-0.25f , -0.25f , -0.25f);
         if(score1+score2==9){
         score2++;
         Score1.text="Player 1: "+score1;
    Score2.text="Player 2: "+score2;
       // UnityEditor.EditorApplication.isPlaying = false;
         //Application.Quit();

         if(score1>score2){
    win.text="Player 1 win";
    }
    else if(score2>score1){
    win.text="Player 2 win";
    }
    else{
    win.text="Draw!!";
    }
         }
         score2++;
         Destroy(gameObject);
         
         
        // Debug.Log("score 2 : "+score2);
         }

         
          
          }
}

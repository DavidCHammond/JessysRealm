using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JessyLives : MonoBehaviour
{
    public static int jessyLives = 9;
    public int levelSelect;
    public int HELL;
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        //respawnLives = jessyLives;
    }

    // Update is called once per frame
    void Update()
    {
        Lives();
        if(PlayerMovement.hasDied)
        {
            Debug.Log("Jessy has " + jessyLives + " lives.");
        }
    }
    public void Lives()
    {
        if(jessyLives == 9)
        {
            anim.SetBool("nine", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
        }
        if (jessyLives == 8)
        {
            anim.SetBool("eight", true);
            anim.SetBool("nine", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 7)
        {
            anim.SetBool("seven", true);
            anim.SetBool("eight", false);
            anim.SetBool("nine", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 6)
        {
            anim.SetBool("six", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("nine", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 5)
        {
            anim.SetBool("five", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("nine", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 4)
        {
            anim.SetBool("four", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("nine", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 3)
        {
            anim.SetBool("three", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("nine", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 2)
        {
            anim.SetBool("two", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("nine", false);
            anim.SetBool("one", false);
            
        }
        if (jessyLives == 1)
        {
            anim.SetBool("one", true);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("nine", false);
            
        }
        if (jessyLives == 0)
        {
            jessyLives = 9;
            anim.SetBool("one", false);
            anim.SetBool("eight", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("nine", false);
            anim.SetBool("zero", true);
            SceneManager.LoadScene(levelSelect);
            PlayerMovement.IsInputEnabled = true;
        }
    }
}

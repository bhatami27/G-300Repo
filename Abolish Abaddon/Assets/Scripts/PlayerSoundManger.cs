using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManger : MonoBehaviour
{


    public static AudioClip playerJump, playerFalling, playerSword, playerSwordReject, playerDeath, enemyDeath, playerWalking, playerLand, playerHit;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerJump = Resources.Load<AudioClip> ("playerJump");
        playerFalling = Resources.Load<AudioClip>("playerFallin");
        playerSword = Resources.Load<AudioClip>("playerSword");
        playerSwordReject = Resources.Load<AudioClip>("playerSwordReject");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerWalking = Resources.Load<AudioClip>("playerWalking");
        playerLand = Resources.Load<AudioClip>("playerLand");
        enemyDeath = Resources.Load<AudioClip>("enemyDeath");
        playerHit = Resources.Load<AudioClip>("playerHit");

        audioSrc = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update()
    {
          
        
    }

    public static void PlayerSound(string clip)
    {
        switch (clip){
            case "enemyDeath":
                audioSrc.PlayOneShot (enemyDeath);
                break;
            case "playerLand":
                audioSrc.PlayOneShot (playerLand);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot (playerDeath);
                break;
            case "playerSword":
                audioSrc.PlayOneShot (playerSword);
                break;
            case "playerSwordReject":
                audioSrc.PlayOneShot (playerSwordReject);
                break;
            case "playerJump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHit);
                break;

        }

    }
}

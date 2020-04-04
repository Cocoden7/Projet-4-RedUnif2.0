using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Gère toutes les collisions du joueur, ses mouvements (clavier), sa mort, la collecte de crédits, lance le niveau suivant lorsque nécessaire

public class StagePlayerBehavior : PlayerBehavior
{
    /*
    Fonction qui gère le ramassage des pièces ainsi que la fin du niveau (quand on a assez de pièces)
    */
    void AddCredit(int nb = 1)
    {
    	nbCredit = nbCredit + nb;
    }

    void SetUINextLevel()
    { }
    
    void Dead(string mort = "")
    {

        if (ST.tag == "PlayerElec" && mort == "elsecTrap")
        {
            print("Les gens en elec ne craignent pas l'electricite");
        }
        else if (ST.tag == "PlayerGBio" && mort == "ennemis")
        {
            print("Les gens en GBio connaissent les points faibles de l'anatomies des profs et sont à même de les mettre KO");
        }
        else if (ST.tag == "PlayerGC" && mort == "trou")
        {
            print("Les gens en GC ne tombent pas dans les trous du bâtiment");
        }
        else if (ST.tag == "PlayerInfo" && mort == "canon")
        {
            print("Les gens en Info ne craignent pas les canons, car ils peuvent les pirater");
        }
        else
        {
            PlayerPrefs.SetInt("CreditsStage", (PlayerPrefs.GetInt("CreditsStage", 0) + nbCredit));
            dead = true;
            print("La mort est due à un(e) " + mort);
            FindObjectOfType<DeadMenu>().SendMessageUpwards(mort, SendMessageOptions.DontRequireReceiver);
        }
    }

}
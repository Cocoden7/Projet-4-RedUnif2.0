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
    
}
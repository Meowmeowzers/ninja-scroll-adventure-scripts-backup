using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Weapon")]
public class Weapon : ScriptableObject
{
   [SerializeField] AttackType attack;

   public void Execute(Stats stats){
      attack.Execute(stats);
   }
}

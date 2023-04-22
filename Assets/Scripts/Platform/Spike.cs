using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// º‚¥Ã∂‘œÛΩ≈±æ
/// </summary>
public class Spike : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out PlayerController player))
      {
         player.OnDefeated();
      }
   }
}

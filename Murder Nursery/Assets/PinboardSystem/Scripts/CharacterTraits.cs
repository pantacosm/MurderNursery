using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/New Character")]
public class CharacterTraits : ScriptableObject
{
    public string characterName;
    public List<string> likes;
    public List<string> dislikes;
}

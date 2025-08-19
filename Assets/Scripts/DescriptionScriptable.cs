using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Desc", menuName = "Scriptable Objects/DescriptionScriptable")]
public class DescriptionScriptable : ScriptableObject
{
    public Sprite image;
    [TextArea(3, 10)] public String descText;
}

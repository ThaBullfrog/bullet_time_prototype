using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterInput
{
    Vector2 move { get; }
    Vector2 lookTarget { get; }
    bool shooting { get; }
}
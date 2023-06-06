using System;
using UnityEngine;

namespace AI.Memory
{
    public enum Factor
    {
        Player,
        StrangeSound,
        PlayerHided
    }

    [Serializable]
    public struct FactorInfo
    {
        public Factor Factor;
        public Transform SourceTransform;
        public PlaceForHide PlaceForHide;
    }
}

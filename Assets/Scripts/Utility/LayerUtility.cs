using UnityEngine;

public static class LayerUtility
{
    public static LayerMask PlayerLayer = LayerMask.NameToLayer("Player");
    public static LayerMask GroundedLayer = LayerMask.NameToLayer("Ground");
    public static LayerMask ItemLayer = LayerMask.NameToLayer("Item");
    public static LayerMask ObstacleLayer = LayerMask.NameToLayer("Obstacle");
}
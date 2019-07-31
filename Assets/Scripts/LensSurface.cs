using UnityEngine;

public class LensSurface {

    public enum Type {
        CONCAVE,
        CONVEX,
        PLANAR
    }

    public Type type { get; private set; }
    public float radius { get; private set; }   //for planar this should be infinity
    public float extent { get; private set; }   //only applies to concave surfaces

    public LensSurface (Type type, float radius, float extent) {
        this.type = type;
        this.radius = radius;
        this.extent = extent;
    }
	
}

using UnityEngine;

public struct Range {

	public readonly float bound1, bound2;

	public float span => Mathf.Abs(bound1 - bound2);
	public float lowerBound => Mathf.Min(bound1, bound2);
	public float upperBound => Mathf.Max(bound1, bound2);

	public float this[int index] {
		get {
			if(index == 0) return bound1;
			if(index == 1) return bound2;
			throw new UnityException("Invalid Index \"" + index.ToString() + "\", only 0 or 1 allowed!");
		}
	}

	public Range (float bound1, float bound2) {
		this.bound1 = bound1;
		this.bound2 = bound2;
	}

	public bool Contains (float value) {
		float maxDelta = Mathf.Max(Mathf.Abs(bound1 - value), Mathf.Abs(bound2 - value));
		return (maxDelta <= this.span); 
	}

	public override string ToString () {
		float min = Mathf.Min(bound1, bound2);
		float max = Mathf.Max(bound1, bound2);
		return $"[{min:F2}, {max:F2}]";
	}
	
}

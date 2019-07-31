public struct LensCreationParameters {

    public LensSurface frontSurface { get; private set; }
    public LensSurface rearSurface { get; private set; }
    public float refractiveIndex { get; private set; }
    public float thickness { get; private set; }
    public float desiredRadius { get; private set; }
	
}

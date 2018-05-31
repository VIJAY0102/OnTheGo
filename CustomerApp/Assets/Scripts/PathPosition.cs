[System.Serializable]
public class PathPosition{
	public float x;
	public float y;
	public float z;
	public override string ToString() {
		return x + ", " + y + ", " + z;
	}
}

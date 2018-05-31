using System.Collections.Generic;

[System.Serializable]
public class ShortestPathModel {
	public List<ShortestPathBaseModel> __Mappings__;
}

[System.Serializable]
public class ShortestPathBaseModel {
	public PathPosition seeker;
	public PathPosition target;
}
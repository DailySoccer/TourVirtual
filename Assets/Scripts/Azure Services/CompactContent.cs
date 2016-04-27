using System.Collections.Generic;

public class CompactContent {
	public int ASSET_TYPE_PHOTO = 0;
	public int ASSET_TYPE_VIDEO = 1;
	public int ASSET_TYPE_CONTENT_TITLE_IMAGE = 2;

	public string IdContent;
	public string Type;
	public string Title;
	public string Description;
    public Dictionary<string, object> Asset = new Dictionary<string, object>();
	public string CreationDate;
	public List<object> Links = new List<object>();
	public string PublishedDate;
	public int OrderInDay;
	public bool HighLight;
	public int OrderInHighLight;
	public bool Visible;
	public string LinkId;

	public bool IsImage {
		get {
			return AssetType == ASSET_TYPE_PHOTO || AssetType == ASSET_TYPE_CONTENT_TITLE_IMAGE;
		}
	}

	public string AssetUrl {
		get {
			return Asset["AssetUrl"] as string;
		}
	}

	public string ThumbnailUrl {
		get {
			return Asset["ThumbnailUrl"] as string;
		}
	}

	public int AssetType {
		get {
			return (int) Asset["Type"];
		}
	}

	private void initFromJSON(object json) {
		if (json is Dictionary<string, object>) {
            Dictionary<string, object> jsonMap = json as Dictionary<string, object>;
			
			IdContent = jsonMap["IdContent"] as string;
			Type = jsonMap["Type"] as string;
			Title = jsonMap["Title"] as string;
			Description = jsonMap["Description"] as string;

			Asset = jsonMap["Asset"] as Dictionary<string, object>;
		}
	}
	
	public override string ToString() {
		return string.Format("CompactContent: IdContent: {0} - Type: {1} - Title: {2} - Description: {3}", IdContent, Type, Title, Description);
	}
	
	static public CompactContent LoadFromJSON(object json) {
		CompactContent compactContent = new CompactContent();
		compactContent.initFromJSON(json);
		return compactContent;
	}
}

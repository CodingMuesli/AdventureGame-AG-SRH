namespace AdventureGame_AG;

public class Scene {
	public readonly long Id;
	private static long _lastId = 0;
	public List<string> CurrentFlags = new List<string>();
	private Object _backgroundImage = "TODO";
	public string Title;

	public Scene(string title) {
		this.Id = Scene._lastId++;
		this.Title = title;
	}
}
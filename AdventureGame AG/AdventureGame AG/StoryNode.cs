namespace AdventureGame_AG;

public class StoryNode {
	public readonly long Id;
	private long _parentId;
	private static long _lastId = 0;
	public readonly string Message;
	private readonly List<ProgressOption> _options;
	public readonly Scene Room;
	private readonly List<string> RequiredFlags;
	public int ChildrenDepth;

	public StoryNode(string message, List<ProgressOption> options, Scene scene) {
		this.Id = StoryNode._lastId++;
		this.Message = message;
		this._options = options;
		this.Room = scene;
		this.ChildrenDepth = 0;
		foreach (ProgressOption option in options) {
			option.Node.SetParentNode(this.Id);
			if (option.Node.ChildrenDepth >= this.ChildrenDepth) {
				this.ChildrenDepth = option.Node.ChildrenDepth + 1;
			}
		}
	}

	public void SetParentNode(long id) {
		this._parentId = id;
	}

	public List<string> GetOptions(List<string> flags) {
		List<string> optionStrings = new List<string>();
		foreach (ProgressOption option in this._options) {
			if (option.IsAvailable(flags)) {
				optionStrings.Add(option.Message);
			}
		}
		return optionStrings;
	}

	public StoryNode? ChooseOption(int optionId) {
		if (optionId < 0 || optionId > this._options.Count) return null;
		return this._options[optionId].Node;
	}
	
	public bool IsAvailable(List<string> currentFlags) {
		foreach (string flag in this.RequiredFlags ) {
			if (!currentFlags.Contains(flag)) return false;
		}
		return true;
	}
}
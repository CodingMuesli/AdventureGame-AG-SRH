namespace AdventureGame_AG;

public class ProgressOption {
	public readonly string Message;
	public readonly StoryNode Node;
	public readonly List<string> RequiredFlags;

	public ProgressOption(string message, StoryNode node, List<string> requiredFlags) {
		this.Message = message;
		this.Node = node;
		this.RequiredFlags = requiredFlags;
	}

	public bool IsAvailable(List<string> currentFlags) {
		return this.Node.IsAvailable(currentFlags);
	}
	
}
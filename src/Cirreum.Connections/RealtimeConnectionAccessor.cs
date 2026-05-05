namespace Cirreum.Connections;

/// <summary>
/// Default <see cref="AsyncLocal{T}"/>-backed implementation of <see cref="IRealtimeConnectionAccessor"/>.
/// Transport adapters call <see cref="SetConnection"/> and <see cref="ClearConnection"/>
/// to manage the ambient scope; consumers read via <see cref="Connection"/>.
/// </summary>
public sealed class RealtimeConnectionAccessor : IRealtimeConnectionAccessor {

	private static readonly AsyncLocal<IRealtimeConnection?> _current = new();

	/// <inheritdoc />
	public IRealtimeConnection? Connection => _current.Value;

	/// <inheritdoc />
	public void SetConnection(IRealtimeConnection connection) => _current.Value = connection;

	/// <inheritdoc />
	public void ClearConnection() => _current.Value = null;

}
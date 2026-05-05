namespace Cirreum.Connections;

/// <summary>
/// Ambient accessor for the current <see cref="IRealtimeConnection"/>.
/// Returns <c>null</c> outside an active connection scope.
/// </summary>
public interface IRealtimeConnectionAccessor {

	/// <summary>Gets the current connection, or <c>null</c> if none is active.</summary>
	IRealtimeConnection? Connection { get; }

	/// <summary>Set the ambient connection for the current async flow.</summary>
	void SetConnection(IRealtimeConnection connection);

	/// <summary>Clear the ambient connection for the current async flow.</summary>
	void ClearConnection();

}

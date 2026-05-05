namespace Cirreum.Connections;

/// <summary>
/// App-side hook invoked by the transport adapter at connection lifecycle boundaries.
/// <para>
/// <see cref="OnConnectedAsync"/> runs immediately after the connection is established
/// and <c>HttpContext.Items</c> have been copied onto <c>connection.Items</c>.
/// Return <c>false</c> to reject the connection (transport adapter aborts the upgrade).
/// </para>
/// </summary>
public interface IConnectionAuthLifecycle {

	/// <summary>
	/// Called after upgrade completes and identity context has been copied to the connection.
	/// Return <c>false</c> or throw to reject the connection.
	/// </summary>
	ValueTask<bool> OnConnectedAsync(IRealtimeConnection connection, CancellationToken cancellationToken);

	/// <summary>
	/// Called after the transport detects a disconnect, before connection resources are disposed.
	/// Exceptions are absorbed by the framework.
	/// </summary>
	ValueTask OnDisconnectedAsync(IRealtimeConnection connection, CancellationToken cancellationToken);

}

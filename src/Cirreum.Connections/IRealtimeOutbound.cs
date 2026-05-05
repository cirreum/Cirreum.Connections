namespace Cirreum.Connections;

/// <summary>
/// Server-initiated push over the active connection. Fire-and-forget; no expected response.
/// <para>
/// Safe to call from multiple producers concurrently. Within a single producer, sends
/// preserve issue order. Across producers, ordering is unspecified.
/// </para>
/// </summary>
public interface IRealtimeOutbound {

	/// <summary>Send a payload over the current connection.</summary>
	ValueTask SendAsync<T>(T payload, CancellationToken cancellationToken = default);

}

namespace Cirreum.Connections;

/// <summary>
/// Well-known keys for <see cref="IRealtimeConnection.Items"/> slots managed by the
/// Connections framework. Parallel to <c>AuthenticationContextKeys</c> in Cirreum.Core
/// (which defines the HTTP-side keys); the same values are used so feature code that
/// reads these keys works identically against both bags.
/// </summary>
public static class ConnectionContextKeys {

	/// <summary>Key for the <see cref="IRealtimeOutbound"/> instance bound to this connection.</summary>
	public const string Outbound = "__Cirreum_Connection_Outbound";

	/// <summary>Key for the application name captured from the upgrade request.</summary>
	public const string AppName = "__Cirreum_Connection_AppName";

	/// <summary>Key for the connection's transport identifier (e.g. "signalr", "websockets").</summary>
	public const string TransportName = "__Cirreum_Connection_Transport";

}

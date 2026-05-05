# Changelog

All notable changes to **Cirreum.Connections** will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased

### Added

- `IRealtimeConnection` — per-connection state (ConnectionId, User, Items, ConnectedAtUtc, Transport)
- `IRealtimeInvocation` — per-message state (Connection, Items, Services, Aborted)
- `IRealtimeConnectionAccessor` — AsyncLocal-backed ambient connection accessor
- `IRealtimeInvocationAccessor` — AsyncLocal-backed ambient invocation accessor
- `IConnectionAuthLifecycle` — App-side connect/disconnect hook for identity resolution
- `IRealtimeOutbound` — server-initiated fire-and-forget push primitive
- `ConnectionContextKeys` — well-known `Items` keys for connection-bag slots
- `RealtimeConnectionAccessor` — default AsyncLocal-backed implementation
- `RealtimeInvocationAccessor` — default AsyncLocal-backed implementation

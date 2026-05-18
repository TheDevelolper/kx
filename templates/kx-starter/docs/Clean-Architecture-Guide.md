# Clean Architecture Layers

## Domain

### Entities
Core business objects with identity and business rules.

Examples:

```csharp
User
Order
Invoice
Subscription
```

### Value Objects
Immutable objects representing concepts without identity.

Examples:

```csharp
EmailAddress
Money
UserId
DateRange
```

### Domain Services
Business logic that does not naturally belong to a single entity.

Examples:

```csharp
PricingCalculator
TaxCalculator
SubscriptionPolicy
```

### Repository Interfaces
Abstractions for persistence required by the domain/application.

Examples:

```csharp
UserRepository
OrderRepository
InvoiceRepository
```

### Domain Events
Business events that occurred in the domain.

Examples:

```csharp
UserRegistered
OrderPlaced
InvoicePaid
```

### Specifications / Policies
Reusable business rules and validation policies.

Examples:

```csharp
PasswordPolicy
DiscountEligibilityPolicy
```

---

## Application

### Commands / Command Handlers
Write operations.

Examples:

```csharp
RegisterUser
CreateOrder
CancelSubscription
UpdateProfile
```

### Queries / Query Handlers
Read operations.

Examples:

```csharp
GetUserById
ListOrders
SearchProducts
GetInvoiceSummary
```

### Ports / Interfaces
Abstractions the application needs, implemented by infrastructure.

Examples:

```csharp
PasswordHasher
EmailSender
PaymentGateway
UnitOfWork
CacheProvider
```

### DTOs / Contracts
Input and output shapes for use cases.

Examples:

```csharp
RegisterUserCommand
RegisterUserResult
GetUserByIdQuery
GetUserByIdResult
```

### Validators
Application-level validation before running a use case.

Examples:

```csharp
Required fields
Password length
Permission checks
```

### Mappers
Translate between domain objects, DTOs, and read models.

### Behaviours / Pipeline
Cross-cutting logic around handlers.

Examples:

```csharp
Validation
Authorization
Transactions
Logging
Retries
Metrics
```

### Application Services
Shared workflow logic used by multiple use cases.

### Application Event Handlers
React to application/domain events.

Examples:

```csharp
SendWelcomeEmail
GenerateAuditLog
PublishIntegrationEvent
```

---

## Infrastructure

### Persistence
Database implementations and ORM integrations.

Examples:

```csharp
PrismaUserRepository
TypeOrmOrderRepository
MongoInvoiceRepository
```

### External Services
Integrations with third-party systems.

Examples:

```csharp
StripePaymentGateway
SendGridEmailSender
TwilioSmsSender
```

### Security
Authentication, hashing, encryption, and authorization implementations.

Examples:

```csharp
BcryptPasswordHasher
JwtTokenGenerator
```

### Messaging
Queues, event buses, and message brokers.

Examples:

```csharp
KafkaEventBus
RabbitMqPublisher
```

### Storage
File and blob storage implementations.

Examples:

```csharp
S3FileStorage
AzureBlobStorage
```

### Caching
Cache implementations.

Examples:

```csharp
RedisCacheProvider
MemoryCacheProvider
```

### Logging / Monitoring
Infrastructure-level observability.

Examples:

```csharp
SerilogLogger
OpenTelemetryTracing
```

### Infrastructure Event Handlers
Technical/integration event processing.

Examples:

```csharp
StripeWebhookHandler
KafkaConsumer
```

---

## Presentation

### Controllers / Endpoints
HTTP/API entry points.

Examples:

```csharp
UsersController
OrdersController
```

### Routes
Route registration and endpoint definitions.

### Request DTOs
Incoming request shapes.

Examples:

```csharp
RegisterUserRequest
CreateOrderRequest
```

### Response DTOs
Outgoing response shapes.

Examples:

```csharp
UserResponse
OrderSummaryResponse
```

### Middleware
HTTP pipeline behaviours.

Examples:

```csharp
AuthenticationMiddleware
ErrorHandlingMiddleware
RequestLoggingMiddleware
```

### GraphQL Resolvers
GraphQL entry points.

### CLI Commands
Command-line entry points.

### WebSocket Handlers
Realtime communication handlers.

---

## Composition Root

### Dependency Injection / Wiring
Application startup and dependency registration.

Examples:

```csharp
Container configuration
Service registration
Handler registration
```

### Configuration
Environment and application configuration.

Examples:

```csharp
Database config
API keys
Feature flags
```

### Bootstrap / Startup
Application initialization.

Examples:

```csharp
HTTP server startup
Database migration startup
Queue initialization
```
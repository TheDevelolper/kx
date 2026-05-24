# Clean Architecture Layers

## Domain

### Entities

Core business objects with identity and business rules.

_Examples:_

```csharp
User
Order
Invoice
Subscription
```

### Value Objects

Immutable objects representing concepts without identity.

_Examples:_

```csharp
EmailAddress
Money
UserId
DateRange
```

### Domain Services

Business logic that does not naturally belong to a single entity.

_Examples:_

```csharp
PricingCalculator
TaxCalculator
SubscriptionPolicy
```

### Repository Interfaces

Abstractions for persistence required by the domain/application.

_Examples:_

```csharp
UserRepository
OrderRepository
InvoiceRepository
```

### Domain Events

Business events that occurred in the domain.

_Examples:_

```csharp
UserRegistered
OrderPlaced
InvoicePaid
```

### Specifications / Policies

Reusable business rules and validation policies.

_Examples:_

```csharp
PasswordPolicy
DiscountEligibilityPolicy
```

---

## Application

### Commands / Command Handlers

Write operations.

_Examples:_

```csharp
RegisterUser
CreateOrder
CancelSubscription
UpdateProfile
```

### Queries / Query Handlers

Read operations.

_Examples:_

```csharp
GetUserById
ListOrders
SearchProducts
GetInvoiceSummary
```

### Ports / Interfaces

Abstractions the application needs, implemented by infrastructure.

_Examples:_

```csharp
PasswordHasher
EmailSender
PaymentGateway
UnitOfWork
CacheProvider
```

### DTOs / Contracts

Input and output shapes for use cases.

_Examples:_

```csharp
RegisterUserCommand
RegisterUserResult
GetUserByIdQuery
GetUserByIdResult
```

### Validators

Application-level validation before running a use case.

_Examples:_

```csharp
Required fields
Password length
Permission checks
```

### Mappers

Translate between domain objects, DTOs, and read models.

### Behaviours / Pipeline

Cross-cutting logic around handlers.

_Examples:_

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

_Examples:_

```csharp
SendWelcomeEmail
GenerateAuditLog
PublishIntegrationEvent
```

---

## Infrastructure

### Persistence

Database implementations and ORM integrations.

_Examples:_

```csharp
PrismaUserRepository
TypeOrmOrderRepository
MongoInvoiceRepository
```

### External Services

Integrations with third-party systems.

_Examples:_

```csharp
StripePaymentGateway
SendGridEmailSender
TwilioSmsSender
```

### Security

Authentication, hashing, encryption, and authorization implementations.

_Examples:_

```csharp
BcryptPasswordHasher
JwtTokenGenerator
```

### Messaging

Queues, event buses, and message brokers.

_Examples:_

```csharp
KafkaEventBus
RabbitMqPublisher
```

### Storage

File and blob storage implementations.

_Examples:_

```csharp
S3FileStorage
AzureBlobStorage
```

### Caching

Cache implementations.

_Examples:_

```csharp
RedisCacheProvider
MemoryCacheProvider
```

### Logging / Monitoring

Infrastructure-level observability.

_Examples:_

```csharp
SerilogLogger
OpenTelemetryTracing
```

### Infrastructure Event Handlers

Technical/integration event processing.

_Examples:_

```csharp
StripeWebhookHandler
KafkaConsumer
```

---

## Presentation

### Controllers / Endpoints

HTTP/API entry points.

_Examples:_

```csharp
UsersController
OrdersController
```

### Routes

Route registration and endpoint definitions.

### Request DTOs

Incoming request shapes.

_Examples:_

```csharp
RegisterUserRequest
CreateOrderRequest
```

### Response DTOs

Outgoing response shapes.

_Examples:_

```csharp
UserResponse
OrderSummaryResponse
```

### Middleware

HTTP pipeline behaviours.

_Examples:_

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

_Examples:_

```csharp
Container configuration
Service registration
Handler registration
```

### Configuration

Environment and application configuration.

_Examples:_

```csharp
Database config
API keys
Feature flags
```

### Bootstrap / Startup

Application initialization.

_Examples:_

```csharp
HTTP server startup
Database migration startup
Queue initialization
```

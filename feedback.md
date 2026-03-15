# Feedback til Mikkel - Airport Information System

Virkelig flot arbejde med dit mini-projekt! Du har tænkt ud af boksen med din arkitektur, især med brugen af middleware og topics.

## ASP.NET Core Web API
- **Endpoints:** Dine CRUD-operationer i `FlightController` er gode og følger REST-principperne. Det er smart med en `random`-rute til hurtig test-data!
- **Arkitektur:** Brugen af Middleware til at håndtere logning (`AfterEndpointPrintMiddleware`) og publicering til RabbitMQ (`AfterEndpointPublishMiddleware`) er en meget kreativ løsning. Det holder controlleren "ren", men vær opmærksom på, at det kan gøre flowet lidt sværere at gennemskue for andre udviklere, da logikken er "gemt" væk fra selve handlingen.

## RabbitMQ Integration
- **Topics:** Flot implementering af bonusopgaven med `Topic` exchanges! Det giver god fleksibilitet, at skærmene selv kan vælge, hvilke informationer de vil abonnere på (f.eks. kun forsinkede fly).
- **Middleware-publicering:** Din middleware henter alle fly fra databasen og sender dem som en liste efter hvert request. Det fungerer fint som en "full refresh" til skærmene, men i et stort system ville man typisk kun sende det fly, der lige er blevet opdateret.
- **Connection Handling:** Det er godt, at du genbruger `IChannel` som en singleton. Vær dog opmærksom på, at i RabbitMQ er kanaler (`IChannel`) ikke trådsikre (thread-safe). I en rigtig web-api med mange samtidige brugere kunne det give problemer. En `ChannelPool` eller en "channel per request" model ville være sikrere.

## Konsol Applikation (Flight Info Screen)
- **Præsentation:** Din `PrintFlights` metode laver et rigtig flot og læsbart layout i konsollen. Det ligner en rigtig lufthavnstavle!
- **Interaktivitet:** Det er en god detalje, at brugeren kan vælge mellem forskellige topics ved opstart.

## Forslag til forbedringer
- **Modeller:** Din `FlightInfo` model bruger en kompleks løsning med en privat enum og en string-property med validering. I C# er det ofte lettere at bruge en public enum direkte som property-type; EF Core og JSON-serialisering kan sagtens håndtere det. Jeg har lavet en lille rettelse herfor som et eksempel.

Super godt gået! Din løsning viser en god forståelse for systemintegration og asynkron kommunikation.

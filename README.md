API pro správu zaměstnanců

- cílový framework: .NET 7.0
Projekt využívá ORM Entity framework core a OpenAPI.
Pro ukládání dat je použita databáze SQLite.

Jsou naimplementovány Endpointy:
- GET /api/employees - vrací seznam všech zaměstnanců
- GET /api/employees/{id} - vrací údaje zaměstnance na základě zadaného ID
- POST /api/employees - uloží nového zaměstnance na základě přiložených údajů
- PUT /api/employees/{id} - upravý údaje zaměstnance na základě zadaného ID a json údajů zaměstnance v těle požadavku
- DELETE /api/employees/{id} - odstraní záznam zaměstnance z databáze na základě zadaného ID

Při ukládání záznamu se validuje jedinečnost emailové adresy oproti záznamům v databázi.

Databáze s testovacími daty je vytvořena ve složce ../Data. 
Pro vytvoření čisté databáze zadejte v projektu příkaz "dotnet ef database update".

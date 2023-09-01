# Domain Models

## Menu

```csharp
class Menu {
    Menu Create();
    void AddDinner();
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection menuSection);
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "dinnerIds": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "menuReviewIds": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "sections": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 10.99
        }
      ]
    }
  ],
  "createdDateTime": "0001-01-01T00:00:00",
  "updatedDateTime": "0001-01-01T00:00:00",
  "averageRating": 4.5
}
```

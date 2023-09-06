# Create Menu

## Create Menu Request

```js
POST /hosts/{hostId}/menus
```

 ```json
{
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "sections": [
      {
        "name": "Appetizers",
        "description": "Starters",
        "items": [
          {
            "name": "Hummus",
            "description": "A delicious chickpea dip",
          },
          {
            "name": "Falafel",
            "description": "A delicious chickpea ball",
          }
        ]
      }
    ]
}
 ```
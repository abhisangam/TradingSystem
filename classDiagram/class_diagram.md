```mermaid
    classDiagram
    direction LR

    namespace ShopInventory {
        class ShopInventoryController
        class ShopInventoryModel
        class ShopInventoryView
    }

    namespace PlayerInventory {
        class PlayerInventoryController
        class PlayerInventoryModel
        class PlayerInventoryView
    }

    namespace TradableItem {
        class TradableItemController
        class TradableItemModel
        class TradableItemView
    }



    PlayerInventoryController *-- PlayerInventoryModel
    PlayerInventoryController *-- PlayerInventoryView

    ShopInventoryController *-- ShopInventoryModel
    ShopInventoryController *-- ShopInventoryView

    ShopInventoryController o-- TradableItemController
    PlayerInventoryController o-- TradableItemController

    TradableItemController *-- TradableItemModel
    TradableItemController *-- TradableItemView
    TradableItemModel *-- TradableItemSO

    TradeManager <.. ShopInventoryController
    TradeManager <.. PlayerInventoryController
    TradeManager <.. TradableItemInfoPopupController
    TradeManager <.. TradableItemTradingPopupController

    namespace Inventory {
        class InventoryController
        class InventoryModel
        class InventoryView
    }

    InventoryController <|-- PlayerInventoryController
    InventoryModel <|-- PlayerInventoryModel
    InventoryView <|-- PlayerInventoryView

    InventoryController <|-- ShopInventoryController
    InventoryModel <|-- ShopInventoryModel
    InventoryView <|-- ShopInventoryView

    InventoryController *-- InventoryModel
    InventoryController *-- InventoryView
```
# 故事情境

需要3隻API   

1.FOR創造帳號 &修改帳號  
帳號 密碼 手機   

2.查詢訂單&新增訂單
USER誰買 買了那些商品 價格是多少 有沒有折扣


3.查詢月帳單報表
每個月廠商取得訂單金額的報表
廠商名稱 金額總和 月份

# 專案分層
|專案名稱|層級|功用|
|-------|----|----|
|WebApi|表現層|所有的API INPUT|
|WebApi.DataAccess|資料處理層|所有的各種資料庫使用(包含各種資料)|
|WebApi.Service|服務層|各種檢查商務處理|
|WebApi.ServiceTests|服務測試|進行相關邏輯測試|

# 命名規則
## 物件封裝命名規則:

|各種命名|所在層級|規則|
|-------|----|----|
|Dto|Api|放在在Model中，做對應資料轉換的處理封裝|
|VM|Api|放在在Model中，負責對應API外部資料封裝|
|BO|Service|放在在Model中，負責對應商務資料的封裝|
|DAO|DataAccess|放在在Model中，負責對應相對應的資料表的封裝|

## 資料夾命名規則
|各種命名|所在層級|規則|
|-------|--------|----|
|名詞  |Api|根據API的場景|
|名詞  |Service|根據服務的應用封裝切割|
|名詞  |DataAccess|根據Table的Instance封裝切割|

## Function 命名規則

|各種命名|所在層級|規則|
|-------|--------|----|
|名詞|Class|upper camel case|
|名詞|私有參數|lower camel case|
|名詞|公有參數|upper camel case|
|動詞+名詞|Function|upper camel case ，定義是 這個Function是為了"什麼"做"什麼事情"|


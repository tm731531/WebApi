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

## 資料夾命名規則
|各種命名|所在層級|規則|
|-------|--------|----|
|名詞  |Api|根據API的場景|
|名詞  |Service|根據服務的應用封裝切割|
|名詞  |DataAccess|根據Table的Instance封裝切割|

## 物件後墜命名規則:

|各種命名|所在層級|規則|
|-------|----|----|
|Dto|Api|放在在Model中，做對應資料轉換的處理封裝|
|VM|Api|放在在Model中，負責對應API外部資料封裝|
|BO|Service|放在在Model中，負責對應商務資料的封裝|
|DAO|DataAccess|放在在Model中，負責對應相對應的資料表的封裝|


## 物件封裝 命名規則:

|各種命名|所在層級|規則|
|-------|--------|----|
|名詞|Class|upper camel case|
|" _ " +名詞|私有參數|" _ "+lower camel case |
|名詞|公有參數|upper camel case <br> class的public參數|
|名詞|函數內部參數|lower camel case <br> function 傳遞參數 或是函數內部參數|
|動詞+名詞|Function|upper camel case  <br> 定義是 這個Function是為了"什麼"做"什麼事情"|
|I+名詞|Interface|I+upper camel case <br>  切分定義是 這個介面要攏統的告訴外面是"什麼"跟"能做什麼事情 而這個事情是可抽換的"|
### Example
```
    class Member
    {
        private double _salary = 100.0;
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public bool AddSalary(double amount)
        {
           bool returnValue =false;
           _salary=_salary+amount;
           return returnValue;
        }
        
    }
```

## 函數撰寫規則

|序|規則|用意|
|-------|--------|----|
|1|函數必須分三個區塊 <br> 1.定義區 <br> 2. 操作區 <br> 3. 回傳區 <br> 每個區塊中間用空白空開| 用空白區間分隔可以快速下中斷點理解|
|2|符合"動詞+名詞"即可抽離Function <br> 並且準備測試|這樣可以用function名稱+參數<br>節省大家閱讀時間|
|3|抽離物件不可以因為看不懂而拉出去<br> 為了省空間而省空間|這樣只會不斷的產出沒有意義跟無法重複利用的function|
|4|一個函數只能有一個return|這樣可以明確追蹤回傳值 而不會因為中間一堆的return搞混自己|
|5|非同步使用場景要先考慮資料跟執行序|正確使用非同步可以加速程序進行<br>錯誤的使用會造成執行續加速Lock導致機器不正常|
|6|平行化使用也是要考慮使用的場景|平行化將會無限制的直接把CPU 執行續吃光為了求快速所以使用上必須清楚|
|7|Linq 物件請清楚什麼時候是記憶體<br>什麼時候是只是queryable<br>什麼時候是實際物件|錯誤的時機tolist 會造成記憶體飆漲 <br> 正確的時候下tolist 可以讓程序加速百倍(記憶體連續問題)|

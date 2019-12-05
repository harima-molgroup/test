```uml
@startuml 醤油ラーメンシーケンス図

actor Program
participant Chef
participant ShoyuRamen
participant Noodle
participant Soup
participant Tooping

activate Program

create Chef
Program -> Chef : new()
Program -> Chef : Cook()

deactivate Program

activate Chef

Chef -> Noodle : new("細麺", 300, 1)
Chef -> Soup : new("醤油スープ", 100)
Chef -> Tooping : new("チャーシュー", 75)
Chef -> Tooping : new("メンマ", 50)
Chef -> Tooping : new("たまご", 100)
Chef -> Tooping : new("わかめ", 10)
Chef -> Tooping : new("のり", 10)

create ShoyuRamen
Chef -> ShoyuRamen : new(Noodle, Soup, List<Tooping>)

Chef -> ShoyuRamen : GetCalory()

activate ShoyuRamen

ShoyuRamen --> Chef : 合計カロリー

deactivate ShoyuRamen

deactivate Chef

@enduml
```
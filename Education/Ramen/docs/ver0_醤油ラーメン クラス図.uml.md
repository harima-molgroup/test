```
醤油ラーメンのみの場合のクラス図
```

``` uml
@startuml

class Chef {
  + Cook(): ShoyuRamen 
}

Chef .> ShoyuRamen : > 作る

class ShoyuRamen {
  + GetCalory(): int
}

class Noodle {
  + Name: string
  + Kcal: int
}
class Soup {
  + Name: string
  + Kcal: int
}
class Topping {
  + Name: string
  + Kcal: int
}

ShoyuRamen "1" --> "1" Noodle
ShoyuRamen "1" --> "1" Soup
ShoyuRamen "1" --> "0..n" Topping

@enduml

```
ラーメンが増えた場合のクラス図 (Cookで作り分ける場合)
```

``` uml
@startuml

class Chef {
  + Cook(ramenName: string): Ramen 
}

Chef .> Ramen : if 地獄

class Ramen {
  + GetCalory(): int
}

class Noodle {
  + Name: string
  + Kcal: int
}
class Soup {
  + Name: string
  + Kcal: int
}
class Topping {
  + Name: string
  + Kcal: int
}

Ramen "1" --> "1" Noodle
Ramen "1" --> "1" Soup
Ramen "1" --> "0..n" Topping

@enduml
```

```
ラーメンが増えた場合のクラス図 (種類を増やした場合)
```

``` uml
@startuml

class Chef {
  + CookShoyuRamen()
  + CookMisoRamen()
  + CookTonkotsuRamen() etc...
}

Chef ..> ShoyuRamen : > 作る
Chef ..> MisoRamen : > 作る
Chef ..> TonkotsuRamen : > 作る
Chef ..> ShioRamen : > 作る
Chef ..> IeKeiRamen : > 作る
Chef ..> ToyamaBlack : > 作る

class ShoyuRamen
class MisoRamen
class TonkotsuRamen
class ShioRamen
class IeKeiRamen
class ToyamaBlack

class Noodle
class Soup
class Topping

ShoyuRamen --> Noodle
ShoyuRamen --> Soup
ShoyuRamen --> Topping

MisoRamen --> "1" Noodle
MisoRamen -->  Soup
MisoRamen -->  Topping

TonkotsuRamen --> Noodle
TonkotsuRamen --> Soup
TonkotsuRamen --> Topping

ShioRamen --> Noodle
ShioRamen --> Soup
ShioRamen --> Topping

IeKeiRamen --> Noodle
IeKeiRamen --> Soup
IeKeiRamen --> Topping

ToyamaBlack --> Noodle
ToyamaBlack --> Soup
ToyamaBlack --> Topping

@enduml
```

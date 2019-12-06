``` uml
@startuml

class Chef {
  + Cook(ramenSkill: IRamenFactory): IRamen 
}

Chef .> IRamenFactory : > 腕を振るう

interface IRamenFactory {
  CookRamen(): IRamen
}

class ShoyuRamenFactory
class MisoRamenFactory

ShoyuRamenFactory ..|> IRamenFactory
MisoRamenFactory ..|> IRamenFactory

IRamenFactory .> IRamen : > 作る

interface IFood{
  Name: string
  Kcal: int
}

interface IRamen
class Ramen {
  + AddNoodle()
  + AddSoup()
  + AddTopping()
}
Ramen ..|> IRamen
IRamen -() IFood

class Noodle 
class Soup 
class Topping
IRamen "1" --> "1" Noodle
IRamen "1" --> "1" Soup
IRamen "1" --> "0..n" Topping

Noodle --() IFood
Soup --() IFood
Topping --() IFood

@enduml
```

``` uml
こんなこともできる!!!
@startuml

class Chef {
  + Cook(ramenSkill: IRamenFactory): IRamen 
}

Chef .> IRamenFactory : > 腕を振るう

interface IRamenFactory {
  CookRamen(): IRamen
}

class ShoyuRamenFactory
class MisoRamenFactory
class CornButterMisoRamenFactory
ShoyuRamenFactory ..|> IRamenFactory
MisoRamenFactory ..|> IRamenFactory

CornButterMisoRamenFactory --|> MisoRamenFactory

IRamenFactory .> IRamen : > 作る

interface IFood{
  Name: string
  Kcal: int
}

interface IRamen
class Ramen {
  + AddNoodle()
  + AddSoup()
  + AddTopping()
}
Ramen ..|> IRamen
IRamen -() IFood

class Noodle 
class Soup 
class Topping
IRamen "1" --> "1" Noodle
IRamen "1" --> "1" Soup
IRamen "1" --> "0..n" Topping

Noodle --() IFood
Soup --() IFood
Topping --() IFood

@enduml
```

``` uml
さらに...
@startuml

class Chef {
  + Cook(ramenSkill: IRamenFactory): IRamen 
}

Chef .> IRamenFactory : > 腕を振るう

interface IRamenFactory {
  CookRamen(): IRamen
}

class ShoyuRamenFactory
class MisoRamenFactory
class CornButterMisoRamenFactory
class RamenCurryHamburgerFactory{
  + CookCurry(): ICurry
  + CookHamburger(): IHamburger
}
ShoyuRamenFactory ..|> IRamenFactory
MisoRamenFactory ..|> IRamenFactory
RamenCurryHamburgerFactory ...|> IRamenFactory

CornButterMisoRamenFactory --|> MisoRamenFactory

IRamenFactory .> IRamen : > 作る

interface IFood{
  Name: string
  Kcal: int
}

interface IRamen
class Ramen {
  + AddNoodle()
  + AddSoup()
  + AddTopping()
}
Ramen ..|> IRamen
IRamen -() IFood

class Noodle 
class Soup 
class Topping
IRamen "1" --> "1" Noodle
IRamen "1" --> "1" Soup
IRamen "1" --> "0..n" Topping

Noodle --() IFood
Soup --() IFood
Topping --() IFood

@enduml
```

``` uml
@startuml

class Chef {
  + Cook(ramenSkill: IRamenFactory): IRamen 
}

interface IRamen

class Ramen {
  + AddNoodle
  + AddSoup
  + AddTopping
  + GetCalory(): int
}
Ramen ..|> IRamen

class Noodle 
class Soup 
class Topping

Chef -> IRamenFactory : > 腕を振るう
IRamen "1" -- "1" Noodle
IRamen "1" -- "1" Soup
IRamen "1" -- "0..n" Topping

interface IRamenFactory {
  CookRamen()
}
IRamenFactory -> IRamen : > 作る

class ShoyuRamenFactory
class MisoRamenFactory
class CornButterMisoRamenFactory
ShoyuRamenFactory ..|> IRamenFactory
MisoRamenFactory ..|> IRamenFactory

CornButterMisoRamenFactory --|> MisoRamenFactory

@enduml
```
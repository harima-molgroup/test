``` uml
@startuml

class Chef {
  + Cook(): ShoyuRamen 
}

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

Chef -> ShoyuRamen : > 作る
ShoyuRamen "1" -- "1" Noodle
ShoyuRamen "1" -- "1" Soup
ShoyuRamen "1" -- "0..n" Topping

@enduml
```
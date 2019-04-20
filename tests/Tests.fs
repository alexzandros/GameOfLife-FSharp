module Tests

open System
open Xunit
open GameOfLife

let g1 = GameGrid (array2D [[Dead]]) :> Object
let g2 = GameGrid (array2D [[Alive]]) :> Object
let g3 = GameGrid (array2D [[Alive;Alive];[Alive;Alive]]) :> Object
let g4 = GameGrid (array2D [[Dead;Alive];[Alive;Alive]]) :> Object
let g5 = GameGrid (array2D [[Dead;Alive];[Dead;Alive]]) :> Object
let g6 = GameGrid (array2D [[Dead;Dead];[Dead;Dead]]) :> Object
let g7 = GameGrid (array2D [[Alive;Alive;Dead];[Dead;Alive;Alive];[Alive;Alive;Alive]]) :> Object
let g8 = GameGrid (array2D [[Alive;Alive;Alive];[Dead;Dead;Dead];[Alive;Dead;Alive]]) :> Object
let g9 = GameGrid (array2D [[Dead;Alive;Dead];[Alive;Dead;Alive];[Dead;Dead;Dead]]) :> Object


let single = seq {
    yield [| g1; g1 |]
    yield [| g2; g1 |]
    yield [| g3; g3 |]
    yield [| g4; g3 |]
    yield [| g5; g6 |]
    yield [| g7; g8 |]
    yield [| g8; g9 |]
} 

[<Theory>]
[<MemberData("single")>]
let ``prueba 1`` (current:GameGrid) (next: GameGrid) = 
    Assert.Equal(next, current |> nextGen)
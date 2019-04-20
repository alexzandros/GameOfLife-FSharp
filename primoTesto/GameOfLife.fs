module GameOfLife 

    type Cell = 
    | Dead
    | Alive

    type GameGrid = GameGrid of Cell [,]
    
    type Coordinate = {
        x: int
        y: int
    }

    let coord x y = {
        x = x;
        y = y
    }

    let north coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x, coord.y - 1]

    let northeast coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x + 1, coord.y - 1]

    let east coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x + 1, coord.y]

    let southeast coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x + 1, coord.y + 1]

    let south coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x, coord.y + 1]

    let southwest coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x - 1, coord.y + 1]

    let west coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x - 1, coord.y]

    let northwest coord grid =
        match grid with 
        | GameGrid grid -> grid.[coord.x - 1, coord.y - 1]

    let neighbourghCount coord  grid = 
        let cellFromNeighbourgh f = 
            try
                f coord grid
            with 
            | ex -> Dead           
        let neigh = [north; northeast; east; southeast;
                        south; southwest; west; northwest] 
        neigh 
        |> List.map cellFromNeighbourgh
        |> List.filter (function | Alive -> true | Dead -> false )
        |> List.length

    let nextGenCell cell count =
        match cell with 
        | Alive when count = 2  || count = 3 -> Alive
        | Dead when count = 3 -> Alive 
        | _ -> Dead
                    
    let nextGen grid = 
        match grid with 
        | GameGrid innerGrid ->
            innerGrid
            |> Array2D.mapi (fun x y elem -> 
                                grid
                                |> neighbourghCount (coord x y)
                                |> nextGenCell elem) 
            |> GameGrid                    
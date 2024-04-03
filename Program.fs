printfn "This is John Carlo Hipolito's Code!"

printfn "\nRecords:"
type Coach = { Name: string; FormerPlayer: bool }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }

printfn "\nList of Teams:"
let teams =[
      { Name = "Boston Celtics"; Coach = { Name = "Joe Mazzulla"; FormerPlayer = true }; Stats = { Wins = 3570; Losses = 2462 }}
      { Name = "Los Angeles Lakers"; Coach = { Name = "Darvin Ham"; FormerPlayer = true }; Stats = { Wins = 3503; Losses = 2419 }}
      { Name = "Miami Heat"; Coach = { Name = "Erik Spoelstra"; FormerPlayer = true }; Stats = { Wins = 1475; Losses = 1328 }}
      { Name = "New York Knicks"; Coach = { Name = "Tom Thibodeau"; FormerPlayer = true }; Stats = { Wins = 2924; Losses = 3099 }}
      { Name = "Toronto Raptors"; Coach = { Name = "Darko Rajakovic"; FormerPlayer = false }; Stats = { Wins = 1071; Losses = 1157 }} ]
teams
|> List.iter (printfn "%A")

printfn "\nSuccessful Teams:"
teams
|> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)
|> List.map (_.Name)
|> List.iter (printfn "%s")

printfn "\nSuccess Percentages:"
teams
|> List.map (fun team -> (team.Name, (float team.Stats.Wins / float(team.Stats.Wins + team.Stats.Losses)) * 100.0))
|> List.iter(fun (name, pct) -> printf $"%s{name}: %.2f{pct}%%\n")

printfn "\nDiscriminated Union:"
type Cuisine =
    | Korean
    | Turkish
    
type MovieType =
    | Regular
    | IMax
    | DBox
    | RegularWithSnacks
    | IMaxWithSnacks
    | DBoxWithSnacks
    
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of km: int * fuel: float

let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movie ->
        match movie with
        | Regular -> 12.0 * 2.0
        | IMax -> 17.0 * 2.0
        | DBox -> 20.0 * 2.0
        | RegularWithSnacks -> (12.0 + 5.0) * 2.0
        | IMaxWithSnacks -> (17.0 + 5.0) * 2.0
        | DBoxWithSnacks -> (20.0 + 5.0) * 2.0
    | Restaurant restaurant ->
        match restaurant with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (km, fuel) -> float km * fuel
    
let watchAMovie = calculateBudget(Movie IMaxWithSnacks)
let dineOut = calculateBudget(Restaurant Korean)
let torontoToNiagara = calculateBudget(LongDrive (250, 1.5))
    
printfn $"\nThe cost of watching a movie in IMAX theater with snacks is: %.2f{watchAMovie} CAD"
printfn $"The cost of eating in a Korean restaurant is: %.2f{dineOut} CAD"
printfn $"The cost of a long drive is: %.2f{torontoToNiagara} CAD"
printfn $"Total cost of the activities: %.2f{watchAMovie + dineOut + torontoToNiagara} CAD"
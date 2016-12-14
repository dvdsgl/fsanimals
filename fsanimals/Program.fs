// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System.IO

let rand = System.Random()
let animals =
    File.ReadAllLines("../../animals.txt")
    |> Array.map (fun s -> s.ToLower())

let adjectives =
    File.ReadAllLines("../../adjectives.txt")
    |> Array.map (fun s -> s.ToLower())

let adjectivesByLetter =
    adjectives
    |> Array.groupBy (fun s -> s.[0])
    |> dict

let getAdjectiveAnimal() =
    let animal = animals.[rand.Next(animals.Length)]
    let adjective = adjectives.[rand.Next(adjectives.Length)]
    (adjective, animal)

let pairs = seq {
    while true do
        yield getAdjectiveAnimal()
}

[<EntryPoint>]
let main argv =
    printfn "%A" (pairs |> Seq.take 100 |> List.ofSeq)
    0 // return an integer exit code


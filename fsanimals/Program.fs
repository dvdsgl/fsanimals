open System.IO

let rand = System.Random()

let animals =
    File.ReadAllLines("../../animals.txt")
    |> Array.map (fun s -> s.ToLower())

let adjectives =
    File.ReadAllLines("../../adjectives.txt")
    |> Array.map (fun s -> s.ToLower())

let getAdjectiveAnimal() =
    let random (array : 'a[]) = array.[rand.Next(array.Length)]
    (random adjectives, random animals)

let pairs = Seq.initInfinite (fun _ -> getAdjectiveAnimal())

[<EntryPoint>]
let main argv =
    printfn "%A" (pairs |> Seq.take 100 |> List.ofSeq)
    0
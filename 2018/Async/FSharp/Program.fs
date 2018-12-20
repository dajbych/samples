open System
open System.Net

// F# 2007
// computation expression

let fetchAsync(url : string) =
    async {
        try
            let uri = new Uri(url)
            let webClient = new WebClient()
            let! html = Async.AwaitTask(webClient.DownloadStringTaskAsync(uri))
            printfn "Downloaded %d characters" html.Length
        with
            | ex -> printfn "%s" (ex.Message);
    }

[<EntryPoint>]
let main argv = 

    fetchAsync("http://localhost:55558/")
    |> Async.RunSynchronously
    |> ignore
    
    Console.ReadLine() |> ignore
    
    0 
module SieveOfEratosthenes

let siebWhile n =
    let toCheck = Array.zeroCreate<int> (n + 1)
    let crossedV = -1
    
    let mutable i = 2
    while i <= n do
        if toCheck.[i] <> crossedV then
            toCheck.[i] <- i
            
            let mutable j = i + i
            while j <= n do
                toCheck.[j] <- crossedV
                j <- j + i
        i <- i + 1
    toCheck

let siebFor n =
    let toCheck = Array.zeroCreate<int> (n + 1)
    let crossedV = -1
    
    for i in 2..n do
        if toCheck.[i] <> crossedV then
            toCheck.[i] <- i
            
            for j in (i+i).. i .. n do
                toCheck.[j] <- crossedV
    toCheck

let siebIter n =
    let toCheck = Array.zeroCreate<int> (n + 1)
    let crossedV = -1
    
    toCheck
    |> Array.iteri (fun i v ->
        if i < 2 then ()
        elif toCheck.[i] <> crossedV then
            toCheck.[i] <- i
            
            for j in (i+i).. i .. n do
                toCheck.[j] <- crossedV
        else ())
    toCheck

let siebPIter n =
    let toCheck = Array.zeroCreate<int> (n + 1)
    let crossedV = -1
    
    toCheck |> Array.Parallel.iteri (fun i v ->
        if i < 2 then ()
        elif toCheck.[i] <> crossedV then
            toCheck.[i] <- i

            for j in (i+i).. i .. n do
                toCheck.[j] <- crossedV
        else ())
    toCheck

let siebRec n =
    let toCheck = Array.zeroCreate<int> (n + 1)
    let crossedV = -1

    // F# has tail call optimizations and can transform that into a whie loop
    let rec loopi i =
        if i <= n then
            if toCheck.[i] <> crossedV then
                toCheck.[i] <- i
                
                let rec loopj j =
                    if j <= n then
                        toCheck.[j] <- crossedV
                        loopj (j+i)
                loopj (2*i)
            loopi (i+1)
    loopi (2)
    
    // return
    toCheck



module Performance =

    open System.Diagnostics
    
    let measure name f =
        let sw = Stopwatch()
        sw.Start()
        let res = f()
        sw.Stop()
        printfn "%50s  --  %fs" name sw.Elapsed.TotalSeconds
        res
    
    let filterPrim v = v |> Array.filter (fun x -> x > 0)
    
    let cases = [
        siebWhile, "while loop"
        siebFor, "for loop"
        siebIter, "Array.iteri (outer) for loop (inner)"
        siebPIter, "Array.Parallel.iteri (outer) for loop (inner)"
        siebRec, "Tail recursion (both)"
    ]
    
    let benchmark() =
        let n = 50_000_000

        printfn ""

        for (case, desc) in cases do
            (fun () -> case n) |> measure desc |> ignore
    
        printfn ""
        printfn ""

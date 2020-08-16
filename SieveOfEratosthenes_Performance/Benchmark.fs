namespace Benchmark

open BenchmarkDotNet.Attributes

type SieveOfEratosthenes() =
    [<Params(10_000_000, 50_000_000, 100_000_000)>]
    member val n = 0 with get, set

    [<Benchmark>]
    member this.For() = SieveOfEratosthenes.siebFor this.n

    [<Benchmark>]
    member this.While() = SieveOfEratosthenes.siebWhile this.n

    [<Benchmark>]
    member this.Iter() = SieveOfEratosthenes.siebIter this.n

    [<Benchmark>]
    member this.PIter() = SieveOfEratosthenes.siebPIter this.n

    [<Benchmark>]
    member this.Rec() = SieveOfEratosthenes.siebRec this.n

module Program =
    open BenchmarkDotNet.Running

    [<EntryPoint>]
    let main _ =
        BenchmarkRunner.Run<SieveOfEratosthenes>() |> ignore
        0
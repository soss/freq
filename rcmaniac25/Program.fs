open System
open System.IO

[<EntryPoint>]
let main argv = 
    let filePath,printBar =
        match argv.Length with
        | 0 ->
            printf "Please enter the file path: "
            Console.ReadLine(),true
        | _ -> argv.[0],(argv |> Seq.skip 1 |> Seq.tryFind(fun w -> w.ToLower() = "nobox")).IsNone

    if not(File.Exists(filePath))
    then
        printfn "Could not find '%s'" filePath
        0
    else
        let toString (chars : char[]) = String(chars)

        use file = new StreamReader(filePath)
        let cleanChars =
            file.ReadToEnd()
            |> Seq.choose(fun c ->
                match c with
                | '\'' | '"' | '\n' | '\t' | '\r' -> None
                | c when not(Char.IsLetter(c)) -> Some ' '
                | _ -> Some(Char.ToLower(c)))
            |> Seq.toArray
            |> toString
        let words =
            cleanChars.Split([| ' '; |], StringSplitOptions.RemoveEmptyEntries)
            |> Seq.groupBy id
            |> Seq.map(fun (w,s) -> w,(s |> Seq.length))
            |> Seq.sortBy(fun (_,c) -> -c)

        let largestWord = (words |> Seq.maxBy(fun (w,_) -> w.Length) |> fst).Length
        let totalWords = words |> Seq.sumBy(fun (_,c) -> c)

        words
        |> Seq.iter(fun (w,c) ->
            let spaces = String(' ', largestWord - w.Length)
            printf "%s%s: " spaces w
            if printBar
            then
                let boxes = String('▇', c)
                printfn "%s" boxes
            else printfn "%d" c)

        0

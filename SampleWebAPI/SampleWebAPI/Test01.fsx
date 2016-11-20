#r @"..\packages\Suave.1.1.3\lib\net40\Suave.dll"
#load "BuzLogic.fsx"

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open BuzLogic

let app =
  choose
    [ GET >=> choose
        [ 
            path "/hello" >=> OK "Hello GET";
            path "/goodbye" >=> OK "Good bye GET" 
            path "/gettime" >=> request (fun r -> OK (TestInfo.getTime()))
        ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST";
          path "/goodbye" >=> OK "Good bye POST" ] ]

startWebServer defaultConfig app



namespace kashtocash.Controllers

open System
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.Collections.Generic
open kashtocash.Models


open Microsoft.FSharp.Collections

type HomeController(logger: ILogger<HomeController>) =
    inherit Controller()

    member this.Index() =
        this.View()

    member this.Privacy() =
        this.View()

    member this.About() =
        this.View()

    
    member this.Products() =
         let products = [
           { Id = 1; Title = "Kashmiri Shawl"; Description = "Hand-woven pure wool shawl"; ImageUrl = "/images/product1.jpg"; Price = 2499.00M }
           { Id = 2; Title = "Pashmina Scarf"; Description = "Luxurious pashmina scarf"; ImageUrl = "/images/product2.jpg"; Price = 1899.00M }
           { Id = 3; Title = "Carved Walnut Box"; Description = "Intricately carved walnut wood box"; ImageUrl = "/images/product3.jpg"; Price = 1299.00M }
         ]

         let csharpList = List<Product>(products) // Convert F# list to C# List<Product>
         this.View(csharpList)

       [<HttpGet>]
       [<Route("Cart")>] // maps cart directly
      member this.Cart() =
        let cartItemsFsharp = [
           { ProductId = 1; Title = "Kashmiri Shawl"; Quantity = 2; Price = 2499.00M; ImageUrl = "/images/product1.jpg" }
           { ProductId = 2; Title = "Pashmina Scarf"; Quantity = 1; Price = 1899.00M; ImageUrl = "/images/product2.jpg" }
        ]

    // Convert F# list to .NET List<CartItem>
        let cartItemsDotNet = System.Collections.Generic.List<kashtocash.Models.CartItem>(cartItemsFsharp)

        this.View(cartItemsDotNet)






    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error() =
        let reqId =
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })

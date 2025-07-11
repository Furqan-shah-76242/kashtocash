namespace kashtocash.Models

[<CLIMutable>]
type Product = {
    Id: int
    Title: string
    Description: string
    ImageUrl: string
    Price: decimal
}

using System.Text.Json.Serialization;

namespace api
{
    // use C# 9+ record reference type
    // compare this POCO by value when using equality operators
    // For record types, including record struct and readonly record struct, two objects are equal if they are of the same type and store the same values.
    // For records, the implementation is compiler synthesized and uses the declared data members.        
    
    public record StoresRequest([property: JsonPropertyName("id")] int ID,
    [property: JsonPropertyName("inventoryID")] int InventoryID,
    [property: JsonPropertyName("requestedKernels")] int RequestedKernels);
}
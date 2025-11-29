using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Crk_Topping_Scanner
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "ItemType")]
    [JsonDerivedType(typeof(Topping), "Topping")]
    [JsonDerivedType(typeof(Beascuit), "Beascuit")]
    internal interface Iitem
    {
    }
}

using System.Runtime.Serialization;
using FLovers.DAL.Repository.Entities;
using Newtonsoft.Json;

namespace FLovers.DAL.Repository.Dtos
{
    [DataContract]
    public class ProductDto
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("weightedItem")]
        public bool? WeightedItem { get; set; } = false;

        [DataMember]
        [JsonProperty("suggestedSellingPrice")]
        public decimal SuggestedSellingPrice { get; set; }


        public static ProductDto FromModel(Product model)
        {
            return new ProductDto()
            {
                Id = model.Id, 
                Name = model.Name, 
                WeightedItem = model.WeightedItem, 
                SuggestedSellingPrice = model.SuggestedSellingPrice, 
            }; 
        }

        public Product ToModel()
        {
            return new Product()
            {
                Id = Id, 
                Name = Name, 
                WeightedItem = WeightedItem, 
                SuggestedSellingPrice = SuggestedSellingPrice, 
            }; 
        }
    }
}
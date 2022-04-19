using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
   
        public class Customer
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        public class Address
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string company { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public int cityCode { get; set; }
            public int cityId { get; set; }
            public string district { get; set; }
            public int districtId { get; set; }
            public int neighborhoodId { get; set; }
            public string neighborhood { get; set; }
            public string apartmentNumber { get; set; }
            public string floor { get; set; }
            public string doorNumber { get; set; }
            public string addressDescription { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string phone { get; set; }
        }

        public class Item
        {
            public string packageItemId { get; set; }
            public long lineItemId { get; set; }
            public bool isCancelled { get; set; }
        }

        public class ModifierProduct
        {
            public string name { get; set; }
            public double price { get; set; }
            public int productId { get; set; }
            public int modifierGroupId { get; set; }
            public List<object> modifierProducts { get; set; }
            public List<ExtraIngredient> extraIngredients { get; set; }
            public List<RemovedIngredient> removedIngredients { get; set; }
        }

        public class ExtraIngredient
        {
            public int id { get; set; }
            public string name { get; set; }
            public double price { get; set; }
        }

        public class RemovedIngredient
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Line
        {
            public double price { get; set; }
            public double unitSellingPrice { get; set; }
            public int productId { get; set; }
            public string name { get; set; }
            public List<Item> items { get; set; }
            public List<ModifierProduct> modifierProducts { get; set; }
            public List<ExtraIngredient> extraIngredients { get; set; }
            public List<RemovedIngredient> removedIngredients { get; set; }
        }

        public class CancelInfo
        {
            public int reasonCode { get; set; }
        }

        public class Content
        {
            public string id { get; set; }
            public int supplierId { get; set; }
            public int storeId { get; set; }
            public string orderCode { get; set; }
            public string orderId { get; set; }
            public string orderNumber { get; set; }
            public long packageCreationDate { get; set; }
            public long packageModificationDate { get; set; }
            public int preparationTime { get; set; }
            public double totalPrice { get; set; }
            public string callCenterPhone { get; set; }
            public string deliveryType { get; set; }
            public Customer customer { get; set; }
            public Address address { get; set; }
            public string packageStatus { get; set; }
            public List<Line> lines { get; set; }
            public string customerNote { get; set; }
            public long lastModifiedDate { get; set; }
            public bool isCourierNearby { get; set; }
            public CancelInfo cancelInfo { get; set; }
            public string eta { get; set; }

        }

        public class TrendyolYemekOrder
        {
            public int page { get; set; }
            public int size { get; set; }
            public int totalPages { get; set; }
            public int totalCount { get; set; }
            public List<Content> content { get; set; }
        }
    }

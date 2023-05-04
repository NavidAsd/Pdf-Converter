using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Commons
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime InsertTime { get; set; } = DateTime.Now;
        [Column(TypeName = "date")]
        public DateTime? LastUpdate { get; set; }
        public bool IsRemoved { get; set; } = false;
        [Column(TypeName = "date")]
        public DateTime? RemoveTime { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {
    }

    public abstract class FeaturesBasic<TKey> : BaseEntity
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
        public string FileOutName { set; get; }
        public string QRImage { set; get; }
        public string ShortLink { set; get; }
    }
    public abstract class FeaturesBasic : FeaturesBasic<long>
    {
    }

}

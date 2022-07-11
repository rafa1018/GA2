using System;

namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Base Auditory Tables
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>20/03/2021</date>
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public Guid MODIFIEDBY { get; set; }
        public DateTime MODIFIEDON { get; set; }
        public Guid CREATEBY { get; set; }
        public DateTime CREATEON { get; set; }
        public bool STATE { get; set; }
    }
}

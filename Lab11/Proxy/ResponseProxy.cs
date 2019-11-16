using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11.Proxy
{
    public class ResponseProxy<TEntity> : ICloneable where TEntity : class, new()
    {
        public bool Exitoso { get; set; }
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public IEnumerable<TEntity> listado { get; set; }
        public TEntity objeto { get; set; }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
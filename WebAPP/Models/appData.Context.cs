﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WebAPPEntities : DbContext
    {
        public WebAPPEntities()
            : base("name=WebAPPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<ReferenceValue> ReferenceValues { get; set; }
    
        public virtual int sp_GetDataFromTable(string tableName, Nullable<int> currentPage, Nullable<int> itemPerPage, string orderBy, ObjectParameter recordCount)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));
    
            var currentPageParameter = currentPage.HasValue ?
                new ObjectParameter("CurrentPage", currentPage) :
                new ObjectParameter("CurrentPage", typeof(int));
    
            var itemPerPageParameter = itemPerPage.HasValue ?
                new ObjectParameter("ItemPerPage", itemPerPage) :
                new ObjectParameter("ItemPerPage", typeof(int));
    
            var orderByParameter = orderBy != null ?
                new ObjectParameter("OrderBy", orderBy) :
                new ObjectParameter("OrderBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetDataFromTable", tableNameParameter, currentPageParameter, itemPerPageParameter, orderByParameter, recordCount);
        }
    }
}

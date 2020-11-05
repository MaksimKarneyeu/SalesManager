using SalesManager.Data.Context;
using SalesManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SalesManager.Data.Context
{
    public class ContextInitializer : DropCreateDatabaseAlways<SalesManagerContext>
    {
        protected override void Seed(SalesManagerContext context)
        {
            Document testDoc = new Document {
                Name = "Test Doc",
                EndUploadTime = DateTime.Now, 
                StartUploadTime = DateTime.Now, 
                Sales = new List<Sale>
                { 
                    new Sale 
                    { 
                        Country = "Test"
                    } 
                } 
            };

            context.Document.Add(testDoc);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

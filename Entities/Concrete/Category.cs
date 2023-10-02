using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Concrete altındaki her bir class IEntity implement etmelidir.

    public class Category: IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

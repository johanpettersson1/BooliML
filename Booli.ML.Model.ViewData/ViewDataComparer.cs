using System;
using System.Collections.Generic;

namespace Booli.ML.Model.ViewData
{
    class ViewDataComparer : IEqualityComparer<ViewData>
    {
        public bool Equals(ViewData x, ViewData y)
        {
            return x.County == y.County && x.Municipality == y.Municipality && x.StreetAddress == y.StreetAddress;
        }

        public int GetHashCode(ViewData vd)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(vd, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = vd.StreetAddress == null ? 0 : vd.StreetAddress.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = vd.Municipality.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }
    }

}

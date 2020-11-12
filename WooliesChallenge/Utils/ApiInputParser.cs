using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WooliesChallenge.Models;
using Microsoft.AspNetCore.Http;

namespace WooliesChallenge.Utils
{
    public static class ApiInputParser
    {
        public static SortOption GetSortOption(string sortOption)
        {
            if (string.IsNullOrWhiteSpace(sortOption))
            {
                return SortOption.Ascending;
            }
            var sortOptionEnum = Enum.Parse<SortOption>(sortOption, ignoreCase:true);
            return Enum.IsDefined(typeof(SortOption), sortOptionEnum) ? sortOptionEnum : SortOption.Ascending;
        }
    }
}

using System;
using System.Linq;

namespace Soat.CleanCoders.DipKata.Repository
{
    public class LoaderFactory
    {
        public static ILoader GetLoader(string fileName)
        {
            var extension = fileName.Split('.').ToArray().Last();
            if (extension == "json")
            {
                return new JsonFriendsLoader(fileName);
            }
            throw new ArgumentException("Extension of filename not recognised");
        }

    }
}

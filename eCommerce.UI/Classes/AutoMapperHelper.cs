using System;
using System.Linq;
using System.Reflection;

namespace eCommerce
{
    public class QMapper
    {
        public static object CloneClassicVersion(object source, Type targetType)
        {
            // ihtiyac duyulan tipe ait nesne runtime'da örneklenir
            var result = Activator.CreateInstance(targetType);
            // .net reflection api kullanılırak kaynak ve hedef tipin üye degiskenleri elde edilir
            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = targetType.GetProperties();

            // hedef tipin uye degiskenleri uzerinden donguye girlir
            foreach (var targetProperty in targetProperties)
            {
                // linq kullanıp ikinci donguye girilmeyebilinirdi, okunabilirlik ve basitlik
                // adına böyle bıraktım, linq ifade: 
                //var currentProperty = sourceProperties.First(a => a.Name == targetProperty.Name);
                foreach (var sourceProperty in sourceProperties)
                {
                    // eslesen uye degiskenler saptanır, kaynaktan hedefe dogru deger atanır
                    if (sourceProperty.Name == targetProperty.Name)
                    {
                        targetProperty.SetValue(result, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }

            return result;

        }

        public static TTarget CloneGenericVersion<TTarget>(object source)
        {
            var result = (TTarget)Activator.CreateInstance(typeof(TTarget));

            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = typeof(TTarget).GetProperties();

            foreach (var targetProperty in targetProperties)
            {
                foreach (var sourceProperty in sourceProperties)
                {
                    if (sourceProperty.Name == targetProperty.Name)
                    {
                        targetProperty.SetValue(result, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }

            return result;

        }
    }
}
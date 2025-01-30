using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;

namespace ProductosMVVM.Models.Services
{
    internal class SettinsService
    {
        public List<CultureInfo> idiomas = new();

        public List<CultureInfo> GetCulturas()
        {
            idiomas.Add(new CultureInfo("es-ES"));
            idiomas.Add(new CultureInfo("en-US"));
            return idiomas;
        }

        public void GetCulture(CultureInfo culture)
        {
            if (culture != null)
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

            }
         
        }
    }
}
    

using System;

namespace Mhetrika.Web.ViewModels
{
    public class NewLaboratoryViewModel
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate
        {
            get { return DateTime.Now; }
        }
        public DateTime ModifiedDate
        {
            get { return DateTime.Now; }
        }
        public AddressViewModel AddressViewModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Domain.Entities
{
    public class Url
    {
        #region Atributos
        private String? _id;
        private string _urlOriginal;
        private string _urlNova;
        #endregion

        #region propriedades
        public String? Id { get => _id; set => _id = value; }
        public string UrlOriginal { get => _urlOriginal; set => _urlOriginal = value; }
        public string UrlNova { get => _urlNova; set => _urlNova = value; }
        #endregion
    }
}

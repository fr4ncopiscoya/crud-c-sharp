using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attributes
{
    public class Attributes
    {
        private string id;
        private string name;
        private string lastname;
        private string sexo;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Sexo { get => sexo; set => sexo = value; }
    }
}

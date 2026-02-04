using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications;
public class Notifiers
{

    public Notifiers() { }

    [NotMapped]
    public string PropertyName {  get; set; }
    [NotMapped]
    public string mensagem {  get; set; }
    [NotMapped]
    public List<Notifiers> Notcations{  get; set; }

    public bool ValidateStringProperty(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(PropertyName))
        {
            Notcations.Add(new Notifiers()
            {
                mensagem = "Campo Obrigatório",
                PropertyName = propertyName
            });
        return false;
        }
        return true;
    }

    public bool ValidateIntProperty(int valor, string PropertyName)
    {
        if (valor < 1 || string.IsNullOrWhiteSpace(PropertyName))
        {
            Notcations.Add(new Notifiers
            {
                mensagem = "Valor deve ser maior que 0",
                PropertyName = PropertyName
            });

            return false;
        }

        return true;
    }

    public bool ValidateDecimalValue(decimal valor, string PropertyName)
    {
        if (valor < 1 || string.IsNullOrWhiteSpace(PropertyName))
        {
            Notcations.Add(new Notifiers
            {
                mensagem = "Valor deve ser maior que 0",
                PropertyName = PropertyName
            });

            return false;
        }

        return true;
    }

}
